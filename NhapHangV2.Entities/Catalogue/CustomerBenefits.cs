using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Catalogue
{
    public class CustomerBenefits : AppDomainCatalogue
    {
        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string IMG { get; set; } = string.Empty;

        /// <summary>
        /// Link
        /// </summary>
        public string Link { get; set; } = string.Empty;

        /// <summary>
        /// Vị trí
        /// </summary>
        public int? Position { get; set; } = 0;

        /// <summary>
        /// 1. Cam kết, 2. Quyền lợi
        /// </summary>
        public int? ItemType { get; set; } = 0;
    }
}
