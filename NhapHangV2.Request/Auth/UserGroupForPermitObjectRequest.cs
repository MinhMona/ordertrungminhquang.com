using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request.Auth
{
    public class UserGroupForPermitObjectRequest
    {
        public int UserGroupId { get; set; }

        public int PermitObjectId { get; set; }

        public int PermissionId { get; set; }

        public bool IsCheck { get; set; }
    }
}
