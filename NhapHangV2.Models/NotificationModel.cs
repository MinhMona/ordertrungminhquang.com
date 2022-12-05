using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models
{
    public class NotificationModel : AppDomainModel
    {
        /// <summary>
        /// Mã template thông báo
        /// </summary>
        public int? NotificationTemplateId { get; set; }

        /// <summary>
        /// Nội dung thông báo
        /// </summary>
        public string NotificationContent { get; set; }

        /// <summary>
        /// Cờ đã xem
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// Gửi đến người dùng
        /// </summary>
        public int ToUserId { get; set; }

        /// <summary>
        /// Gửi đến nhóm người dùng
        /// </summary>
        public int UserGroupId { get; set; }

        /// <summary>
        /// Link Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        public int MainOrderId { get; set; }

        /// <summary>
        /// Loại thông báo: 0-Yêu cầu nạp,1-Yêu cầu rút, 2-Đơn hàng, 3-Khiếu nại
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Là thông báo của nhân viên
        /// </summary>
        public bool? OfEmployee { get; set; }
    }
}
