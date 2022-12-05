using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models.Catalogue
{
    public class StepModel : AppDomainCatalogueModel
    {
        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string IMG { get; set; }

        /// <summary>
        /// Vị trí
        /// </summary>
        public int? Position { get; set; }

        /// <summary>
        /// Link
        /// </summary>
        public string Link { get; set; }
    }
}
