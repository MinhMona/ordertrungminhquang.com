using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Auth
{
    public class UserGroupForPermitObject
    {
        public int UserGroupId { get; set; }

        public int PermitObjectId { get; set; }

        public int PermissionId { get; set; }

        public bool IsCheck { get; set; }
    }
}
