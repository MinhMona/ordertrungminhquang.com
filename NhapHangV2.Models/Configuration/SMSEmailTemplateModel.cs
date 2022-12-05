using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NhapHangV2.Models.Configuration
{
    /// <summary>
    /// Bảng câu hình template gửi đi
    /// </summary>
    public class SMSEmailTemplateModel : AppDomainCatalogueModel
    {
        /// <summary>
        /// Tiêu đề
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Nội dung
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Mẫu là SMS
        /// </summary>
        public bool IsSMS { get; set; }
    }
}
