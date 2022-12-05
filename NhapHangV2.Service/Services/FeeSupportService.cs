using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NhapHangV2.Entities;
using NhapHangV2.Entities.DomainEntities;
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
    public class FeeSupportService : DomainService<FeeSupport, BaseSearch>, IFeeSupportService
    {
        public FeeSupportService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var user = await unitOfWork.Repository<Users>().GetQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == LoginContext.Instance.CurrentUser.UserId);
            var exists = Queryable
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
            if (exists != null)
            {
                exists.Deleted = true;
                unitOfWork.Repository<FeeSupport>().Update(exists);

                //Thêm lịch sử đơn hàng thay đổi
                await unitOfWork.Repository<HistoryOrderChange>().CreateAsync(new HistoryOrderChange()
                {
                    MainOrderId = exists.MainOrderId,
                    UID = user.Id,
                    HistoryContent = String.Format("{0} đã xóa tiền phụ phí của đơn hàng ID là: {1}, Tên phụ phí: {2}, Số tiền: {3}.", user.UserName, exists.MainOrderId, exists.SupportName, exists.SupportInfoVND),
                    Type = (int?)TypeHistoryOrderChange.MaDonHang
                });

                await unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                throw new Exception(id + " not exists");
            }
        }
    }
}
