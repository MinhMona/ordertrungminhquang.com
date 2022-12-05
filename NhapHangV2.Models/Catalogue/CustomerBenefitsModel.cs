using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models.Catalogue
{
    public class CustomerBenefitsModel : AppDomainCatalogueModel
    {
        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string IMG { get; set; }

        /// <summary>
        /// Link
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Vị trí
        /// </summary>
        public int? Position { get; set; }

        /// <summary>
        /// Loại
        /// </summary>
        public int? ItemType { get; set; }

        /// <summary>
        /// Tên loại
        /// </summary>
        public string ItemTypeName
        {
            get
            {
                switch (ItemType)
                {
                    case 1:
                        return "Cam kết của chúng tôi";
                    case 2:
                        return "Quyền lợi của khách hàng";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
