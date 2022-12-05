using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Search;
using NhapHangV2.Extensions;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services
{
    public class OrderCommentService : DomainService<OrderComment, OrderCommentSearch>, IOrderCommentService
    {
        protected readonly IHubContext<DomainHub, IDomainHub> hubContext;
        public OrderCommentService(IAppUnitOfWork unitOfWork, IMapper mapper, IHubContext<DomainHub, IDomainHub> hubContext) : base(unitOfWork, mapper)
        {
            this.hubContext = hubContext;
        }

        protected override string GetStoreProcName()
        {
            return "OrderComment_GetPagingData";
        }

        public override async Task<bool> CreateAsync(OrderComment item)
        {
            var user = await unitOfWork.Repository<Users>().GetQueryable().Where(e => !e.Deleted && e.Id == LoginContext.Instance.CurrentUser.UserId).FirstOrDefaultAsync();
            item.UID = user.Id;

            var mainOrder = await unitOfWork.Repository<MainOrder>().GetQueryable().Where(e => !e.Deleted && e.Id == item.MainOrderId).FirstOrDefaultAsync();

            await unitOfWork.Repository<OrderComment>().CreateAsync(item);
            await unitOfWork.SaveAsync();

            item.UserName = user.UserName;

            switch (item.Type)
            {
                case 1: //Nhắn với khách hàng
                    await hubContext.Clients.All.BroadcastMessageUser(item);
                    break;
                case 2: //Nhắn tin nội bộ
                    await hubContext.Clients.All.BroadcastMessageInternal(item);
                    break;
                default:
                    break;
            }

            return true;
        }
    }
}
