using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Search
{
    public class OrderShopTempSearch : BaseSearch
    {
        /// <summary>
        /// ID của User
        /// </summary>
        public int? UID { get; set; }
    }
}
