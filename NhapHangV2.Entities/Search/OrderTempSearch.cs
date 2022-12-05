using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Search
{
    public class OrderTempSearch : BaseSearch
    {
        /// <summary>
        /// Id người dùng
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// ShopID
        /// </summary>
        public int? ShopID { get; set; }
    }
}
