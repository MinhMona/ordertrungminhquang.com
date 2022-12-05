using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class Dashboard_GetTotalInWeek
    {
        #region Số lượng đơn hàng trong 1 tuần
        /// <summary>
        /// Mua hàng hộ
        /// </summary>
        public int MainOrderCount { get; set; } = 0;
        
        /// <summary>
        /// Mua hàng hộ khác
        /// </summary>
        public int MainOrderAnotherCount { get; set; } = 0;

        /// <summary>
        /// Vận chuyển hộ
        /// </summary>
        public int TransportationOrderCount { get; set; } = 0;

        /// <summary>
        /// Thanh toán hộ
        /// </summary>
        public int PayHelpCount { get; set; } = 0;
        #endregion

        /// <summary>
        /// Tổng tiền khách nạp trong tuần
        /// </summary>
        public decimal TotalAmount { get; set; } = 0;

        /// <summary>
        /// Tổng tiền khách nạp trong tuần vừa rồi
        /// </summary>
        public decimal TotalAmountPrev { get; set; } = 0;

        /// <summary>
        /// Tỉ lệ nạp tiền của tuần vừa rồi và tuần này
        /// </summary>
        public decimal TotalAmountPercent
        {
            get
            {
                if (TotalAmount != 0 && TotalAmountPrev != 0) return Decimal.Round(Math.Abs(((TotalAmount - TotalAmountPrev) * 100) / TotalAmountPrev), 0);
                return 0;
            }
        }
    }
}
