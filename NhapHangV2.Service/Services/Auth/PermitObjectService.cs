using AutoMapper;
using NhapHangV2.Service.Services.DomainServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Interface.Services.Auth;
using NhapHangV2.Entities.Auth;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NhapHangV2.Interface.DbContext;

namespace NhapHangV2.Service.Services.Auth
{
    public class PermitObjectService : CatalogueService<PermitObjects, CatalogueSearch>, IPermitObjectService
    {
        protected readonly IAppDbContext Context;
        public PermitObjectService(IAppUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IAppDbContext Context) : base(unitOfWork, mapper, configuration)
        {
            this.Context = Context;
        }

        public async Task<bool> UpdateAsyncUserGroupForPermitObject(List<UserGroupForPermitObject> items)
        {
            foreach (var item in items)
            {
                var permissions = new String[] { "0", "0", "0", "0", "0", "0", "0", "0", "0" };
                var permitObjectPermissions = await unitOfWork.Repository<PermitObjectPermissions>().GetQueryable().Where(e => e.UserGroupId == item.UserGroupId && e.PermitObjectId == item.PermitObjectId).FirstOrDefaultAsync();
                if (item.IsCheck) //Có tích
                {
                    if (permitObjectPermissions == null) //Chưa tồn tại
                    {
                        permissions[item.PermissionId - 1] = "1";

                        permitObjectPermissions = new PermitObjectPermissions();

                        permitObjectPermissions.PermitObjectId = item.PermitObjectId;
                        permitObjectPermissions.UserGroupId = item.UserGroupId;
                        permitObjectPermissions.Permissions = string.Join(',', permissions);
                        await unitOfWork.Repository<PermitObjectPermissions>().CreateAsync(permitObjectPermissions);
                        continue;
                    }

                    //Đã tồn tại
                    permissions = permitObjectPermissions.Permissions.Split(',');
                    permissions[item.PermissionId - 1] = "1";
                    permitObjectPermissions.Permissions = string.Join(',', permissions);
                    unitOfWork.Repository<PermitObjectPermissions>().Update(permitObjectPermissions);
                    continue;
                }

                //Bỏ tích
                if (permitObjectPermissions == null) continue;

                permissions = permitObjectPermissions.Permissions.Split(',');
                permissions[item.PermissionId - 1] = "0";

                var isUpdate = false;
                for (int i = 0; i < permissions.Length; i++)
                {
                    if (Convert.ToInt32(permissions[i]) == 1)
                    {
                        isUpdate = true;
                        break;
                    }
                }
                permitObjectPermissions.Permissions = string.Join(',', permissions);

                if (isUpdate) unitOfWork.Repository<PermitObjectPermissions>().Update(permitObjectPermissions);
                else unitOfWork.Repository<PermitObjectPermissions>().Delete(permitObjectPermissions);


            }
            await unitOfWork.SaveAsync();
            return true;
        }
    }
}
