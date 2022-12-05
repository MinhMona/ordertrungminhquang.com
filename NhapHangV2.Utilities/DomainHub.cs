using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Utilities
{
    public interface IDomainHub
    {
        [HubMethodName("change")]
        Task Change(object mainOrder, object transportationOrder);

        [HubMethodName("send-notification")]
        Task SendNotification(object notification);

        //[HubMethodName("get-total-notification")]
        //Task GetTotalNotification();

        /// <summary>
        /// Nhắn tin với khách hàng
        /// </summary>
        /// <param name="orderComment"></param>
        /// <returns></returns>
        [HubMethodName("broadcast-message-user")]
        Task BroadcastMessageUser(object orderComment);

        /// <summary>
        /// Nhắn tin nội bộ
        /// </summary>
        /// <param name="orderComment"></param>
        /// <returns></returns>
        [HubMethodName("broadcast-message-internal")]
        Task BroadcastMessageInternal(object orderComment);

        /// <summary>
        /// Thông báo khi có sự thay đổi tỉ giá -> Cập nhật lại Giỏ hàng
        /// </summary>
        /// <param name="isChange"></param>
        /// <returns></returns>
        [HubMethodName("change-temp")]
        Task ChangeTemp(object isChange);
    }

    public class DomainHub : Hub<IDomainHub>
    {
        /// <summary>
        /// Thêm vào nhóm
        /// </summary>
        /// <param name="id">Id người dùng</param>
        /// <param name="userGroupId">Id nhóm người dùng</param>
        /// <returns></returns>
        [HubMethodName("join")]
        public async Task Join(string id, string userGroupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, string.Format("UserId_{0}", id));
            await Groups.AddToGroupAsync(Context.ConnectionId, string.Format("UserGroup_{0}", userGroupId));
        }

        /// <summary>
        /// Rời khỏi nhóm
        /// </summary>
        /// <param name="id">Id người dùng</param>
        /// <param name="userGroupId">Id nhóm người dùng</param>
        /// <returns></returns>
        [HubMethodName("leave")]
        public async Task Leave(string id, string userGroupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, string.Format("UserId_{0}", id));
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, string.Format("UserGroup_{0}", userGroupId));
        }
    }
}
