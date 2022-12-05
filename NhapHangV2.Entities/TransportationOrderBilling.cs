using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class TransportationOrderBilling
    {
        //public int Status { get; set; } //1 là đủ tiền, 0 là không đủ tiền
        public decimal Wallet { get; set; } = 0;

        public decimal TotalWeight { get; set; } = 0;

        public int TotalQuantity { get; set; } = 0;

        public decimal TotalWeightPriceCNY { get; set; } = 0;

        public decimal TotalWeightPriceVND { get; set; } = 0;

        public decimal FeeOutStockCNY { get; set; } = 0;

        public decimal FeeOutStockVND { get; set; } = 0;

        public decimal TotalPriceCNY { get; set; } = 0;

        public decimal TotalPriceVND { get; set; } = 0;

        public List<int> ListId { get; set; } = new List<int>();

        public decimal TotalSensoredFeeVND { get; set; } = 0;

        public decimal TotalSensoredFeeCNY { get; set; } = 0;

        public decimal TotalAdditionFeeVND { get; set; } = 0;

        public decimal TotalAdditionFeeCNY { get; set; } = 0;

        public decimal LeftMoney { get; set; } = 0;

        public List<ModelUpdatePayment> ModelUpdatePayments { get; set; } = new List<ModelUpdatePayment>();
    }

    public class ModelUpdatePayment
    {
        public int Id { get; set; } = 0;

        public decimal? Price { get; set; } = 0;

        public decimal? Weight { get; set; } = 0;
    }
}
