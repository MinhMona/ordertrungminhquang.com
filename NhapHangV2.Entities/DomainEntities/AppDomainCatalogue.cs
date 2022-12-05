using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NhapHangV2.Entities.DomainEntities
{
    public class AppDomainCatalogue : AppDomain
    {
        [StringLength(50)]
        public string Code { get; set; } = string.Empty;

        [StringLength(500)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
    }
}
