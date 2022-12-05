using AutoMapper;
using NhapHangV2.Service.Services.DomainServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Interface.Services.Auth;
using NhapHangV2.Entities.Auth;

namespace NhapHangV2.Service.Services.Auth
{
    public class PermissionService : CatalogueService<Permissions, CatalogueSearch>, IPermissionService
    {
        public PermissionService(IAppUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : base(unitOfWork, mapper, configuration)
        {
        }
    }
}
