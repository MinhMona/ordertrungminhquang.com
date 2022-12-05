using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Catalogue
{
    public class NotificationTemplate : AppDomainCatalogue
    {
        /// <summary>
        /// Tiêu đề
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Nội dung
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Template mặc định
        /// </summary>
        public bool IsTemplateDefault { get; set; } = false;
    }
}
