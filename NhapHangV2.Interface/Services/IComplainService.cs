using NhapHangV2.Entities;
using NhapHangV2.Entities.Search;
using NhapHangV2.Interface.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.Services
{
    public interface IComplainService : IDomainService<Complain, ComplainSearch>
    {
        Task<bool> UpdateStatus(int id, decimal amount, int status);
    }
}
