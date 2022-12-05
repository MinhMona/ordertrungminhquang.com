using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Catalogue
{
    public class PageSEO : AppDomainCatalogue
    {
        /// <summary>
        /// OG Url
        /// </summary>
        public string OGUrl { get; set; } = string.Empty;

        /// <summary>
        /// OG Title
        /// </summary>
        public string OGTitle { get; set; } = string.Empty;

        /// <summary>
        /// OG Description
        /// </summary>
        public string OGDescription { get; set; } = string.Empty;

        /// <summary>
        /// OG Image
        /// </summary>
        public string OGImage { get; set; } = string.Empty;

        /// <summary>
        /// Meta Title
        /// </summary>
        public string MetaTitle { get; set; } = string.Empty;

        /// <summary>
        /// Meta Description
        /// </summary>
        public string MetaDescription { get; set; } = string.Empty;

        /// <summary>
        /// Meta Keyword
        /// </summary>
        public string MetaKeyword { get; set; } = string.Empty;
    }
}
