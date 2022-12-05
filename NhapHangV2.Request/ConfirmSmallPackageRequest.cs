using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class ConfirmSmallPackageRequest
    {
        /// <summary>
        /// SmallPackageId
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Số điện thoại xác nhận
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Ghi chú xác nhận
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public IList<string>? Images { get; set; }
    }
}
