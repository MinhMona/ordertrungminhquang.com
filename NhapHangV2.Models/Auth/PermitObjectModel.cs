using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhapHangV2.Models.Auth
{
    /// <summary>
    /// Chức năng người dùng
    /// </summary>
    public class PermitObjectModel : AppDomainCatalogueModel
    {
        /// <summary>
        /// Tên controller
        /// </summary>
        public string ControllerNames { get; set; }

        /// <summary>
        /// Nhóm người dùng
        /// </summary>
        public int UserGroupId { get; set; }

        /// <summary>
        /// List quyền + chức năng
        /// </summary>
        public List<PermitObjectPermissionModel> PermitObjectPermissions { get; set; }

        #region Extension Properties

        /// <summary>
        /// Danh sách tên controller
        /// </summary>
        public IList<string> Controllers { get; set; }


        public void ToModel()
        {
            ControllerNames = string.Join(";", Controllers);
        }

        public void ToView()
        {
            if (!string.IsNullOrEmpty(ControllerNames))
            {
                Controllers = ControllerNames.Split(";");
            }
        }
        #endregion

    }
}
