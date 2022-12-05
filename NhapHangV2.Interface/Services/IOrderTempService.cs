﻿using NhapHangV2.Entities;
using NhapHangV2.Entities.Search;
using NhapHangV2.Interface.Services.DomainServices;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.Services
{
    public interface IOrderTempService : IDomainService<OrderTemp, OrderTempSearch>
    {

    }
}
