using AutoMapper;
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
using NhapHangV2.Service.Services.Configurations;
using NhapHangV2.Service.Services.DomainServices;
using NhapHangV2.Utilities;
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
    public class ComplainService : DomainService<Complain, ComplainSearch>, IComplainService
    {
        protected readonly IAppDbContext Context;
        protected readonly IUserService userService;
        protected readonly IMainOrderService mainOrderService;
        private readonly INotificationSettingService notificationSettingService;
        private readonly INotificationTemplateService notificationTemplateService;
        private readonly ISendNotificationService sendNotificationService;
        private readonly ISMSEmailTemplateService sMSEmailTemplateService;


        public ComplainService(IServiceProvider serviceProvider, IAppUnitOfWork unitOfWork, IMapper mapper, IAppDbContext Context) : base(unitOfWork, mapper)
        {
            this.Context = Context;
            userService = serviceProvider.GetRequiredService<IUserService>();
            mainOrderService = serviceProvider.GetRequiredService<IMainOrderService>();
            notificationSettingService = serviceProvider.GetRequiredService<INotificationSettingService>();
            notificationTemplateService = serviceProvider.GetRequiredService<INotificationTemplateService>();
            sendNotificationService = serviceProvider.GetRequiredService<ISendNotificationService>();
            sMSEmailTemplateService = serviceProvider.GetRequiredService<ISMSEmailTemplateService>();

        }

        public override async Task<Complain> GetByIdAsync(int id)
        {
            var complain = await Queryable.Where(e => e.Id == id && !e.Deleted).AsNoTracking().FirstOrDefaultAsync();
            if (complain == null)
                return null;
            var user = await unitOfWork.Repository<Users>().GetQueryable().Where(x => x.Id == complain.UID).FirstOrDefaultAsync();
            if (user != null)
                complain.UserName = user.UserName;

            var mainOrder = await unitOfWork.Repository<MainOrder>().GetQueryable().Where(x => x.Id == complain.MainOrderId).FirstOrDefaultAsync();
            if (mainOrder != null)
                complain.CurrentCNYVN = mainOrder.CurrentCNYVN;
            return complain;
        }

        protected override string GetStoreProcName()
        {
            return "Complain_GetPagingData";
        }

        public async Task<bool> UpdateStatus(int id, decimal amount, int status)
        {
            DateTime currentDate = DateTime.Now;
            string userName = LoginContext.Instance.CurrentUser.UserName;

            var item = await this.GetByIdAsync(id);
            if (item == null)
                throw new KeyNotFoundException("Item không tồn tại");
            var users = await userService.GetByIdAsync(item.UID ?? 0);

            item.Updated = currentDate;
            item.UpdatedBy = userName;
            item.Status = status;
            item.Amount = amount;

            int notiTemplateId = 0;
            string emailTemplateCode = "";
            switch (status)
            {
                case (int)StatusComplain.DaHuy:
                    //Thông báo
                    notiTemplateId = 4;
                    emailTemplateCode = "UHKN";
                    break;
                case (int)StatusComplain.ChuaDuyet:
                    break;
                case (int)StatusComplain.DangXuLy:
                    break;
                case (int)StatusComplain.DaXuLy:
                    decimal? wallet = users.Wallet + amount;

                    //Cập nhật cho account
                    users.Wallet = wallet;
                    users.Updated = currentDate;
                    users.UpdatedBy = users.UserName;
                    unitOfWork.Repository<Users>().Update(users);

                    //Lịch sử ví tiền
                    await unitOfWork.Repository<HistoryPayWallet>().CreateAsync(new HistoryPayWallet
                    {
                        UID = users.Id,
                        MainOrderId = item.MainOrderId,
                        MoneyLeft = wallet,
                        Amount = amount,
                        Type = (int)DauCongVaTru.Cong,
                        TradeType = (int)HistoryPayWalletContents.HoanTienKhieuNai,
                        Content = string.Format("{0} đã được hoàn tiền khiếu nại của đơn hàng: {1} vào tài khoản.", userName, item.MainOrderId),
                        Deleted = false,
                        Active = true,
                        Created = currentDate,
                        CreatedBy = userName
                    });

                    //Thông báo
                    notiTemplateId = 3;
                    emailTemplateCode = "UDKN";
                    break;
                default:
                    break;
            }

            unitOfWork.Repository<Complain>().UpdateFieldsSave(item, new Expression<Func<Complain, object>>[]
            {
                e => e.Updated,
                e => e.UpdatedBy,
                e => e.Status,
                e => e.Amount
            });

            var mainOrder = await mainOrderService.GetByIdAsync(item.MainOrderId ?? 0);
            if (mainOrder == null) { }
            else
            {
                mainOrder.IsComplain = false;
                mainOrder.Status = (int)StatusOrderContants.DaHoanThanh;
                unitOfWork.Repository<MainOrder>().UpdateFieldsSave(mainOrder, new Expression<Func<MainOrder, object>>[]
                {
                    e => e.IsComplain,
                    e=>e.Status
                });
            }

            //Thông báo (Hủy và đã duyệt)

            var notificationSetting = await notificationSettingService.GetByIdAsync(10);
            var notiTemplate = await notificationTemplateService.GetByIdAsync(notiTemplateId);
            var emailTemplate = await sMSEmailTemplateService.GetByCodeAsync(emailTemplateCode);
            if (emailTemplate != null)
            {
                string subject = emailTemplate.Subject;
                string emailContent = string.Format(emailTemplate.Body);
                await sendNotificationService.SendNotification(notificationSetting, notiTemplate, item.MainOrderId.ToString(), "", string.Format(Complain_List), users.Id, subject, emailContent);
                //await sendNotificationService.SendNotification(notificationSetting, notiTemplate, item.MainOrderId.ToString(), "", "/user/report", users.Id, subject, emailContent);
            }
            await unitOfWork.SaveAsync();
            return true;
        }
    }
}
