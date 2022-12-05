using NhapHangV2.Entities.Auth;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.Services.Auth
{
    public interface IPermitObjectService : ICatalogueService<PermitObjects, CatalogueSearch>
    {
        Task<bool> UpdateAsyncUserGroupForPermitObject(List<UserGroupForPermitObject> itemModels);
    }
}
