using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request.Catalogue
{
    public class NotificationSettingRequest : AppDomainCatalogueRequest
    {
        /// <summary>
        /// Thông báo cho admin
        /// </summary>
        public bool IsNotifyAdmin { get; set; }

        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        public bool IsNotifyUser { get; set; }

        /// <summary>
        /// Gửi email cho admin
        /// </summary>
        public bool IsEmailAdmin { get; set; }

        /// <summary>
        /// Gửi email cho người dùng
        /// </summary>
        public bool IsEmailUser { get; set; }

        /// <summary>
        /// Thông báo cho kho TQ
        /// </summary>
        public bool IsNotifyWarehoueFrom { get; set; } = false;

        /// <summary>
        /// Thông báo cho kho VN
        /// </summary>
        public bool IsNotifyWarehoue { get; set; } = false;

        /// <summary>
        /// Thông báo cho đặt hàng
        /// </summary>
        public bool IsNotifyOrderer { get; set; } = false;

        /// <summary>
        /// Thông báo cho saler
        /// </summary>
        public bool IsNotifySaler { get; set; } = false;

        /// <summary>
        /// Thông báo cho thủ kho
        /// </summary>
        public bool IsNotifyStorekeepers { get; set; } = false;

        /// <summary>
        /// Thông báo cho kế toán
        /// </summary>
        public bool IsNotifyAccountant { get; set; } = false;
    }
}
