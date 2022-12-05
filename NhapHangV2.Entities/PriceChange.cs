
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class PriceChange : DomainEntities.AppDomain
    {
        /// <summary>
        /// Giá tệ từ
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PriceFromCNY { get; set; } = 0;

        /// <summary>
        /// Giá tệ đến
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? PriceToCNY { get; set; } = 0;

        /// <summary>
        /// Tiền VNĐ
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? PriceVND { get; set; } = 0;

        /// <summary>
        /// VIP 0
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Vip0 { get; set; } = 0;

        /// <summary>
        /// VIP 1
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Vip1 { get; set; } = 0;

        /// <summary>
        /// VIP 2
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Vip2 { get; set; } = 0;

        /// <summary>
        /// VIP 3
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Vip3 { get; set; } = 0;

        /// <summary>
        /// VIP 4
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Vip4 { get; set; } = 0;

        /// <summary>
        /// VIP 5
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Vip5 { get; set; } = 0;

        /// <summary>
        /// VIP 6
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Vip6 { get; set; } = 0;

        /// <summary>
        /// VIP 7
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Vip7 { get; set; } = 0;

        /// <summary>
        /// VIP 8
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Vip8 { get; set; } = 0;
    }
}
