using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models
{
    public class OrderModel : AppDomainModel
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// Tên sản phẩm (gốc)
        /// </summary>
        public string TitleOrigin { get; set; }

        /// <summary>
        /// Tên sản phẩm (dịch)
        /// </summary>
        public string TitleTranslated { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Giá mua thực tế (tệ)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? RealPrice { get; set; }

        /// <summary>
        /// Ghi chú sản phẩm
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? ProductStatus { get; set; }

        /// <summary>
        /// Tên trạng thái
        /// </summary>
        public string ProductStatusName
        {
            get
            {
                switch (ProductStatus)
                {
                    case 1:
                        return "Còn hàng";
                    case 2:
                        return "Hết hàng";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// Giá gốc (tệ)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PriceOrigin { get; set; }

        /// <summary>
        /// Giá khuyến mãi (tệ)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PricePromotion { get; set; }

        /// <summary>
        /// Thông số (dịch)
        /// </summary>
        public string PropertyTranslated { get; set; }

        /// <summary>
        /// Thông số (Gốc)
        /// </summary>
        public string Property { get; set; }

        public string DataValue { get; set; }

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string ImageOrigin { get; set; }

        /// <summary>
        /// Id của shop trên web
        /// </summary>
        public string ShopId { get; set; }

        /// <summary>
        /// Tên của shop trên web
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// Id của người bán trên web
        /// </summary>
        public string SellerId { get; set; }

        /// <summary>
        /// Extension (Chưa biết là gì)
        /// </summary>
        public string Wangwang { get; set; }

        /// <summary>
        /// Hàng trong kho
        /// </summary>
        public int? Stock { get; set; }

        /// <summary>
        /// Địa chỉ của shop
        /// </summary>
        public string LocationSale { get; set; }

        /// <summary>
        /// Website
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// Extension (Có xài mà không biết là gì)
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Id của sản phẩm trên website
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// Link của sản phẩm
        /// </summary>
        public string LinkOrigin { get; set; }

        public string OuterId { get; set; }

        /// <summary>
        /// Extension (Lỗi)
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Cân nặng
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// Extension (Tên danh mục)
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Extension (Id danh mục)
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Extension (Công cụ)
        /// </summary>
        public string Tool { get; set; }

        /// <summary>
        /// Extension (Phiên bản)
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Dịch
        /// </summary>
        public bool? IsTranslate { get; set; }

        /// <summary>
        /// Đơn giá
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? UPriceBuy
        {
            get
            {
                if (PricePromotion > 0 && PricePromotion < PriceOrigin)
                    return PricePromotion;
                else
                    return PriceOrigin;
            }
        }

        /// <summary>
        /// Đơn giá (VNĐ)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? UPriceBuyVN
        {
            get
            {
                if (PricePromotion > 0 && PricePromotion < PriceOrigin)
                    return PricePromotion * CurrentCNYVN;
                else
                    return PriceOrigin * CurrentCNYVN;
            }
        }

        public bool? IsFastDelivery { get; set; }

        public decimal? IsFastDeliveryPrice { get; set; }

        public bool? IsCheckProduct { get; set; }

        public decimal? IsCheckProductPrice { get; set; }

        public bool? IsPacked { get; set; }

        public decimal? IsPackedPrice { get; set; }

        public bool? IsFast { get; set; }

        public decimal? IsFastPrice { get; set; }

        public decimal? PriceVND { get; set; }

        public decimal? PriceCNY { get; set; }

        public decimal? FeeShipCN { get; set; }

        public decimal? FeeBuyPro { get; set; }

        public decimal? FeeWeight { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(1000)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public int? Status { get; set; }

        public decimal? Deposit { get; set; }

        public decimal? CurrentCNYVN { get; set; }

        public decimal? TotalPriceVND { get; set; }

        public decimal? PriceChange { get; set; }

        public int? MainOrderId { get; set; }

        [StringLength(1000)]
        public string ProductNote { get; set; }

        public string StepPrice { get; set; }

        [StringLength(500)]
        public string OrderShopCode { get; set; }

        public bool? IsBuy { get; set; }

        public string UserName { get; set; }
    }
}
