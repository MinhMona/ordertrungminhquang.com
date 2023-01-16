using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace NhapHangV2.Request.Auth
{
    public class UserGroupRequest : AppDomainCatalogueRequest
    {
        #region Extension Properties

        /// <summary>
        /// List id user của nhóm
        /// </summary>
        public List<int>? UserIds { get; set; }

        /// <summary>
        /// Người dùng thuộc nhóm
        /// </summary>
        public IList<UserInGroupRequest>? UserInGroups { get; set; }

        /// <summary>
        /// Chức năng + quyền của nhóm
        /// </summary>
        public IList<PermitObjectPermissionRequest>? PermitObjectPermissions { get; set; }
        #endregion
    }
}
