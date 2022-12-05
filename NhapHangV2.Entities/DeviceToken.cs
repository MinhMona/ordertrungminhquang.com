
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class DeviceToken : DomainEntities.AppDomain
    {
        public int? UID { get; set; }

        public int? Type { get; set; }

        [StringLength(100)]
        public string TypeName { get; set; }

        [StringLength(100)]
        public string Device { get; set; }

        public string UserToken { get; set; }
    }
}
