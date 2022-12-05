using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhapHangV2.Models.Auth
{
    /// <summary>
    /// Danh mục quyền ứng với chức năng người dùng
    /// </summary>
    public class PermitObjectPermissionModel : AppDomainModel
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
