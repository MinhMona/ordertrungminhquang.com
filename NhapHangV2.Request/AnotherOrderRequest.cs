using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class AnotherOrderRequest
    {
        /// <summary>
        /// UID
        /// </summary>
        public int UID { get; set; }

        /// <summary>
        /// Kho TQ
        /// </summary>
        public int WarehouseTQ { get; set; }

        /// <summary>
        /// Kho VN
        /// </summary>
        public int WarehouseVN { get; set; }

        /// <summary>
        /// Phương thức vận chuyển
        /// </summary>
        public int ShippingType { get; set; }

        /// <summary>
        /// Khách ghi chú
        /// </summary>
        public string? UserNote { get; set; }

        /// <summary>
        /// Danh sách sản phẩm
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Giao tận nhà
        /// </summary>
        public bool? IsFastDelivery { get; set; }

        /// <summary>
        /// Kiểm đếm
        /// </summary>
        public bool? IsCheckProduct { get; set; }

        /// <summary>
        /// Đóng gói
        /// </summary>
        public bool? IsPacked { get; set; }

        /// <summary>
        /// Bảo hiểm
        /// </summary>
        public bool? IsInsurance { get; set; }

    }

    public class Product
    {
        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string? ImageProduct { get; set; }

        /// <summary>
        /// Link sản phẩm
        /// </summary>
        public string LinkProduct { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string NameProduct { get; set; }

        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        public decimal? PriceProduct { get; set; }

        /// <summary>
        /// Màu sắc, kích thước
        /// </summary>
        public string? PropertyProduct { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int QuantityProduct { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string? NoteProduct { get; set; }
    }
}
