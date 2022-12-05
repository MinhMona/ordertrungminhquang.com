
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class HistoryScanPackage : DomainEntities.AppDomain
    {
        public int? SmallPackageId { get; set; } = 0;

        /// <summary>
        /// Id kho TQ
        /// </summary>
        public int? WareHouseId { get; set; } = 0;
    }
}
