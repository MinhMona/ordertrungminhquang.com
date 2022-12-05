using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Catalogue
{
    public class Bank : AppDomainCatalogue
    {
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        [StringLength(50)]
        public string BankName { get; set; } = string.Empty;

        /// <summary>
        /// Số tài khoản
        /// </summary>
        [StringLength(50)]
        public string BankNumber { get; set; } = string.Empty;

        /// <summary>
        /// Chi nhánh
        /// </summary>
        [StringLength(100)]
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string IMG { get; set; } = string.Empty;

        /// <summary>
        /// Thông tin
        /// </summary>
        [NotMapped]
        public string BankInfo
        {
            get
            {
                return BankName + " - " + Name + " - " + BankNumber + " - " + Branch;
            }
        }
    }
}
