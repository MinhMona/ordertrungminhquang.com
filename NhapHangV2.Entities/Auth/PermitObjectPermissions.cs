using System;
using System.Collections.Generic;
using System.Text;

namespace NhapHangV2.Entities.Auth
{
    /// <summary>
    /// Danh mục quyền ứng với chức năng người dùng
    /// </summary>
    public class PermitObjectPermissions : DomainEntities.AppDomain
    {
        /// <summary>
        /// Chức năng
        /// </summary>
        public int PermitObjectId { get; set; }

        /// <summary>
        /// List quyền
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        /// Nhóm người dùng
        /// </summary>
        public int? UserGroupId { get; set; }
    }
}
