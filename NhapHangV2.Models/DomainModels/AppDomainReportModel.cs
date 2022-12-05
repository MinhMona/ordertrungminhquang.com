using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models.DomainModels
{
    public class AppDomainReportModel
    {
        /// <summary>
        /// Số thứ tự
        /// </summary>
        public long RowNumber { get; set; } = 0;

        /// <summary>
        /// Khóa chính
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Tạo bởi
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Người cập nhật
        /// </summary>
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
