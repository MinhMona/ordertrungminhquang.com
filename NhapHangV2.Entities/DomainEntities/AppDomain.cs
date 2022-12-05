using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NhapHangV2.Entities.DomainEntities
{
    public class AppDomain
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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        [NoMapCreated]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Tạo bởi
        /// </summary>
        [StringLength(50)]
        [NoMapCreated]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        [NoMapUpdated]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Người cập nhật
        /// </summary>
        [StringLength(50)]
        [NoMapUpdated]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Cờ xóa
        /// </summary>
        public bool Deleted { get; set; } = false;

        /// <summary>
        /// Cờ active
        /// </summary>
        public bool Active { get; set; } = true;

    }
}
