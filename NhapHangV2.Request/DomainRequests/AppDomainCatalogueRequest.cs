using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NhapHangV2.Request.DomainRequests
{
    public class AppDomainCatalogueRequest : AppDomainRequest
    {
        [StringLength(50, ErrorMessage = "Mã không được dài quá 50 kí tự")]
        public string Code { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Tên không được dài quá 500 kí tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Mô tả không được vượt quá 1000 kí tự")]
        public string? Description { get; set; }
    }
}
