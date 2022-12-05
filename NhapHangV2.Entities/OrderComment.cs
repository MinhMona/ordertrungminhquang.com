
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class OrderComment : DomainEntities.AppDomain
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; } = 0;

        /// <summary>
        /// Id đơn hàng
        /// </summary>
        public int? MainOrderId { get; set; } = 0;

        /// <summary>
        /// Nội dung
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// 1. Nhắn tin với khách
        /// 2. Nhắn tin nội bộ
        /// </summary>
        public int? Type { get; set; } = 0;

        /// <summary>
        /// Lưu tập tin
        /// </summary>
        public string FileLink { get; set; } = string.Empty;

        /// <summary>
        /// UserName
        /// </summary>
        [NotMapped]
        public string UserName { get; set; } = string.Empty;
    }
}
