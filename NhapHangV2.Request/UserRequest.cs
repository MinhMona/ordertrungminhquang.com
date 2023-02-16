using NhapHangV2.Request.Auth;
using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NhapHangV2.Request
{
    public class UserRequest : AppDomainRequest
    {

        [Required(ErrorMessage = "Vui lòng nhập User Name!")]
        public string? UserName { get; set; }

        [StringLength(12, ErrorMessage = "Số kí tự của số điện thoại phải lớn hơn 8 và nhỏ hơn 12!", MinimumLength = 9)]
        [Required(ErrorMessage = "Vui lòng nhập Số điện thoại!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]+${9,11}", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string? Phone { get; set; }

        [StringLength(50, ErrorMessage = "Số kí tự của email phải nhỏ hơn 50!")]
        [Required(ErrorMessage = "Vui lòng nhập Email!")]
        [EmailAddress(ErrorMessage = "Email có định dạng không hợp lệ!")]
        public string? Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        [StringLength(1000, ErrorMessage = "Số kí tự của email phải nhỏ hơn 1000!")]
        public string? Address { get; set; }

        /// <summary>
        /// Trạng thái (1: Đã kích hoạt, 2: Chưa kích hoạt, 3: Đang bị khóa)
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Phải là admin không
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Cờ kiểm tra OTP của user
        /// </summary>
        public bool IsCheckOTP { get; set; }

        /// <summary>
        /// Mật khẩu người dùng
        /// </summary>
        [StringLength(255, ErrorMessage = "Mật khẩu phải lớn hơn 8 kí tự", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        /// <summary>
        /// Ảnh đại diện
        /// </summary>
        //public string? AvatarIMG { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Họ
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Họ tên người dùng
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// ID nhân viên kinh doanh
        /// </summary>
        public int? SaleId { get; set; }

        /// <summary>
        /// ID nhân viên đặt hàng
        /// </summary>
        public int? DatHangId { get; set; }

        /// <summary>
        /// Phần trăm đặt cọc (%)
        /// </summary>
        public decimal? Deposit { get; set; }

        /// <summary>
        /// Phí cân nặng riêng (VNĐ/KG)
        /// </summary>
        public decimal? FeeTQVNPerWeight { get; set; }

        /// <summary>
        /// Phí thể tích riêng (VNĐ/KG)
        /// </summary>
        public decimal? FeeTQVNPerVolume { get; set; } = 0;

        /// <summary>
        /// Phí mua hàng riêng (%)
        /// </summary>
        public decimal? FeeBuyPro { get; set; }

        /// <summary>
        /// Tỉ giá riêng (Tệ)
        /// </summary>
        public decimal? Currency { get; set; }

        /// <summary>
        /// Cấp người dùng
        /// </summary>
        public int? LevelId { get; set; }

        /// <summary>
        /// One Signal Player ID
        /// </summary>
        public string? OneSignalPlayerID { get; set; }

        #region Extension Properties

        /// <summary>
        /// Có reset mật khẩu không
        /// </summary>
        [DefaultValue(false)]
        public bool IsResetPassword { get; set; }

        /// <summary>
        /// Mật khẩu cũ
        /// </summary>
        [DataType(DataType.Password)]
        public string? ConfirmPassWord { get; set; }

        /// <summary>
        /// Mật khẩu mới cho add
        /// </summary>
        [DataType(DataType.Password)]
        public string? NewPassWord { get; set; }

        /// <summary>
        /// Xác nhận mật khẩu mới cho add
        /// </summary>
        [DataType(DataType.Password)]
        public string? ConfirmNewPassWord { get; set; }

        /// <summary>
        /// Mật khẩu mới cho update
        /// </summary>
        [DataType(DataType.Password)]
        public string? PasswordNew { get; set; }

        /// <summary>
        /// Xác nhận mật khẩu mới cho update
        /// </summary>
        [DataType(DataType.Password)]
        public string? PasswordAgain { get; set; }

        /// <summary>
        /// Giới tính
        /// 0 => Nữ
        /// 1 => Nam
        /// </summary>
        [DefaultValue(0)]
        public int Gender { get; set; }

        /// <summary>
        /// Id nhóm người dùng được chọn
        /// </summary>
        public int UserGroupId { get; set; }

        /// <summary>
        /// Phương thức vận chuyển
        /// </summary>
        public int? ShippingType { get; set; } = 0;

        /// <summary>
        /// Kho TQ
        /// </summary>
        public int? WarehouseFrom { get; set; } = 0;

        /// <summary>
        /// Kho VN
        /// </summary>
        public int? WarehouseTo { get; set; } = 0;
        #endregion
    }
}
