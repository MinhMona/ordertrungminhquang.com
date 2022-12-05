using AutoMapper;
using Microsoft.Data.SqlClient;
using NhapHangV2.Entities;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services
{
    public class UserLevelService : DomainService<UserLevel, BaseSearch>, IUserLevelService
    {
        public UserLevelService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override string GetStoreProcName()
        {
            return "UserLevel_GetPagingData";
        }

        //public override async Task<bool> CreateAsync(UserLevel item)
        //{
        //    await unitOfWork.Repository<UserLevel>().CreateAsync(item);
        //    var newItem = new UserLevel();
        //    newItem.Name = newItem.Id.ToString();
        //    await unitOfWork.Repository<UserLevel>().CreateAsync(newItem);
        //    return true;
        //}
    }
}
