using NhapHangV2.Interface.UnitOfWork;
using AutoMapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using NhapHangV2.Interface.Services.Auth;
using NhapHangV2.Service.Services.DomainServices;
using NhapHangV2.Entities.Search;
using NhapHangV2.Entities.Auth;
using System.Linq.Dynamic.Core;
using NhapHangV2.Entities;
using System.Collections;

namespace NhapHangV2.Service.Services.Auth
{
    public class UserInGroupService : DomainService<UserInGroups, UserInGroupSearch>, IUserInGroupService
    {
        public UserInGroupService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override string GetStoreProcName()
        {
            return "UserInGroup_GetPagingData";
        }


        public async Task<IList<UserInGroups>> GetUserInGroupsByUserGroupId(int userGroupId)
        {
            var userInGroups = await this.GetAsync(x => !x.Deleted && x.Active && x.UserGroupId == userGroupId);
            if (userInGroups != null)
                return userInGroups;
            return null;
        }
    }
}
