using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class FieldForExportRequestTurnRequest
    {
        /// <summary>
        /// Xuất kho - ExportRequestTurnId
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Xuất kho đã yêu cầu - List SmallPackageId
        /// </summary>
        public List<int>? SmallPackageIds { get; set; }

        /// <summary>
        /// Cờ xuất kho đã yêu cầu
        /// </summary>
        public bool IsRequest { get; set; } = false;
    }
}
