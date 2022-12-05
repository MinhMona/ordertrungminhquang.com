using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.DomainEntities
{
    public class AppDomainFile : AppDomain
    {
        /// <summary>
        /// Tên file (Tên lưu trong thư mục)
        /// </summary>
        [StringLength(500)]
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Loại file
        /// </summary>
        [StringLength(100)]
        public string ContentType { get; set; } = string.Empty;

        /// <summary>
        /// Đuôi file
        /// </summary>
        [StringLength(50)]
        public string FileExtension { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả
        /// </summary>
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Link download File
        /// </summary>
        public string FileUrl { get; set; } = string.Empty;
    }
}
