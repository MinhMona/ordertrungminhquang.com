using NhapHangV2.Entities;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using NhapHangV2.Service.Services.DomainServices;
using NhapHangV2.Interface.Services.Auth;
using NhapHangV2.Entities.Auth;

namespace NhapHangV2.Service.Services.Auth
{
    public class PermitObjectPermissionService : DomainService<PermitObjectPermissions, BaseSearch>, IPermitObjectPermissionService
    {
        public PermitObjectPermissionService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
