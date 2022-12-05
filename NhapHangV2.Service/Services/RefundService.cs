using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NhapHangV2.Entities;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Entities.Search;
using NhapHangV2.Extensions;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Service.Services
{
    public class RefundService : DomainService<Refund, RefundSearch>, IRefundService
    {
        protected readonly IUserService userService;
        public RefundService(IServiceProvider serviceProvider, IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            userService = serviceProvider.GetRequiredService<IUserService>();
        }

        public override async Task<Refund> GetByIdAsync(int id)
        {
            var item = await Queryable.Where(e => e.Id == id && !e.Deleted).AsNoTracking().FirstOrDefaultAsync();
            if (item == null)
                return null;
            var user = await unitOfWork.Repository<Users>().GetQueryable().Where(e => e.Id == item.UID && !e.Deleted).FirstOrDefaultAsync();
            if (user != null)
                item.UserName = user.UserName;
            return item;
        }

        protected override string GetStoreProcName()
        {
            return "Refund_GetPagingData";
        }

        public override async Task<bool> CreateAsync(Refund item)
        {
            var user = await userService.GetByIdAsync(LoginContext.Instance.CurrentUser.UserId); //User
            if (user.UserGroupId != (int)PermissionTypes.User)
                user = await userService.GetByIdAsync(item.UID ?? 0); //Admin nạp / rút dùm

            item.UID = user.Id;

            if (item.Status == (int)WalletStatus.DaDuyet)
            {
                //Cập nhật lại ví
                user.WalletCNY -= item.Amount ?? 0;
                unitOfWork.Repository<Users>().Update(user);

                //Thêm vào lịch sử ví tiền tệ
                await unitOfWork.Repository<HistoryPayWalletCNY>().CreateAsync(new HistoryPayWalletCNY
                {
                    UID = user.Id,
                    Amount = item.Amount,
                    Note = item.Note, //string.Format("{0} đã được hoàn lại tiền mua hộ vào tài khoản", user.UserName),
                    MoneyLeft = user.WalletCNY,
                    Type = (int)DauCongVaTru.Tru,
                    TradeType = (int)HistoryPayWalletCNYContents.RutTien
                });
            }

            await unitOfWork.Repository<Refund>().CreateAsync(item);
            await unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateStatus(Refund item, int status)
        {
            var user = await userService.GetByIdAsync(LoginContext.Instance.CurrentUser.UserId); //User
            if (user.UserGroupId != (int)PermissionTypes.User)
                user = await userService.GetByIdAsync(item.UID ?? 0); //Admin nạp / rút dùm

            switch (status)
            {
                case (int)WalletStatus.DangChoDuyet:
                    item.Status = (int)WalletStatus.DangChoDuyet;
                    break;
                case (int)WalletStatus.DaDuyet: //Đã duyệt

                    //Cập nhật lại ví
                    user.WalletCNY -= item.Amount ?? 0;
                    unitOfWork.Repository<Users>().Update(user);

                    //Thêm vào lịch sử ví tiền tệ
                    await unitOfWork.Repository<HistoryPayWalletCNY>().CreateAsync(new HistoryPayWalletCNY
                    {
                        UID = user.Id,
                        Amount = item.Amount,
                        Note = string.Format("{0} đã được hoàn lại tiền mua hộ (rút tiền) vào tài khoản", user.UserName),
                        MoneyLeft = user.WalletCNY,
                        Type = (int)DauCongVaTru.Tru,
                        TradeType = (int)HistoryPayWalletCNYContents.RutTien,
                    });

                    item.Status = (int)WalletStatus.DaDuyet;
                    break;

                case (int)WalletStatus.Huy: //Hủy
                    item.Status = (int)WalletStatus.Huy;
                    break;
                default:
                    break;
            }

            unitOfWork.Repository<Refund>().Update(item);
            await unitOfWork.SaveAsync();

            return true;
        }

        public override async Task<bool> UpdateAsync(Refund item)
        {
            return await UpdateStatus(item, item.Status ?? 0);
        }
    }
}
