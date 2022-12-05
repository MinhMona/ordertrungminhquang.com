using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Extensions;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.Services.Auth;
using NhapHangV2.Interface.Services.Catalogue;
using NhapHangV2.Models.Auth;
using NhapHangV2.Models.Catalogue;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NhapHangV2.API.Controllers.Auth
{
    [Route("api/catalogue")]
    [ApiController]
    [Description("Quản lý danh mục")]
    [Authorize]
    public class CatalogueController : NhapHangV2.BaseAPI.Controllers.Catalogue.CatalogueController
    {
        protected readonly IBankService bankService;
        protected readonly IShippingTypeVNService shippingTypeVNService;
        protected readonly IShippingTypeToWareHouseService shippingTypeToWareHouseService;
        protected readonly IWarehouseFromService warehouseFromService;
        protected readonly IWarehouseService warehouseService;
        protected readonly IUserGroupService userGroupService;
        protected readonly IUserLevelService userLevelService;
        protected readonly IUserService userService;
        protected readonly IUserInGroupService userInGroupService;
        protected readonly IBigPackageService bigPackageService;
        protected readonly IPageTypeService pageTypeService;

        public CatalogueController(IServiceProvider serviceProvider, IMapper mapper, IConfiguration configuration) : base(serviceProvider, mapper, configuration)
        {
            bankService = serviceProvider.GetRequiredService<IBankService>();
            shippingTypeVNService = serviceProvider.GetRequiredService<IShippingTypeVNService>();
            shippingTypeToWareHouseService = serviceProvider.GetRequiredService<IShippingTypeToWareHouseService>();
            warehouseFromService = serviceProvider.GetRequiredService<IWarehouseFromService>();
            warehouseService = serviceProvider.GetRequiredService<IWarehouseService>();
            userGroupService = serviceProvider.GetRequiredService<IUserGroupService>();
            userLevelService = serviceProvider.GetRequiredService<IUserLevelService>();
            userService = serviceProvider.GetRequiredService<IUserService>();
            userInGroupService = serviceProvider.GetRequiredService<IUserInGroupService>();
            bigPackageService = serviceProvider.GetRequiredService<IBigPackageService>();
            pageTypeService = serviceProvider.GetRequiredService<IPageTypeService>();
        }

        /// <summary>
        /// Lấy danh sách ngân hàng
        /// </summary>
        /// <param name="searchContent"></param>
        /// <returns></returns>
        [HttpGet("get-bank-catalogue")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public async Task<AppDomainResult> GetBankCatalogue(string searchContent)
        {
            var banks = await this.bankService.GetAsync(e => !e.Deleted && e.Active
            && (string.IsNullOrEmpty(searchContent) ||
            (e.Code.Contains(searchContent)
            || e.Name.Contains(searchContent)
            ))
            );
            return new AppDomainResult()
            {
                Data = mapper.Map<IList<Bank>>(banks),
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Lấy danh sách bao hàng
        /// </summary>
        /// <param name="searchContent"></param>
        /// <param name="status">
        /// 0: Tất cả (ngoại trừ Hủy)
        /// 1: TQ
        /// 2: VN
        /// 3: Hủy
        /// </param>
        /// <returns></returns>
        [HttpGet("get-big-package-catalogue")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public async Task<AppDomainResult> GetBigPackageCatalogue(string searchContent, int status)
        {
            IList<BigPackage> bigPackages = new List<BigPackage>();
            if (status == 0)
            {
                bigPackages = await this.bigPackageService.GetAsync(e => !e.Deleted && e.Active && e.Status != 3
                    && (string.IsNullOrEmpty(searchContent) ||
                    (e.Code.Contains(searchContent)
                    || e.Name.Contains(searchContent)
                    )));
            }
            else
            {
                bigPackages = await this.bigPackageService.GetAsync(e => !e.Deleted && e.Active && e.Status == status
                    && (string.IsNullOrEmpty(searchContent) ||
                    (e.Code.Contains(searchContent)
                    || e.Name.Contains(searchContent)
                )));
            }

            return new AppDomainResult()
            {
                Data = mapper.Map<IList<BigPackage>>(bigPackages),
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Lấy danh sách vận chuyển trong nước
        /// </summary>
        /// <param name="searchContent"></param>
        /// <returns></returns>
        [HttpGet("get-shipping-type-vn-catalogue")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public async Task<AppDomainResult> GetShippingTypeVNCatalogue(string searchContent)
        {
            var shippingTypeVN = await this.shippingTypeVNService.GetAsync(e => !e.Deleted && e.Active
            && (string.IsNullOrEmpty(searchContent) ||
            (e.Code.Contains(searchContent)
            || e.Name.Contains(searchContent)
            ))
            );
            return new AppDomainResult()
            {
                Data = mapper.Map<IList<ShippingTypeVNModel>>(shippingTypeVN),
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Lấy danh sách hình thức vận chuyển
        /// </summary>
        /// <param name="searchContent"></param>
        /// <returns></returns>
        [HttpGet("get-shipping-type-to-warehouse-catalogue")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public async Task<AppDomainResult> GetShippingTypeToWarehouseCatalogue(string searchContent)
        {
            var shippingTypeToWareHouse = await this.shippingTypeToWareHouseService.GetAsync(e => !e.Deleted && e.Active
            && (string.IsNullOrEmpty(searchContent) ||
            (e.Code.Contains(searchContent)
            || e.Name.Contains(searchContent)
            ))
            );
            return new AppDomainResult()
            {
                Data = mapper.Map<IList<ShippingTypeToWareHouseModel>>(shippingTypeToWareHouse),
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Lấy danh sách kho TQ
        /// </summary>
        /// <param name="searchContent"></param>
        /// <returns></returns>
        [HttpGet("get-warehouse-from-catalogue")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public async Task<AppDomainResult> GetWarehouseFromCatalogue(string searchContent)
        {
            var warehouseFrom = await this.warehouseFromService.GetAsync(e => !e.Deleted && e.Active
            && (string.IsNullOrEmpty(searchContent) ||
            (e.Code.Contains(searchContent)
            || e.Name.Contains(searchContent)
            ))
            );
            return new AppDomainResult()
            {
                Data = mapper.Map<IList<WarehouseFromModel>>(warehouseFrom),
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Lấy danh sách kho VN
        /// </summary>
        /// <param name="searchContent"></param>
        /// <returns></returns>
        [HttpGet("get-warehouse-catalogue")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public async Task<AppDomainResult> GetWarehouseCatalogue(string searchContent)
        {
            var warehouse = await this.warehouseService.GetAsync(e => !e.Deleted && e.Active
            && (string.IsNullOrEmpty(searchContent) ||
            (e.Code.Contains(searchContent)
            || e.Name.Contains(searchContent)
            ))
            );
            return new AppDomainResult()
            {
                Data = mapper.Map<IList<WarehouseModel>>(warehouse),
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Lấy danh sách quyền
        /// </summary>
        /// <param name="searchContent"></param>
        /// <returns></returns>
        [HttpGet("get-user-group-catalogue")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public async Task<AppDomainResult> GetUserGroupCatalogue(string searchContent)
        {
            var userGroups = await this.userGroupService.GetAsync(e => !e.Deleted && e.Active
            && (string.IsNullOrEmpty(searchContent) ||
            (e.Code.Contains(searchContent)
            || e.Name.Contains(searchContent)
            ))
            );
            return new AppDomainResult()
            {
                Data = mapper.Map<IList<UserGroupModel>>(userGroups),
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Lấy danh sách phí người dùng
        /// </summary>
        /// <param name="searchContent"></param>
        /// <returns></returns>
        [HttpGet("get-user-level-catalogue")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public async Task<AppDomainResult> GetUserLevelCatalogue(string searchContent)
        {
            var userLevels = await this.userLevelService.GetAsync(e => !e.Deleted && e.Active
            && (string.IsNullOrEmpty(searchContent) ||
            (e.Name.Contains(searchContent)
            ))
            );
            return new AppDomainResult()
            {
                Data = mapper.Map<IList<UserLevel>>(userLevels),
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Lấy danh sách User
        /// </summary>
        /// <param name="searchContent">UserName</param>
        /// <param name="userGroupId">1: Admin, 2: User, 3: Quản lý, 4: Đặt hàng, 5: Kho TQ, 6: Kho VN, 7: Saler (kinh doanh), 8: Kế toán, 9: Thủ kho</param>
        /// <returns></returns>
        [HttpGet("get-user-catalogue")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public async Task<AppDomainResult> GetUserCatalogue(string searchContent, int userGroupId)
        {
            var userInGroups = await this.userInGroupService.GetAsync(e => !e.Deleted && e.UserGroupId == userGroupId);
            var users = new List<Users>();
            if (userInGroups.Any())
            {
                foreach (var userInGroup in userInGroups)
                {
                    var user = await this.userService.GetSingleAsync(e => !e.Deleted
                    && (string.IsNullOrEmpty(searchContent) || (e.UserName.Contains(searchContent)))
                    && e.Id == userInGroup.UserId);
                    if (user == null)
                        continue;
                    users.Add(user);
                }
            }

            return new AppDomainResult()
            {
                Data = mapper.Map<IList<Users>>(users),
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Lấy danh sách chuyên mục bài viết
        /// </summary>
        /// <param name="searchContent"></param>
        /// <returns></returns>
        [HttpGet("get-page-type-catalogue")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public async Task<AppDomainResult> GetPageTypeCatalogue(string searchContent)
        {
            var userLevels = await this.pageTypeService.GetAsync(e => !e.Deleted && e.Active
            && (string.IsNullOrEmpty(searchContent) ||
            (e.Name.Contains(searchContent)
            ))
            );
            return new AppDomainResult()
            {
                Data = mapper.Map<IList<PageType>>(userLevels),
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

    }
}