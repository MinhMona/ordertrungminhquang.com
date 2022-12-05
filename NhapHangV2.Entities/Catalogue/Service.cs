using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Catalogue
{
    public class Service : AppDomainCatalogue
    {
        /// <summary>
        /// Link
        /// </summary>
        public string Link { get; set; } = string.Empty;

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string IMG { get; set; } = string.Empty;

        /// <summary>
        /// Vị trí
        /// </summary>
        public int? Position { get; set; } = 0;
    }
}
