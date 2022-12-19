using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.DomainEntities
{
    public class CatalogueSearch : BaseSearch
    {
        /// <summary>
        /// Active
        /// </summary>
        public bool? Active { set; get; }

        /// <summary>
        /// ItemType 1: Cam kết của chúng tôi, 2: Quyền lợi của khách hàng
        /// </summary>
        public int? Type { get; set; }
    }
}
