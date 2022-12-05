using NhapHangV2.Models.Auth;
using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Models
{
    public class UserModel : AppDomainModel
    {
        /// <summary>
        /// One Signal Player ID
        /// </summary>
        public string OneSignalPlayerID { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string AvatarIMG { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        [StringLength(200)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Họ
        /// </summary>
        [StringLength(200)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Tên trạng thái
        /// </summary>
        public string StatusName 
        { 
            get {
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
        /// Ngày sinh
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Phải là admin không
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Mật khẩu người dùng
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Cờ kiểm tra OTP của user
        /// </summary>
        public bool IsCheckOTP { get; set; }

        /// <summary>
        /// Cờ check login = facebook
        /// </summary>
        public bool IsLoginFaceBook { get; set; }

        /// <summary>
        /// Cờ check login = google
        /// </summary>
        public bool IsLoginGoogle { get; set; }

        #region Extension Properties

        /// <summary>
        /// Có reset mật khẩu không
        /// </summary>
        public bool IsResetPassword { get; set; }

        /// <summary>
        /// Mật khẩu cũ
        /// </summary>
        public string ConfirmPassWord { get; set; }

        /// <summary>
        /// Mật khẩu mới
        /// </summary>
        public string NewPassWord { get; set; }

        /// <summary>
        /// Mật khẩu mới
        /// </summary>
        public string ConfirmNewPassWord { get; set; }

        /// <summary>
        /// Giới tính
        /// 0 => Nữ
        /// 1 => Nam
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Id nhóm người dùng được chọn
        /// </summary>
        public int UserGroupId { get; set; }

        /// <summary>
        /// Tên nhóm người dùng được chọn
        /// </summary>
        public string UserGroupName { get; set; }

        #endregion

        /// <summary>
        /// Cấp người dùng
        /// </summary>
        public int? LevelId { get; set; }

        /// <summary>
        /// Số dư (VNĐ)
        /// </summary>
        public decimal? Wallet { get; set; }

        /// <summary>
        /// ID nhân viên kinh doanh
        /// </summary>
        public int? SaleId { get; set; }

        /// <summary>
        /// ID nhân viên đặt hàng
        /// </summary>
        public int? DatHangId { get; set; }

        /// <summary>
        /// Số dư (Tệ)
        /// </summary>
        public decimal? WalletCNY { get; set; }

        /// <summary>
        /// Kho TQ
        /// </summary>
        public int? WarehouseFrom { get; set; }

        /// <summary>
        /// Kho VN
        /// </summary>
        public int? WarehouseTo { get; set; }

        /// <summary>
        /// Tỉ giá riêng (Tệ)
        /// </summary>
        public decimal? Currency { get; set; }

        /// <summary>
        /// Phí mua hàng riêng (%)
        /// </summary>
        public decimal? FeeBuyPro { get; set; }

        /// <summary>
        /// Phí cân nặng riêng (VNĐ/KG)
        /// </summary>
        public string FeeTQVNPerWeight { get; set; }

        /// <summary>
        /// Phần trăm đặt cọc (%)
        /// </summary>
        public decimal? Deposit { get; set; }

        /// <summary>
        /// Phương thức vận chuyển
        /// </summary>
        public int? ShippingType { get; set; }

        //public string LoginStatus { get; set; }

        /// <summary>
        /// Tổng nạp
        /// </summary>
        public decimal SumAmount { get; set; }

        /// <summary>
        /// Tổng đơn mua hộ
        /// </summary>
        public decimal TotalMainOrder { get; set; }

        /// <summary>
        /// Tổng đơn vận chuyển hộ
        /// </summary>
        public decimal TotalTransportationOrder { get; set; }

        /// <summary>
        /// Tổng đơn thanh toán hộ
        /// </summary>
        public decimal TotalPayHelp { get; set; }

        //public string FeeTQVNPerVolume { get; set; }

        //public string TienTichLuy { get; set; }

        //public DateTime? DateUpLevel { get; set; }

        /// <summary>
        /// Tổng tiền đơn hàng
        /// </summary>
        public decimal? TotalOrderPrice { get; set; }

        /// <summary>
        /// Tổng tiền đã thanh toán
        /// </summary>
        public decimal? TotalPaidPrice { get; set; }

        /// <summary>
        /// Tổng tiền chưa thanh toán
        /// </summary>
        public decimal? TotalUnPaidPrice { get; set; }
    }
}
