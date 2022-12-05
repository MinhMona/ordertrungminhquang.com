using NhapHangV2.Extensions;
using NhapHangV2.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using NhapHangV2.Models.Auth;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services.Auth;
using NhapHangV2.Models.DomainModels;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Request.Auth;
using NhapHangV2.Entities.Auth;
using NhapHangV2.Entities.Search;

namespace NhapHangV2.API.Controllers.Auth
{
    [Route("api/permit-object")]
    [ApiController]
    [Description("Chức năng người dùng")]
    [Authorize]
    public class PermitObjectController : BaseCatalogueController<PermitObjects, PermitObjectModel, PermitObjectRequest, CatalogueSearch>
    {
        protected IPermitObjectPermissionService permitObjectPermissionService;
        protected IPermitObjectService permitObjectService;
        public PermitObjectController(IServiceProvider serviceProvider, ILogger<BaseCatalogueController<PermitObjects, PermitObjectModel, PermitObjectRequest, CatalogueSearch>> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            this.catalogueService = serviceProvider.GetRequiredService<IPermitObjectService>();
            permitObjectService = serviceProvider.GetRequiredService<IPermitObjectService>();
            permitObjectPermissionService = serviceProvider.GetRequiredService<IPermitObjectPermissionService>();
        }

        /// <summary>
        /// Lấy thông tin những chức năng cần được phân quyền
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-catalogue-controller")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public async Task<AppDomainResult> GetCatalogueController()
        {
            return await Task.Run(() =>
            {
                AppDomainResult appDomainResult = new AppDomainResult();
                System.AppDomain currentDomain = System.AppDomain.CurrentDomain;
                Assembly[] assems = currentDomain.GetAssemblies();
                var controllers = new List<ControllerModel>();
                foreach (Assembly assem in assems)
                {
                    var controller = assem.GetTypes().Where(type =>
                    typeof(ControllerBase).IsAssignableFrom(type) && !type.IsAbstract)
                  .Select(e => new ControllerModel()
                  {
                      Id = e.Name.Replace("Controller", string.Empty),
                      Name = string.Format("{0}", ReflectionUtilities.GetClassDescription(e)).Replace("Controller", string.Empty)
                  }).OrderBy(e => e.Name)
                      .Distinct();

                    controllers.AddRange(controller);
                }
                appDomainResult = new AppDomainResult()
                {
                    Data = controllers,
                    Success = true,
                    ResultCode = (int)HttpStatusCode.OK
                };
                return appDomainResult;
            });
        }

        /// <summary>
        /// Lấy thông tin chức năng theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AppAuthorize(new int[] { CoreContants.View })]
        public override async Task<AppDomainResult> GetById(int id)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            try
            {
                var item = await this.catalogueService.GetByIdAsync(id);
                if (item != null)
                {
                    var itemModel = mapper.Map<PermitObjectModel>(item);
                    itemModel.ToView();
                    appDomainResult = new AppDomainResult()
                    {
                        Success = true,
                        Data = itemModel,
                        ResultCode = (int)HttpStatusCode.OK
                    };
                }
                else
                    throw new KeyNotFoundException("Item không tồn tại");

            }
            catch (Exception ex)
            {
                this.logger.LogError(string.Format("{0} {1}: {2}", this.ControllerContext.RouteData.Values["controller"].ToString(), "GetById", ex.Message));
                throw new Exception(ex.Message);
            }
            return appDomainResult;
        }

        /// <summary>
        /// Thêm mới chức năng
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AppAuthorize(new int[] { CoreContants.AddNew })]
        public override Task<AppDomainResult> AddItem([FromBody] PermitObjectRequest itemModel)
        {
            itemModel.ToModel();
            return base.AddItem(itemModel);
        }

        /// <summary>
        /// Cập nhật thông tin chức năng
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPut]
        [AppAuthorize(new int[] { CoreContants.Update })]
        public override Task<AppDomainResult> UpdateItem([FromBody] PermitObjectRequest itemModel)
        {
            itemModel.ToModel();
            return base.UpdateItem(itemModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpGet("user-group-for-permit-object")]
        [AppAuthorize(new int[] { CoreContants.View })]
        public async Task<AppDomainResult> UserGroupForPermitObject([FromQuery] UserGroupForPermitObjectSearch itemModel)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            try
            {
                var permitObject = this.catalogueService.GetByCode(itemModel.PermitObjectCode);
                if (permitObject == null) throw new KeyNotFoundException("Không tìm thấy chức năng");
                var permitObjectPermissions = await permitObjectPermissionService.GetAsync(e => e.PermitObjectId == permitObject.Id);
                foreach (var permitObjectPermission in permitObjectPermissions.ToList())
                {
                    var permissions = permitObjectPermission.Permissions.Split(',');
                    if (Convert.ToInt32(permissions[itemModel.PermissionId - 1]) == 1) continue;

                    permitObjectPermissions.Remove(permitObjectPermission);
                }

                appDomainResult = new AppDomainResult()
                {
                    Success = true,
                    Data = mapper.Map<List<PermitObjectPermissionModel>>(permitObjectPermissions),
                    ResultCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                this.logger.LogError(string.Format("{0} {1}: {2}", this.ControllerContext.RouteData.Values["controller"].ToString(), "GetById", ex.Message));
                throw new Exception(ex.Message);
            }
            return appDomainResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPut("user-group-for-permit-object")]
        [AppAuthorize(new int[] { CoreContants.Update })]
        public async Task<AppDomainResult> UserGroupForPermitObject(List<UserGroupForPermitObjectRequest> itemModel)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = false;
            if (ModelState.IsValid)
            {
                var item = mapper.Map<List<UserGroupForPermitObject>>(itemModel);
                if (item != null)
                {
                    success = await permitObjectService.UpdateAsyncUserGroupForPermitObject(item);
                    if (success)
                        appDomainResult.ResultCode = (int)HttpStatusCode.OK;
                    else
                        throw new Exception("Lỗi trong quá trình xử lý");
                    appDomainResult.Success = success;
                }
                else
                    throw new KeyNotFoundException("Item không tồn tại");
            }
            else
                throw new AppException(ModelState.GetErrorMessage());

            return appDomainResult;
        }
    }
}
