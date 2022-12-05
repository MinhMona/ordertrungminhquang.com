
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class Order : DomainEntities.AppDomain
    {
        public int? MainOrderId { get; set; } = 0;

        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; } = 0;

        /// <summary>
        /// Tên sản phẩm (gốc)
        /// </summary>
        public string TitleOrigin { get; set; } = string.Empty;

        /// <summary>
        /// Tên sản phẩm (dịch)
        /// </summary>
        public string TitleTranslated { get; set; } = string.Empty;

        /// <summary>
        /// Số lượng
        /// </summary>
        public int? Quantity { get; set; } = 0;

        /// <summary>
        /// Giá mua thực tế (tệ)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? RealPrice { get; set; } = 0;

        /// <summary>
        /// Ghi chú sản phẩm
        /// </summary>
        public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// Trạng thái (1: Còn hàng, 2: Hết hàng)
        /// </summary>
        public int? ProductStatus { get; set; } = 1; //Mặc định là còn hàng

        /// <summary>
        /// Giá gốc (tệ)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? PriceOrigin { get; set; } = 0;

        /// <summary>
        /// Giá khuyến mãi (tệ)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? PricePromotion { get; set; } = 0;

        /// <summary>
        /// Thông số (dịch)
        /// </summary>
        public string PropertyTranslated { get; set; } = string.Empty;

        /// <summary>
        /// Thông số (Gốc)
        /// </summary>
        public string Property { get; set; } = string.Empty;

        public string DataValue { get; set; } = string.Empty;

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string ImageOrigin { get; set; } = string.Empty;

        /// <summary>
        /// Id của shop trên web
        /// </summary>
        public string ShopId { get; set; } = string.Empty;

        /// <summary>
        /// Tên của shop trên web
        /// </summary>
        public string ShopName { get; set; } = string.Empty;

        /// <summary>
        /// Id của người bán trên web
        /// </summary>
        public string SellerId { get; set; } = string.Empty;

        /// <summary>
        /// Extension (Chưa biết là gì)
        /// </summary>
        public string Wangwang { get; set; } = string.Empty;

        /// <summary>
        /// Hàng trong kho
        /// </summary>
        public int? Stock { get; set; } = 0;

        /// <summary>
        /// Địa chỉ của shop
        /// </summary>
        public string LocationSale { get; set; } = string.Empty;

        /// <summary>
        /// Website
        /// </summary>
        public string Site { get; set; } = string.Empty;

        /// <summary>
        /// Extension (Có xài mà không biết là gì)
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Id của sản phẩm trên website
        /// </summary>
        public string ItemId { get; set; } = string.Empty;

        /// <summary>
        /// Link của sản phẩm
        /// </summary>
        public string LinkOrigin { get; set; } = string.Empty;

        public string OuterId { get; set; } = string.Empty;

        /// <summary>
        /// Extension (Lỗi)
        /// </summary>
        public string Error { get; set; } = string.Empty;

        /// <summary>
        /// Cân nặng
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? Weight { get; set; } = 0;

        /// <summary>
        /// Extension (Tên danh mục)
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// Extension (Id danh mục)
        /// </summary>
        public int CategoryId { get; set; } = 0;

        /// <summary>
        /// Extension (Công cụ)
        /// </summary>
        public string Tool { get; set; } = string.Empty;

        /// <summary>
        /// Extension (Phiên bản)
        /// </summary>
        public string Version { get; set; } = string.Empty;

        /// <summary>
        /// Dịch
        /// </summary>
        public bool? IsTranslate { get; set; } = false;

        /// <summary>
        /// Tỉ giá theo sản phẩm
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? CurrentCNYVN { get; set; } = 0;

        public bool? IsFastDelivery { get; set; } = false;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? IsFastDeliveryPrice { get; set; } = 0;

        public bool? IsCheckProduct { get; set; } = false;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? IsCheckProductPrice { get; set; } = 0;

        public bool? IsPacked { get; set; } = false;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? IsPackedPrice { get; set; } = 0;

        public bool? IsFast { get; set; } = false;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? IsFastPrice { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? PriceVND { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? PriceCNY { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? FeeShipCN { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? FeeBuyPro { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? FeeWeight { get; set; } = 0;

        [StringLength(1000)]
        public string Note { get; set; } = string.Empty;

        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Address { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Email { get; set; } = string.Empty;

        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        public int? Status { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? Deposit { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? TotalPriceVND { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")] 
        public decimal? PriceChange { get; set; } = 0;

        [StringLength(1000)]
        public string ProductNote { get; set; } = string.Empty;

        public string StepPrice { get; set; } = string.Empty;

        [StringLength(500)]
        public string OrderShopCode { get; set; } = string.Empty;

        public bool? IsBuy { get; set; } = false;

        /// <summary>
        /// Lịch sử thay đổi (Cập nhật)
        /// </summary>
        [NotMapped]
        public List<HistoryOrderChange> HistoryOrderChanges { get; set; } = new List<HistoryOrderChange>();

        [NotMapped]
        public string UserName { get; set; }

        /// <summary>
        /// Đơn giá
        /// </summary>
        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? UPriceBuy { get; set; } = 0;

        /// <summary>
        /// Đơn giá (VNĐ)
        /// </summary>
        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? UPriceBuyVN { get; set; } = 0;
    }
}
