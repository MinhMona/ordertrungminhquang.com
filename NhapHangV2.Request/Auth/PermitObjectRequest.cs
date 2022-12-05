using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace NhapHangV2.Request.Auth
{
    public class PermitObjectRequest : AppDomainCatalogueRequest
    {
        /// <summary>
        /// Id nhóm người dùng
        /// </summary>
        public int UserGroupId { get; set; }

        /// <summary>
        /// Tên controller
        /// </summary>
        public string ControllerNames { get; set; }

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
