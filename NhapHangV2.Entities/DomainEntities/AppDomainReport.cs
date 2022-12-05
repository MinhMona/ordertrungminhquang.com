using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.DomainEntities
{
    public class AppDomainReport
    {
        /// <summary>
        /// STT
        /// </summary>
        [NotMapped]
        public long RowNumber { get; set; }

        /// <summary>
        /// Tổng số item phân trang
        /// </summary>
        [NotMapped]
        public int TotalItem { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Tạo bởi
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Người cập nhật
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
