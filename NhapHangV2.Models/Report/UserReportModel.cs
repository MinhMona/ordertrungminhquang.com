using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Models.Report
{
    public class UserReportModel : AppDomainReportModel
    {
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Số dư
        /// </summary>
        public decimal Wallet { get; set; }

        /// <summary>
        /// Quyền hạn
        /// </summary>
        public string UserGroupName { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Tên trạng thái
        /// </summary>
        public string StatusName
        {
            get
            {
                switch (Status)
                {
                    case (int)StatusUser.Active:
                        return "Đã kích hoạt";
                    case (int)StatusUser.NotActive:
                        return "Chưa kích hoạt";
                    case (int)StatusUser.Locked:
                        return "Đang bị khóa";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// Nhân viên kinh doanh
        /// </summary>
        public string SalerUserName { get; set; }

        /// <summary>
        /// Nhân viên đặt hàng
        /// </summary>
        public string OrdererUserName { get; set; }

        /// <summary>
        /// Tổng số dư
        /// </summary>
        public decimal TotalWallet { get; set; }

        /// <summary>
        /// Lớn hơn 0
        /// </summary>
        public decimal GreaterThan0 { get; set; }

        /// <summary>
        /// Bằng 0
        /// </summary>
        public decimal Equals0 { get; set; }

        /// <summary>
        /// 1 triệu - 5 triệu
        /// </summary>
        public decimal From1MTo5M { get; set; }

        /// <summary>
        /// 5 triệu - 10 triệu
        /// </summary>
        public decimal From5MTo10M { get; set; }

        /// <summary>
        /// Lớn hơn 10 triệu
        /// </summary>
        public decimal GreaterThan10M { get; set; }
    }
}
