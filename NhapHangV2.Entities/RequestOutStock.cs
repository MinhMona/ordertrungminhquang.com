
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class RequestOutStock : DomainEntities.AppDomain
    {
        public int? SmallPackageId { get; set; } = 0;

        public int? ExportRequestTurnId { get; set; } = 0;

        /// <summary>
        /// Trạng thái
        /// 1. Chờ xuất
        /// 2. Đã xuất
        /// </summary>
        public int? Status { get; set; } = 1; //Mặc định "Chờ xuất"

        [NotMapped]
        public SmallPackage SmallPackage { get; set; } = new SmallPackage();
    }
}
