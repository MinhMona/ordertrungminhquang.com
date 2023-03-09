﻿using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.Search;
using NhapHangV2.Extensions;
using NhapHangV2.Interface.DbContext;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.Services.Auth;
using NhapHangV2.Interface.Services.Catalogue;
using NhapHangV2.Interface.Services.Configuration;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Request;
using NhapHangV2.Service.Services.Auth;
using NhapHangV2.Service.Services.Catalogue;
using NhapHangV2.Service.Services.DomainServices;
using NhapHangV2.Utilities;
using NPOI.POIFS.Crypt.Dsig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Service.Services
{
    public class TransportationOrderService : DomainService<TransportationOrder, TransportationOrderSearch>, ITransportationOrderService
    {
        protected readonly IAppDbContext Context;
        protected readonly IUserService userService;
        protected readonly IConfigurationsService configurationsService;
        protected readonly IWarehouseFeeService warehouseFeeService;
        protected readonly IRequestOutStockService requestOutStockService;
        protected readonly IHistoryPayWalletService historyPayWalletService;
        private readonly INotificationSettingService notificationSettingService;
        private readonly INotificationTemplateService notificationTemplateService;
        private readonly ISendNotificationService sendNotificationService;
        protected readonly IUserInGroupService userInGroupService;
        private readonly ISMSEmailTemplateService sMSEmailTemplateService;
        private readonly IServiceProvider serviceProvider;

        public TransportationOrderService(IServiceProvider serviceProvider, IAppUnitOfWork unitOfWork, IMapper mapper, IAppDbContext Context) : base(unitOfWork, mapper)
        {
            this.Context = Context;
            this.serviceProvider = serviceProvider;
            userService = serviceProvider.GetRequiredService<IUserService>();
            configurationsService = serviceProvider.GetRequiredService<IConfigurationsService>();
            warehouseFeeService = serviceProvider.GetRequiredService<IWarehouseFeeService>();
            requestOutStockService = serviceProvider.GetRequiredService<IRequestOutStockService>();
            historyPayWalletService = serviceProvider.GetRequiredService<IHistoryPayWalletService>();
            notificationSettingService = serviceProvider.GetRequiredService<INotificationSettingService>();
            notificationTemplateService = serviceProvider.GetRequiredService<INotificationTemplateService>();
            sendNotificationService = serviceProvider.GetRequiredService<ISendNotificationService>();
            userInGroupService = serviceProvider.GetRequiredService<IUserInGroupService>();
            sMSEmailTemplateService = serviceProvider.GetRequiredService<ISMSEmailTemplateService>();

        }

        protected override string GetStoreProcName()
        {
            return "TransportationOrder_GetPagingData";
        }

        public override async Task<PagedList<TransportationOrder>> GetPagedListData(TransportationOrderSearch baseSearch)
        {
            PagedList<TransportationOrder> pagedList = new PagedList<TransportationOrder>();
            SqlParameter[] parameters = GetSqlParameters(baseSearch);
            pagedList = await this.unitOfWork.Repository<TransportationOrder>().ExcuteQueryPagingAsync(this.GetStoreProcName(), parameters);
            //Lấy cân tính tiền
            foreach (var item in pagedList.Items)
            {
                var smallPackage = await this.unitOfWork.Repository<SmallPackage>().GetQueryable().Where(e => !e.Deleted && e.Id == item.SmallPackageId).FirstOrDefaultAsync();
                if (smallPackage != null)
                {
                    item.PayableWeight = smallPackage.PayableWeight;
                    item.VolumePayment = smallPackage.VolumePayment;
                }
            }
            pagedList.PageIndex = baseSearch.PageIndex;
            pagedList.PageSize = baseSearch.PageSize;
            return pagedList;
        }

        public override async Task<TransportationOrder> GetByIdAsync(int id)
        {
            var transportationOrder = await Queryable.Where(e => e.Id == id && !e.Deleted).AsNoTracking().FirstOrDefaultAsync();
            if (transportationOrder == null)
                return null;
            var smallPackages = await unitOfWork.Repository<SmallPackage>().GetQueryable().Where(x => !x.Deleted && x.TransportationOrderId == transportationOrder.Id).OrderByDescending(o => o.Id).ToListAsync();
            if (smallPackages.Any())
                transportationOrder.SmallPackages = smallPackages;

            //Lấy cân tính tiền
            var smallPackage = smallPackages.Where(e => e.TransportationOrderId == transportationOrder.Id).FirstOrDefault();
            transportationOrder.PayableWeight = (smallPackage != null && smallPackage.PayableWeight != null) ? smallPackage.PayableWeight : 0;
            transportationOrder.VolumePayment = (smallPackage != null && smallPackage.VolumePayment != null) ? smallPackage.VolumePayment : 0;

            var user = await unitOfWork.Repository<Users>().GetQueryable().Where(e => !e.Deleted && e.Id == transportationOrder.UID).FirstOrDefaultAsync();
            if (user != null)
                transportationOrder.UserName = user.UserName;

            var warehouseFrom = await unitOfWork.CatalogueRepository<WarehouseFrom>().GetQueryable().Where(e => !e.Deleted && e.Id == transportationOrder.WareHouseFromId).FirstOrDefaultAsync();
            if (warehouseFrom != null)
                transportationOrder.WareHouseFrom = warehouseFrom.Name;

            var warehouseTo = await unitOfWork.CatalogueRepository<Warehouse>().GetQueryable().Where(e => !e.Deleted && e.Id == transportationOrder.WareHouseId).FirstOrDefaultAsync();
            if (warehouseTo != null)
                transportationOrder.WareHouseTo = warehouseTo.Name;

            var shippingType = await unitOfWork.CatalogueRepository<ShippingTypeToWareHouse>().GetQueryable().Where(e => !e.Deleted && e.Id == transportationOrder.ShippingTypeId).FirstOrDefaultAsync();
            if (shippingType != null)
                transportationOrder.ShippingTypeName = shippingType.Name;

            var shippingTypeVN = await unitOfWork.CatalogueRepository<ShippingTypeVN>().GetQueryable().Where(e => !e.Deleted && e.Id == transportationOrder.ShippingTypeVN).FirstOrDefaultAsync();
            if (shippingTypeVN != null)
                transportationOrder.ShippingTypeVNName = shippingTypeVN.Name;

            return transportationOrder;
        }

        public override async Task<bool> UpdateAsync(TransportationOrder item)
        {
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    if (item.Status == (int)StatusGeneralTransportationOrder.DaDuyet)
                    {
                        var smallPackage = unitOfWork.Repository<SmallPackage>().GetQueryable().Where(x => x.OrderTransactionCode.Equals(item.OrderTransactionCode)).FirstOrDefault();
                        if (smallPackage == null)
                        {
                            smallPackage = new SmallPackage();
                            smallPackage.UID = item.UID;
                            smallPackage.TransportationOrderId = item.Id;
                            smallPackage.OrderTransactionCode = item.OrderTransactionCode;
                            smallPackage.ProductType = item.Category;
                            smallPackage.BigPackageId = 0;
                            smallPackage.FeeShip = smallPackage.Weight = 0;
                            smallPackage.Status = (int)StatusSmallPackage.MoiDat;
                            smallPackage.Deleted = false;
                            smallPackage.Active = true;
                            smallPackage.Created = item.Created;
                            smallPackage.CreatedBy = item.CreatedBy;
                            smallPackage.IsInsurance = item.IsInsurance;
                            smallPackage.IsCheckProduct = item.IsCheckProduct;
                            smallPackage.IsPackged = item.IsPacked;
                            smallPackage.TotalOrderQuantity = (int)item.Amount;
                            await unitOfWork.Repository<SmallPackage>().CreateAsync(smallPackage);
                            await unitOfWork.SaveAsync();

                            item.SmallPackageId = smallPackage.Id;

                            unitOfWork.Repository<TransportationOrder>().Update(item);
                        }
                        else
                        {
                            if (item.SmallPackages.Count > 0)
                            {
                                unitOfWork.Repository<TransportationOrder>().Update(item);
                                foreach (var sm in item.SmallPackages)
                                {
                                    sm.DonGia = item.FeeWeightPerKg;
                                    sm.PriceVolume = item.FeePerVolume;
                                    sm.OrderTransactionCode = sm.OrderTransactionCode.Replace(" ", "");
                                    unitOfWork.Repository<SmallPackage>().Update(sm);
                                }
                            }
                            else
                            {
                                throw new AppException("Mã vận đơn đã tồn tại ở đơn ký gửi khác");
                            }
                        }
                        await unitOfWork.SaveAsync();
                    }
                    else
                    {
                        unitOfWork.Repository<TransportationOrder>().Update(item);
                        foreach (var smallPackage in item.SmallPackages)
                        {
                            smallPackage.DonGia = item.FeeWeightPerKg;
                            smallPackage.PriceVolume = item.FeePerVolume;
                            smallPackage.OrderTransactionCode = smallPackage.OrderTransactionCode.Replace(" ", "");
                            unitOfWork.Repository<SmallPackage>().Update(smallPackage);
                        }
                    }
                    //Tính tiền hoa hồng
                    var staffInCome = await unitOfWork.Repository<StaffIncome>()
                                            .GetQueryable()
                                            .FirstOrDefaultAsync(x => x.TransportationOrderId == item.Id && x.Deleted == false);
                    if (staffInCome == null)
                    {
                        //Nếu chưa có thì tạo mới
                        var staffInComeNew = await CommissionTransportationOrder(item, staffInCome);
                        if(staffInComeNew != null)
                            await unitOfWork.Repository<StaffIncome>().CreateAsync(staffInComeNew);
                    }
                    if (staffInCome != null && staffInCome.UID == item.SalerID)
                    {
                        //Nếu saler trùng thì cập nhật lại
                        var staffInComeNew = await CommissionTransportationOrder(item, staffInCome);
                        if (staffInComeNew != null) 
                            unitOfWork.Repository<StaffIncome>().Update(staffInComeNew);
                    }
                    else if (staffInCome != null && staffInCome.UID != item.SalerID)
                    {
                        //Nếu đổi saler thì tạo mới
                        var staffInComeNew = await CommissionTransportationOrder(item, staffInCome);
                        if (staffInComeNew != null)
                            await unitOfWork.Repository<StaffIncome>().CreateAsync(staffInComeNew);
                    }
                    await unitOfWork.SaveAsync();
                    await dbContextTransaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }
        public override async Task<bool> CreateAsync(IList<TransportationOrder> items)
        {
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in items)
                    {
                        await unitOfWork.Repository<TransportationOrder>().CreateAsync(item);
                        await unitOfWork.SaveAsync();
                        //Tính hoa hồng
                        var staffInCome = await CommissionTransportationOrder(item, null);
                        if (staffInCome != null)
                            await unitOfWork.Repository<StaffIncome>().CreateAsync(staffInCome);

                        //Thông báo có đơn đặt hàng mới
                        var notiTemplate = await notificationTemplateService.GetByIdAsync(9);
                        var notificationSetting = await notificationSettingService.GetByIdAsync(5);
                        var emailTemplate = await sMSEmailTemplateService.GetByCodeAsync("ADHM");
                        string subject = emailTemplate.Subject;
                        string emailContent = string.Format(emailTemplate.Body); //Thông báo Email
                        await sendNotificationService.SendNotification(notificationSetting, notiTemplate, item.Id.ToString(), String.Format(Detail_Transportorder_Admin, item.Id), "", item.Id, subject, emailContent);
                    }
                    await unitOfWork.SaveAsync();
                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
            return true;
        }

        public async Task<TransportationOrderBilling> GetBillingInfo(List<int> listID, bool isUpdated)
        {
            TransportationOrderBilling model = new TransportationOrderBilling();
            DateTime currentDate = DateTime.Now;
            string userName = LoginContext.Instance.CurrentUser.UserName;
            var users = await userService.GetSingleAsync(x => x.UserName == userName);
            decimal wallet = users.Wallet ?? 0;

            decimal current = 0;
            decimal feeOutStockCNY = 0;
            decimal feeOutStockVND = 0;
            var config = await configurationsService.GetSingleAsync();
            if (config != null)
            {
                current = config.AgentCurrency ?? 0;
                feeOutStockCNY = config.PriceCheckOutWareDefault ?? 0;
                feeOutStockVND = current * feeOutStockCNY;
            }

            var listTrans = await base.GetAsync(x => !x.Deleted && x.Active
                && listID.Contains(x.Id)
            );
            if (!listTrans.Any())
                throw new KeyNotFoundException(string.Format("Không tồn tại dữ liệu. Vui lòng kiểm tra lại"));

            var checkStatus = listTrans.Where(x => x.Status == (int?)StatusGeneralTransportationOrder.VeKhoVN).Count();
            if (listTrans.Count() != checkStatus) //Nếu số lượng khác nhau
                throw new AppException(string.Format("Có đơn bị sai trạng thái thanh toán, vui lòng kiểm tra lại"));

            decimal totalAdditionFeeCNY = 0;
            decimal totalAdditionFeeVND = 0;

            decimal totalSensoredFeeVND = 0;
            decimal totalSensoredFeeCNY = 0;

            var checkWarehouseList = new List<CheckWarehouse>();
            var checkWarehouse = new CheckWarehouse();
            foreach (var item in listTrans)
            {
                checkWarehouse = checkWarehouseList.Where(x => x.WareHouseId == item.WareHouseId
                    && x.WareHouseFromId == item.WareHouseFromId
                    && x.ShippingTypeId == item.ShippingTypeId).FirstOrDefault();
                if (checkWarehouse != null)
                {
                    if (item.SmallPackageId == null && item.SmallPackageId <= 0)
                        continue;

                    var package = unitOfWork.Repository<SmallPackage>().GetQueryable().Where(x => x.Id == item.SmallPackageId).FirstOrDefault();
                    if (package == null && (package.Weight == null && package.Weight <= 0))
                        continue;

                    decimal weight = package.Weight ?? 0;

                    checkWarehouse.TotalWeight += weight;
                    checkWarehouse.Packages.Add(new Package
                    {
                        Weight = weight,
                        TransportationId = item.Id
                    });
                }
                else
                {
                    checkWarehouse = new CheckWarehouse();
                    checkWarehouse.WareHouseFromId = item.WareHouseFromId ?? 0;
                    checkWarehouse.WareHouseId = item.WareHouseId ?? 0;
                    checkWarehouse.ShippingTypeId = item.ShippingTypeId ?? 0;

                    if (item.SmallPackageId == null && item.SmallPackageId <= 0)
                        continue;

                    var package = unitOfWork.Repository<SmallPackage>().GetQueryable().Where(x => x.Id == item.SmallPackageId).FirstOrDefault();
                    if (package == null && (package.Weight == null && package.Weight <= 0))
                        continue;

                    decimal weight = package.Weight ?? 0;

                    checkWarehouse.TotalWeight += weight;
                    checkWarehouse.Packages.Add(new Package
                    {
                        Weight = weight,
                        TransportationId = item.Id
                    });

                    totalAdditionFeeCNY += package.AdditionFeeCNY ?? 0;
                    totalAdditionFeeVND += package.AdditionFeeVND ?? 0;

                    totalSensoredFeeVND += package.SensorFeeVND ?? 0;
                    totalSensoredFeeCNY += package.SensorFeeCNY ?? 0;

                    checkWarehouseList.Add(checkWarehouse);
                }
            }

            decimal totalWeightPriceVND = 0;
            decimal totalWeightPriceCNY = 0;
            if (!string.IsNullOrEmpty(users.FeeTQVNPerWeight.ToString()) && users.FeeTQVNPerWeight > 0)
            {
                totalWeightPriceVND = users.FeeTQVNPerWeight ?? 0 * checkWarehouse.TotalWeight;
                if (isUpdated) //Nếu bằng true thì add vào để xuống thanh toán insert
                {
                    foreach (var item in listTrans)
                    {
                        var package = unitOfWork.Repository<SmallPackage>().GetQueryable().Where(x => x.Id == item.SmallPackageId).FirstOrDefault();
                        if (package == null && (package.Weight == null && package.Weight <= 0))
                            continue;

                        model.ModelUpdatePayments.Add(new ModelUpdatePayment
                        {
                            Id = item.Id,
                            Price = package.PayableWeight * users.FeeTQVNPerWeight,
                            Weight = users.FeeTQVNPerWeight
                        });
                    }
                }
            }
            else
            {
                foreach (var item in checkWarehouseList)
                {
                    var fee = await warehouseFeeService.GetAsync(c => !c.Deleted && c.Active
                        && (c.WarehouseFromId == item.WareHouseFromId
                            && c.WarehouseId == item.WareHouseId
                            && c.ShippingTypeToWareHouseId == item.ShippingTypeId
                            && c.IsHelpMoving == true)
                    );

                    if (!fee.Any())
                        continue;

                    var f = fee.Where(f => item.TotalWeight >= f.WeightFrom && item.TotalWeight <= f.WeightTo).FirstOrDefault();
                    if (f == null)
                        continue;

                    totalWeightPriceVND += f.Price * item.TotalWeight ?? 0;

                    if (isUpdated && item.Packages != null) //Nếu có điều kiện này thì đưa data xuống lát update nè
                    {
                        foreach (var jtem in item.Packages)
                        {
                            model.ModelUpdatePayments.Add(new ModelUpdatePayment
                            {
                                Id = jtem.TransportationId,
                                Price = jtem.Weight * f.Price,
                                Weight = f.Price
                            });
                        }
                    }
                }
            }

            decimal totalPriceVND = totalWeightPriceVND + feeOutStockVND + totalSensoredFeeVND + totalAdditionFeeVND;
            decimal totalPriceCNY = totalWeightPriceCNY + feeOutStockCNY + totalSensoredFeeCNY + totalSensoredFeeCNY;

            if (wallet >= totalPriceVND)
                model.LeftMoney = 0; //Đủ tiền
            else
                model.LeftMoney = totalPriceVND - wallet; //Không đủ tiền

            model.TotalQuantity = listTrans.Count;
            model.TotalWeight = checkWarehouseList.Sum(x => x.TotalWeight);

            model.TotalWeightPriceCNY = totalWeightPriceCNY;
            model.TotalWeightPriceVND = totalWeightPriceVND;

            model.FeeOutStockCNY = feeOutStockCNY;
            model.FeeOutStockVND = feeOutStockVND;

            model.TotalPriceCNY = totalPriceCNY;
            model.TotalPriceVND = totalPriceVND;

            model.ListId = listID;

            model.TotalAdditionFeeCNY = totalAdditionFeeCNY;
            model.TotalAdditionFeeVND = totalAdditionFeeVND;

            model.TotalSensoredFeeCNY = totalSensoredFeeCNY;
            model.TotalSensoredFeeVND = totalSensoredFeeVND;

            return model;
        }

        public async Task<bool> UpdateAsync(IList<TransportationOrder> item, int status, int typePayment)
        {
            DateTime currentDate = DateTime.Now;
            string userName = LoginContext.Instance.CurrentUser.UserName;
            var users = await userService.GetSingleAsync(x => x.UserName == userName);
            switch (status)
            {
                case (int)StatusGeneralTransportationOrder.Huy: //Hủy thì ngoài controller đã làm hết rồi, vào đây chỉ cập nhật thôi
                    foreach (var tran in item)
                    {

                    }
                    await base.UpdateAsync(item);
                    break;
                case (int)StatusGeneralTransportationOrder.DaThanhToan: //Thanh toán thì ngoài controller đã làm hết rồi, vào đây chỉ cập nhật thôi

                    //Giống với Xuất kho chưa yêu cầu(ExportRequestTurn/Create)
                    var info = await GetBillingInfo(item.Select(x => x.Id).ToList(), true); //Lấy data tính từ trước
                    if (!info.ModelUpdatePayments.Any())
                        throw new KeyNotFoundException("Không tìm thấy dữ liệu, vui lòng kiểm tra lại");

                    using (var dbContextTransaction = Context.Database.BeginTransaction())
                    {
                        try
                        {
                            int? shippingTypeID = item.Select(x => x.ShippingTypeVN).FirstOrDefault();
                            string note = item.Select(x => x.ExportRequestNote).FirstOrDefault();

                            ExportRequestTurn exReq = new ExportRequestTurn
                            {
                                UID = users.Id,
                                TotalPriceVND = info.TotalPriceVND,
                                TotalPriceCNY = info.TotalPriceCNY,
                                TotalWeight = info.TotalWeight,
                                Note = note,
                                ShippingTypeInVNId = shippingTypeID,
                                TotalPackage = item.Count,

                                //Thanh toán bằng ví: Type = 2, Status = 2
                                //Thanh toán tại kho: Type = 0, Status 1
                                Status = typePayment == 2 ? 2 : 1,
                                Type = typePayment, //0: Chưa thanh toán, 1: Thanh toán bằng ví, 2: Thanh toán trực tiếp (ở đây là 2 0)

                                OutStockDate = currentDate //Ngày xuất kho
                            };

                            await unitOfWork.Repository<ExportRequestTurn>().CreateAsync(exReq);
                            await unitOfWork.SaveAsync(); //Để lấy ID

                            foreach (var jtem in item)
                            {
                                var package = unitOfWork.Repository<SmallPackage>().GetQueryable().Where(x => x.Id == jtem.SmallPackageId).FirstOrDefault();
                                if (package == null && package.Status != 3) //Cái này chưa hiểu
                                    continue;
                                var check = await requestOutStockService.GetSingleAsync(x => x.SmallPackageId == package.Id);
                                if (check != null) //Có tồn tại rồi thì thôi
                                    continue;

                                package.DateOutWarehouse = currentDate;

                                await unitOfWork.Repository<RequestOutStock>().CreateAsync(new RequestOutStock
                                {
                                    SmallPackageId = package.Id,
                                    Status = 1,
                                    ExportRequestTurnId = exReq.Id,
                                    Deleted = false,
                                    Active = true,
                                    Created = currentDate,
                                    CreatedBy = users.UserName
                                });

                                jtem.TotalPriceVND = info.TotalPriceVND;
                                unitOfWork.Repository<TransportationOrder>().Update(jtem);

                                unitOfWork.Repository<SmallPackage>().Update(package);

                                await unitOfWork.SaveAsync();
                                await dbContextTransaction.CommitAsync();
                            }

                            //Trừ tiền trong ví (chỉ thanh toán bằng ví thì mới cần cái này)
                            if (typePayment == 2) //Thanh toán bằng ví
                            {
                                users.Wallet -= info.TotalPriceVND;
                                users.Updated = currentDate;
                                users.UpdatedBy = users.UserName;
                                unitOfWork.Repository<Users>().Update(users);

                                //Lịch sử của ví
                                await unitOfWork.Repository<HistoryPayWallet>().CreateAsync(new HistoryPayWallet
                                {
                                    UID = users.Id,
                                    MainOrderId = 0,
                                    Amount = info.TotalPriceVND,
                                    Content = string.Format("{0} đã thanh toán đơn hàng vận chuyển hộ.", users.UserName),
                                    MoneyLeft = users.Wallet,
                                    Type = (int?)DauCongVaTru.Tru,
                                    TradeType = (int?)HistoryPayWalletContents.ThanhToanVanChuyenHo,
                                    Deleted = false,
                                    Active = true,
                                    Created = currentDate,
                                    CreatedBy = users.UserName
                                });
                            }


                        }
                        catch (Exception ex)
                        {
                            await dbContextTransaction.RollbackAsync();
                            throw new Exception(ex.Message);
                        }
                    }
                    break;
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// Tính lại tiền khi thay đổi SmallPackage
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<TransportationOrder> PriceAdjustment(TransportationOrder item)
        {
            var config = await unitOfWork.Repository<NhapHangV2.Entities.Configurations>().GetQueryable().FirstOrDefaultAsync();
            var smallPackages = item.SmallPackages;
            var user = await unitOfWork.Repository<Users>().GetQueryable().Where(e => !e.Deleted && e.Id == item.UID).FirstOrDefaultAsync();
            var userLevel = await unitOfWork.Repository<UserLevel>().GetQueryable().Where(e => !e.Deleted && e.Id == user.LevelId).FirstOrDefaultAsync();
            decimal? ckFeeWeight = userLevel == null ? 1 : userLevel.FeeWeight;
            item.FeeWeightCK = ckFeeWeight;

            //Tiền cân nặng
            decimal? totalWeight = smallPackages.Sum(e => e.PayableWeight);
            var warehouseFee = await unitOfWork.Repository<WarehouseFee>().GetQueryable().Where(e => !e.Deleted
                && e.WarehouseFromId == item.WareHouseFromId
                && e.WarehouseId == item.WareHouseId
                && e.ShippingTypeToWareHouseId == item.ShippingTypeId
                && e.IsHelpMoving == true
                && totalWeight >= e.WeightFrom && totalWeight < e.WeightTo).FirstOrDefaultAsync();
            if (warehouseFee == null)
                throw new KeyNotFoundException("Không tìm thấy bảng giá cân nặng");
            decimal? warehouseFeePrice = warehouseFee == null ? 0 : warehouseFee.Price;
            if (user.FeeTQVNPerWeight > 0)
            {
                warehouseFeePrice = user.FeeTQVNPerWeight;
            }
            decimal? feeWeight = 0;
            feeWeight = totalWeight * warehouseFeePrice;

            //Tiền khối
            decimal? totalVolume = smallPackages.Sum(e => e.VolumePayment);
            var volumeFee = await unitOfWork.Repository<VolumeFee>().GetQueryable().FirstOrDefaultAsync(e => !e.Deleted
                && e.WarehouseFromId == item.WareHouseFromId
                && e.WarehouseId == item.WareHouseId
                && e.ShippingTypeToWareHouseId == item.ShippingTypeId
                && e.IsHelpMoving == true
                && (totalVolume >= e.VolumeFrom && totalVolume < e.VolumeTo));
            if (volumeFee == null)
                throw new KeyNotFoundException("Không tìm thấy bảng giá khối");
            decimal? volumeFeePrice = volumeFee == null ? 0 : volumeFee.Price;
            if (user.FeeTQVNPerVolume > 0)
            {
                volumeFeePrice = user.FeeTQVNPerVolume;
            }
            decimal? feeVolume = 0;
            feeVolume = totalVolume * volumeFeePrice;

            smallPackages.ForEach(e =>
            {
                e.PriceWeight = warehouseFeePrice;
                e.DonGia = warehouseFeePrice;
                e.PriceVolume = volumeFeePrice;
                e.TotalPrice = feeVolume > feeWeight ? feeVolume : feeWeight;
            });

            decimal? deliveryPrice = feeVolume > feeWeight ? feeVolume : feeWeight;
            decimal? feeDeliveryDiscount = deliveryPrice * ckFeeWeight / 100;
            deliveryPrice -= feeDeliveryDiscount;

            if (item.DeliveryPrice != (deliveryPrice ?? 0))
            {
                item.TotalPriceVND = item.TotalPriceVND - item.DeliveryPrice + (deliveryPrice ?? 0);
            }
            else
            {
                item.TotalPriceVND = (deliveryPrice ?? 0) + (item.CODFee ?? 0) + (item.IsCheckProductPrice ?? 0) + (item.IsPackedPrice ?? 0) + (item.InsuranceMoney ?? 0);
            }
            if (user.Currency != null && user.Currency > 0)
                item.TotalPriceCNY = item.TotalPriceVND / user.Currency;
            else
                item.TotalPriceCNY = item.TotalPriceVND / config.AgentCurrency;
            item.FeeWeightPerKg = warehouseFeePrice;
            item.FeePerVolume = volumeFeePrice;
            item.DeliveryPrice = deliveryPrice ?? 0;
            return item;
        }

        public async Task<bool> UpdateTransportationOrder(List<int> listId, int userId)
        {
            DateTime currentDate = DateTime.Now;
            decimal totalMustPay = 0;
            string userName = LoginContext.Instance.CurrentUser.UserName;
            var users = await unitOfWork.Repository<Users>().GetQueryable().Where(x => x.UserName == userName).FirstOrDefaultAsync();
            decimal wallet = users.Wallet ?? 0;

            if (!listId.Any())
                throw new KeyNotFoundException("Mã đơn ký gửi không tồn tại");
            var transportOrders = await this.GetAsync(x => !x.Deleted && x.Active && (listId.Contains(x.Id)));
            int checkStatus = 0;

            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    checkStatus = transportOrders.Where(x => x.Status == (int?)StatusGeneralTransportationOrder.VeKhoVN).Count();
                    if (transportOrders.Count() != checkStatus)
                        throw new AppException("Đơn ký gửi chưa thể thanh toán");
                    totalMustPay = transportOrders.Sum(x => x.TotalPriceVND + x.WarehouseFee) ?? 0;
                    if (wallet < totalMustPay)
                        throw new AppException("Số dư trong tài khoản không đủ. Vui lòng nạp thêm tiền");

                    foreach (var item in transportOrders)
                    {
                        decimal feeWarehouse = item.WarehouseFee ?? 0;
                        decimal totalPriceVND = item.TotalPriceVND ?? 0;
                        decimal moneyLeft = totalPriceVND + feeWarehouse;

                        users.Wallet -= moneyLeft;

                        users.Updated = currentDate;
                        users.UpdatedBy = userName;
                        //Tính tiền tích lũy
                        users = await userService.CreateUserTransactionMoney(users, moneyLeft);
                        unitOfWork.Repository<Users>().Update(users);

                        item.Status = (int?)StatusGeneralTransportationOrder.DaThanhToan;
                        item.DateExport = currentDate;
                        item.Updated = currentDate;
                        item.UpdatedBy = userName;

                        unitOfWork.Repository<TransportationOrder>().Update(item);

                        //Thêm lịch sử của ví tiền
                        await unitOfWork.Repository<HistoryPayWallet>().CreateAsync(new HistoryPayWallet()
                        {
                            UID = users.Id,
                            MainOrderId = item.Id,
                            Amount = moneyLeft,
                            Content = string.Format("{0} đã thanh toán đơn ký gửi: {1}.", users.UserName, item.Id),
                            MoneyLeft = wallet - moneyLeft,
                            Type = (int?)DauCongVaTru.Tru,
                            TradeType = (int?)HistoryPayWalletContents.ThanhToanHoaDon,
                            Deleted = false,
                            Active = true,
                            CreatedBy = users.UserName,
                            Created = currentDate
                        });

                        //Thông báo đơn hàng được thanh toán
                        var notificationSettingTT = await notificationSettingService.GetByIdAsync(11);
                        var notiTemplate = await notificationTemplateService.GetByIdAsync(15);
                        notiTemplate.Content = "Đơn ký gửi {0} đã được thanh toán";
                        var emailTemplate = await sMSEmailTemplateService.GetByCodeAsync("ADHDTT");
                        string subject = emailTemplate.Subject;
                        string emailContent = string.Format(emailTemplate.Body); //Thông báo Email
                        await sendNotificationService.SendNotification(notificationSettingTT, notiTemplate, item.Id.ToString(), String.Format(Detail_Transportorder_Admin, item.Id), "", null, subject, emailContent);
                    }

                    await unitOfWork.SaveAsync();
                    await dbContextTransaction.CommitAsync();
                }
                catch (AppException ex)
                {
                    await dbContextTransaction.RollbackAsync();
                    throw new AppException(ex.Message);
                }
                return true;
            }
        }

        public async Task<AmountStatistic> GetTotalOrderPriceByUID(int UID)
        {
            var transportationOrders = await unitOfWork.Repository<TransportationOrder>().GetQueryable().Where(x => x.UID == UID && !x.Deleted).ToListAsync();
            return new AmountStatistic
            {
                TotalOrderPrice = transportationOrders.Sum(x => x.TotalPriceVND) ?? 0,
            };
        }

        public List<TransportationsInfor> GetTransportationsInfor(TransportationOrderSearch transportationOrderSearch)
        {
            var storeService = serviceProvider.GetRequiredService<IStoreSqlService<TransportationsInfor>>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@UID", transportationOrderSearch.UID));
            sqlParameters.Add(new SqlParameter("@RoleID", transportationOrderSearch.RoleID));
            SqlParameter[] parameters = sqlParameters.ToArray();
            var data = storeService.GetDataFromStore(parameters, "GetTransportationsInfor");

            var all = data.Sum(x => x.Quantity);
            data.Add(new() { Status = -1, Quantity = all });
            if (data.Count != Enum.GetNames(typeof(StatusGeneralTransportationOrder)).Length)
            {
                int j = 0;
                foreach (var item in Enum.GetValues(typeof(StatusGeneralTransportationOrder)))
                {
                    if (data[j].Status != (int)item)
                        data.Add(new() { Status = (int)item, Quantity = 0 });
                    else
                        j++;
                }
            }
            return data;
        }

        public async Task<bool> UpdateStaffAsync(int transportationOrderID, int salerID)
        {
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    var transportationOrder = await unitOfWork.Repository<TransportationOrder>()
                        .GetQueryable()
                        .FirstOrDefaultAsync(x => x.Id == transportationOrderID && !x.Deleted);
                    if (transportationOrder == null)
                        throw new KeyNotFoundException($"Không tìm thấy đơn ký gửi #{transportationOrderID}");
                    if (transportationOrder.SalerID != salerID)
                    {
                        transportationOrder.SalerID = salerID;
                        await unitOfWork.Repository<TransportationOrder>().UpdateFieldsSaveAsync(transportationOrder, new Expression<Func<TransportationOrder, object>>[]
                        {
                            x=>x.SalerID
                        });
                        var staffInCome = await unitOfWork.Repository<StaffIncome>()
                        .GetQueryable()
                        .FirstOrDefaultAsync(x => x.TransportationOrderId == transportationOrderID && !x.Deleted);

                        //Nếu đổi saler thì tạo mới
                        var staffInComeNew = await CommissionTransportationOrder(transportationOrder, staffInCome);
                        await unitOfWork.Repository<StaffIncome>().CreateAsync(staffInComeNew);
                        await unitOfWork.SaveAsync();
                        dbContextTransaction.Commit();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                    throw new AppException(ex.Message);
                }
            }

        }
        public TransportationsAmount GetTransportationsAmount(int UID)
        {
            var storeService = serviceProvider.GetRequiredService<IStoreSqlService<TransportationsAmount>>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@UID", UID));
            SqlParameter[] parameters = sqlParameters.ToArray();
            var data = storeService.GetDataFromStore(parameters, "GetTransportationsAmount");
            return data.FirstOrDefault();
        }

        public class CheckWarehouse
        {
            public int WareHouseFromId { get; set; }
            public int WareHouseId { get; set; }
            public int ShippingTypeId { get; set; }
            public decimal TotalWeight { get; set; }
            public List<Package> Packages { get; set; } = new List<Package>();
        }

        public class Package
        {
            public int TransportationId { get; set; }
            public decimal Weight { get; set; }
        }

        public async Task<StaffIncome> CommissionTransportationOrder(TransportationOrder transportationOrder, StaffIncome staffIncome)
        {
            var configuration = await configurationsService.GetSingleAsync();
            if (configuration == null)
                throw new KeyNotFoundException("Không tìm thấy cấu hình hệ thống");
            //Không có SalerId
            if (transportationOrder.SalerID == null || transportationOrder.SalerID < 1)
                return null;
            //Tạo các biến để tính hoa hồng
            decimal orderTotalPrice = transportationOrder.TotalPriceVND ?? 0;
            int percentRecevie = configuration.SaleTranportationPersent ?? 0;
            decimal totalPriceRecieve = 0;
            if (transportationOrder.DeliveryPrice > 0 && percentRecevie > 0)
            {
                totalPriceRecieve = (transportationOrder.DeliveryPrice ?? 0) * percentRecevie / 100;
            }
            if (staffIncome == null)
                return new StaffIncome()
                {
                    TransportationOrderId = transportationOrder.Id,
                    OrderTotalPrice = orderTotalPrice,
                    PercentReceive = percentRecevie,
                    UID = transportationOrder.SalerID,
                    TotalPriceReceive = totalPriceRecieve
                };

            if (transportationOrder.SalerID == staffIncome.UID)
            {
                staffIncome.OrderTotalPrice = orderTotalPrice;
                staffIncome.TotalPriceReceive = totalPriceRecieve;
                return staffIncome;
            }
            staffIncome.Deleted = true;
            unitOfWork.Repository<StaffIncome>().Update(staffIncome);
            await unitOfWork.SaveAsync();

            return new StaffIncome()
            {
                TransportationOrderId = transportationOrder.Id,
                OrderTotalPrice = orderTotalPrice,
                PercentReceive = percentRecevie,
                UID = transportationOrder.SalerID,
                TotalPriceReceive = totalPriceRecieve
            };
        }
    }
}
