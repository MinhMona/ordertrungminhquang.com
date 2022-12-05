using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace NhapHangV2.Entities.Auth
{
    /// <summary>
    /// Chức năng người dùng
    /// </summary>
    public class PermitObjects : AppDomainCatalogue
    {
        /// <summary>
        /// Tên controller
        /// </summary>
        public string ControllerNames { get; set; }

        /// <summary>
        /// Id nhóm người dùng (Dùng để POST)
        /// </summary>
        [NotMapped]
        public int UserGroupId { get; set; }

        /// <summary>
        /// List quyền + chức năng (Dùng để GET)
        /// </summary>
        [NotMapped]
        public List<PermitObjectPermissions> PermitObjectPermissions { get; set; }

        #region Extension Properties

        /// <summary>
        /// Danh sách tên controller
        /// </summary>
        [NotMapped]
        public IList<string> Controllers
        {
            get
            {
                return (!string.IsNullOrEmpty(ControllerNames)) ? ControllerNames.Split(';').ToList() : new List<string>();
            }
        }

        #endregion
    }
}
