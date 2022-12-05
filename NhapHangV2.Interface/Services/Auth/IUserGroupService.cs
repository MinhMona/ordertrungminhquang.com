using NhapHangV2.Entities.Auth;
using NhapHangV2.Entities.Search;
using NhapHangV2.Interface.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace NhapHangV2.Interface.Services.Auth
{
    public interface IUserGroupService : ICatalogueService<UserGroups, UserInGroupSearch>
    {
    }
}
