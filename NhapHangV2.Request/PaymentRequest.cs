using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class PaymentRequest
    {
        /// <summary>
        /// Họ tên
        /// </summary>
        [Required(ErrorMessage = "Vui lòng nhập họ và tên!")]
        public string FullName { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required(ErrorMessage = "Vui lòng nhập Số điện thoại!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]+${9,11}", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Vui lòng nhập Email!")]
        [EmailAddress(ErrorMessage = "Email có định dạng không hợp lệ!")]
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        [StringLength(1000, ErrorMessage = "Số kí tự của địa chỉ phải nhỏ hơn 1000!")]
        public string Address { get; set; }

        /// <summary>
        /// Danh sách shop
        /// </summary>
        public List<ShopPayment> ShopPayments { get; set; }
    }

    public class ShopPayment
    {
        /// <summary>
        /// Id shop
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// Kho TQ
        /// </summary>
        public int WarehouseTQ { get; set; }

        /// <summary>
        /// Chuyển về kho VN
        /// </summary>
        public int WarehouseVN { get; set; }

        /// <summary>
        /// Phương thức vận chuyển
        /// </summary>
        public int ShippingType { get; set; }
        //public decimal TotalMoney { get; set; }

        /// <summary>
        /// Khách ghi chú
        /// </summary>
        public string? UserNote{ get; set; }
        //public decimal TotalMoney { get; set; }
    }
}
