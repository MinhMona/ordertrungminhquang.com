using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NhapHangV2.Models.DomainModels
{
    public class AppDomainModel
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
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Người cập nhật
        /// </summary>
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
