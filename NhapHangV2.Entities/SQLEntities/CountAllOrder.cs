using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.SQLEntities
{
    public class CountAllOrder
    {
        public int MainOrder { get; set; }
        public int MainOrderAnother { get; set; }
        public int TransportationOrder { get; set; }
        public int PayHelp { get; set; }
    }
}
