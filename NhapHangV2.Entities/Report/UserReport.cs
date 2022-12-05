using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Report
{
    public class UserReport : AppDomainReport
    {
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Số dư
        /// </summary>
        [Column(TypeName = "int(18,0)")] 
        public decimal Wallet { get; set; } 

        /// <summary>
        /// Quyền hạn
        /// </summary>
        public string UserGroupName { get; set; } = string.Empty;

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int Status { get; set; } = 0;

        /// <summary>
        /// Nhân viên kinh doanh
        /// </summary>
        public string SalerUserName { get; set; } = string.Empty;

        /// <summary>
        /// Nhân viên đặt hàng
        /// </summary>
        public string OrdererUserName { get; set; } = string.Empty;

        /// <summary>
        /// Tổng số dư
        /// </summary>
        [Column(TypeName = "int(18,0)")] 
        public decimal TotalWallet { get; set; } 

        /// <summary>
        /// Lớn hơn 0
        /// </summary>
        [Column(TypeName = "int(18,0)")] 
        public int GreaterThan0 { get; set; } 

        /// <summary>
        /// Bằng 0
        /// </summary>
        [Column(TypeName = "int(18,0)")] 
        public int Equals0 { get; set; } 

        /// <summary>
        /// 1 triệu - 5 triệu
        /// </summary>
        [Column(TypeName = "int(18,0)")] 
        public int From1MTo5M { get; set; } 

        /// <summary>
        /// 5 triệu - 10 triệu
        /// </summary>
        [Column(TypeName = "int(18,0)")] 
        public int From5MTo10M { get; set; } 

        /// <summary>
        /// Lớn hơn 10 triệu
        /// </summary>
        [Column(TypeName = "int(18,0)")] 
        public int GreaterThan10M { get; set; } 
    }
}
