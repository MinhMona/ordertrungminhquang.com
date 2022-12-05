using NhapHangV2.Entities.Auth;
using NhapHangV2.Entities.Search;
using NhapHangV2.Interface.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.Services.Auth
{
    public interface IUserInGroupService : IDomainService<UserInGroups, UserInGroupSearch>
    {
        Task<IList<UserInGroups>> GetUserInGroupsByUserGroupId(int userGroupId);
    }
}
