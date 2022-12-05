using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class Dashboard_GetItemInWeek
    {
        /// <summary>
        /// Ngày trong tuần
        /// </summary>
        public DateTime? DateOfWeek { get; set; }

        /// <summary>
        /// Mua hàng hộ
        /// </summary>
        public int MainOrder { get; set; } = 0;

        /// <summary>
        /// Mua hàng hộ khác
        /// </summary>
        public int MainOrderAnother { get; set; } = 0;

        /// <summary>
        /// Vận chuyển hộ
        /// </summary>
        public int TransportationOrder { get; set; } = 0;

        /// <summary>
        /// Thanh toán hộ
        /// </summary>
        public int PayHelp { get; set; } = 0;

        /// <summary>
        /// Tiền khách nạp trong tuần
        /// </summary>
        public decimal AdminSendUserWallet { get; set; } = 0;
    }
}
