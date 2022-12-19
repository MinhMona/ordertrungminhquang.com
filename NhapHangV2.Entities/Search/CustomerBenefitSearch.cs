using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Search
{
    public class CustomerBenefitSearch : CatalogueSearch
    {
        /// <summary>
        /// Loại 1: Cam kết của chúng tôi, 2: Quyền lợi của khách hàng
        /// </summary>
        public int? Type { get; set; }
    }
}
