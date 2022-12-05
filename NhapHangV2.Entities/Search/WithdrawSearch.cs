using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Search
{
    public class WithdrawSearch : BaseSearch
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// Loại
        /// </summary>
        public int? Type { get; set; } = 2;

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; }
    }
}
