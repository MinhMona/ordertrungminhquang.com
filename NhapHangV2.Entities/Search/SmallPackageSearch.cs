using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Search
{
    public class SmallPackageSearch : BaseSearch
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// RoleID
        /// </summary>
        public int? RoleID { get; set; }

        /// <summary>
        /// ID Shop
        /// </summary>
        public int? MainOrderId { get; set; }

        /// <summary>
        /// ID kiện lớn
        /// </summary>
        public int? BigPackageId { get; set; }

        /// <summary>
        /// SearchContent theo loại (mặc định search theo OrderTransactionCode)
        /// 1: Theo MainOrderId
        /// 2: Theo Id
        /// 3: Theo UserName
        /// </summary>
        public int? SearchType { get; set; }

        /// <summary>
        /// Từ ngày
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Đến ngày
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Chọn menu
        /// 0: Danh sách kiện trôi nổi
        /// 1: Các kiện dựa vào kiện lớn
        /// 2: Quản lý mã vận đơn
        /// 3: Danh sách kiện thất lạc
        /// </summary>
        public int? Menu { get; set; } = 2;
    }
}
