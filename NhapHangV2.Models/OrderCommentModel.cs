using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models
{
    public class OrderCommentModel : AppDomainModel
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// Id đơn hàng
        /// </summary>
        public int? MainOrderId { get; set; }

        /// <summary>
        /// Nội dung
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 1. Nhắn tin với khách
        /// 2. Nhắn tin nội bộ
        /// </summary>
        public int? Type { get; set; }

        public string TypeName
        {
            get
            {
                switch (Type)
                {
                    case 1:
                        return "Nhắn tin với khách";
                    case 2:
                        return "Nhắn tin nội bộ";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// Lưu tập tin
        /// </summary>
        public string FileLink { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; } = string.Empty;
    }
}
