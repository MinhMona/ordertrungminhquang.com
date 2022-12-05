using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Entities;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Extensions;
using NhapHangV2.Interface.Services;
using NhapHangV2.Models;
using NhapHangV2.Request;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NhapHangV2.API.Controllers
{
    [Route("api/configuration")]
    [ApiController]
    [Description("Cấu hình hệ thống")]
    [Authorize]
    public class ConfigurationsController : BaseController<Configurations, ConfigurationsModel, ConfigurationsRequest, BaseSearch>
    {
        protected readonly IConfiguration configuration;
        protected readonly IConfigurationsService configurationsService;
        protected readonly IHubContext<DomainHub, IDomainHub> hubContext;
        public ConfigurationsController(IServiceProvider serviceProvider, ILogger<BaseController<Configurations, ConfigurationsModel, ConfigurationsRequest, BaseSearch>> logger, IWebHostEnvironment env, IConfiguration configuration, IHubContext<DomainHub, IDomainHub> hubContext) : base(serviceProvider, logger, env)
        {
            this.configuration = configuration;
            configurationsService = serviceProvider.GetRequiredService<IConfigurationsService>(); ;
            this.hubContext = hubContext;
            this.domainService = this.serviceProvider.GetRequiredService<IConfigurationsService>();
        }

        /// <summary>
        /// Lấy tỷ giá thanh toán hộ theo cấu hình
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-currency")]
        [AppAuthorize(new int[] { CoreContants.View })]
        public async Task<AppDomainResult> GetCurrency()
        {
            var configurations = await this.domainService.GetAllAsync();
            decimal? currency = 0;
            if (configurations.FirstOrDefault() != null)
                currency = configurations.FirstOrDefault().Currency;
            return new AppDomainResult()
            {
                Data = currency,
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Lấy tỷ giá mua hộ
        /// </summary>
        /// <returns></returns>
        [HttpGet("currency")]
        [AppAuthorize(new int[] { CoreContants.View })]
        public async Task<AppDomainResult> GetCurrencyHeplBuy()
        {
            int UID = LoginContext.Instance.CurrentUser.UserId;
            var currency = await configurationsService.GetCurrency(UID);
            return new AppDomainResult()
            {
                Data = currency,
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Thêm mới item
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AppAuthorize(new int[] { CoreContants.AddNew })]
        public override async Task<AppDomainResult> AddItem([FromBody] ConfigurationsRequest itemModel)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = false;
            if (ModelState.IsValid)
            {
                var item = mapper.Map<Configurations>(itemModel);
                if (item != null)
                {
                    // Kiểm tra item có tồn tại chưa?
                    var messageUserCheck = await this.domainService.GetExistItemMessage(item);
                    if (!string.IsNullOrEmpty(messageUserCheck))
                        throw new KeyNotFoundException(messageUserCheck);
                    #region Upload ảnh code cũ
                    ////Logo
                    //List<string> filePaths = new List<string>();
                    //List<string> folderUploadPaths = new List<string>();
                    //string fileLogoIMG = itemModel.LogoIMG;
                    //if (!string.IsNullOrEmpty(fileLogoIMG))
                    //{

                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, fileLogoIMG);
                    //    // ------- START GET URL FOR FILE
                    //    string folderUploadPath = string.Empty;
                    //    var folderUpload = configuration.GetValue<string>("MySettings:FolderUpload");
                    //    folderUploadPath = Path.Combine(folderUpload, CoreContants.UPLOAD_FOLDER_NAME); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //    string fileUploadPath = Path.Combine(folderUploadPath, Path.GetFileName(filePath));
                    //    // Kiểm tra có tồn tại file trong temp chưa?
                    //    if (System.IO.File.Exists(filePath) && !System.IO.File.Exists(fileUploadPath))
                    //    {
                    //        FileUtilities.CreateDirectory(folderUploadPath);
                    //        FileUtilities.SaveToPath(fileUploadPath, System.IO.File.ReadAllBytes(filePath));
                    //        folderUploadPaths.Add(fileUploadPath);
                    //        var currentLinkSite = $"{Extensions.HttpContext.Current.Request.Scheme}://{Extensions.HttpContext.Current.Request.Host}/{CoreContants.UPLOAD_FOLDER_NAME}/";
                    //        string fileUrl = Path.Combine(currentLinkSite, Path.GetFileName(filePath)); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //                                                                                    // ------- END GET URL FOR FILE
                    //        filePaths.Add(filePath);

                    //        //Gán lại cho itemModel để mapper
                    //        item.LogoIMG = fileUrl;
                    //    }
                    //    item.LogoIMG = fileLogoIMG;
                    //}

                    ////OG Image
                    //string fileOGImage = itemModel.OGImage;
                    //if (!string.IsNullOrEmpty(fileOGImage))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, fileOGImage);
                    //    // ------- START GET URL FOR FILE
                    //    string folderUploadPath = string.Empty;
                    //    var folderUpload = configuration.GetValue<string>("MySettings:FolderUpload");
                    //    folderUploadPath = Path.Combine(folderUpload, CoreContants.UPLOAD_FOLDER_NAME); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //    string fileUploadPath = Path.Combine(folderUploadPath, Path.GetFileName(filePath));
                    //    // Kiểm tra có tồn tại file trong temp chưa?
                    //    if (System.IO.File.Exists(filePath) && !System.IO.File.Exists(fileUploadPath))
                    //    {
                    //        FileUtilities.CreateDirectory(folderUploadPath);
                    //        FileUtilities.SaveToPath(fileUploadPath, System.IO.File.ReadAllBytes(filePath));
                    //        folderUploadPaths.Add(fileUploadPath);
                    //        var currentLinkSite = $"{Extensions.HttpContext.Current.Request.Scheme}://{Extensions.HttpContext.Current.Request.Host}/{CoreContants.UPLOAD_FOLDER_NAME}/";
                    //        string fileUrl = Path.Combine(currentLinkSite, Path.GetFileName(filePath)); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //                                                                                    // ------- END GET URL FOR FILE
                    //        filePaths.Add(filePath);

                    //        //Gán lại cho itemModel để mapper
                    //        item.OGImage = fileUrl;
                    //    }
                    //    item.OGImage = fileOGImage;

                    //}

                    ////OG Twitter Image
                    //string fileOGTwitterImage = itemModel.OGTwitterImage;
                    //if (!string.IsNullOrEmpty(fileOGTwitterImage))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, fileOGTwitterImage);
                    //    // ------- START GET URL FOR FILE
                    //    string folderUploadPath = string.Empty;
                    //    var folderUpload = configuration.GetValue<string>("MySettings:FolderUpload");
                    //    folderUploadPath = Path.Combine(folderUpload, CoreContants.UPLOAD_FOLDER_NAME); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //    string fileUploadPath = Path.Combine(folderUploadPath, Path.GetFileName(filePath));
                    //    // Kiểm tra có tồn tại file trong temp chưa?
                    //    if (System.IO.File.Exists(filePath) && !System.IO.File.Exists(fileUploadPath))
                    //    {
                    //        FileUtilities.CreateDirectory(folderUploadPath);
                    //        FileUtilities.SaveToPath(fileUploadPath, System.IO.File.ReadAllBytes(filePath));
                    //        folderUploadPaths.Add(fileUploadPath);
                    //        var currentLinkSite = $"{Extensions.HttpContext.Current.Request.Scheme}://{Extensions.HttpContext.Current.Request.Host}/{CoreContants.UPLOAD_FOLDER_NAME}/";
                    //        string fileUrl = Path.Combine(currentLinkSite, Path.GetFileName(filePath)); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //                                                                                    // ------- END GET URL FOR FILE
                    //        filePaths.Add(filePath);

                    //        //Gán lại cho itemModel để mapper
                    //        item.OGTwitterImage = fileUrl;
                    //    }
                    //    item.OGTwitterImage = fileOGTwitterImage;
                    //}

                    #endregion
                    success = await this.domainService.CreateAsync(item);
                    if (success)
                    {
                        appDomainResult.ResultCode = (int)HttpStatusCode.OK;
                    }
                    #region Response cũ
                    //if (success)
                    //{
                    //    //// Remove file trong thư mục temp
                    //    if (filePaths.Any())
                    //    {
                    //        foreach (var filePath in filePaths)
                    //        {
                    //            System.IO.File.Delete(filePath);
                    //        }
                    //    }
                    //}

                    //else
                    //{
                    //    if (folderUploadPaths.Any())
                    //    {
                    //        foreach (var folderUploadPath in folderUploadPaths)
                    //        {
                    //            System.IO.File.Delete(folderUploadPath);
                    //        }
                    //    }
                    //    throw new Exception("Lỗi trong quá trình xử lý");
                    //}
                    #endregion
                    appDomainResult.Success = success;
                }
                else
                    throw new KeyNotFoundException("Item không tồn tại");
            }
            else
            {
                throw new AppException(ModelState.GetErrorMessage());
            }
            return appDomainResult;
        }

        /// <summary>
        /// Cập nhật thông tin item
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPut]
        [AppAuthorize(new int[] { CoreContants.Update })]
        public override async Task<AppDomainResult> UpdateItem([FromBody] ConfigurationsRequest itemModel)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = false;
            if (ModelState.IsValid)
            {
                var item = mapper.Map<Configurations>(itemModel);
                if (item != null)
                {
                    // Kiểm tra item có tồn tại chưa?
                    var messageUserCheck = await this.domainService.GetExistItemMessage(item);
                    if (!string.IsNullOrEmpty(messageUserCheck))
                        throw new KeyNotFoundException(messageUserCheck);
                    #region Upload ảnh code cũ
                    //Logo
                    //List<string> filePaths = new List<string>();
                    //List<string> folderUploadPaths = new List<string>();
                    //string fileLogoIMG = itemModel.LogoIMG;
                    //if (!string.IsNullOrEmpty(fileLogoIMG))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, fileLogoIMG);
                    //    // ------- START GET URL FOR FILE
                    //    string folderUploadPath = string.Empty;
                    //    var folderUpload = configuration.GetValue<string>("MySettings:FolderUpload");
                    //    folderUploadPath = Path.Combine(folderUpload, CoreContants.UPLOAD_FOLDER_NAME); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //    string fileUploadPath = Path.Combine(folderUploadPath, Path.GetFileName(filePath));
                    //    // Kiểm tra có tồn tại file trong temp chưa?
                    //    if (System.IO.File.Exists(filePath) && !System.IO.File.Exists(fileUploadPath))
                    //    {
                    //        FileUtilities.CreateDirectory(folderUploadPath);
                    //        FileUtilities.SaveToPath(fileUploadPath, System.IO.File.ReadAllBytes(filePath));
                    //        folderUploadPaths.Add(fileUploadPath);
                    //        var currentLinkSite = $"{Extensions.HttpContext.Current.Request.Scheme}://{Extensions.HttpContext.Current.Request.Host}/{CoreContants.UPLOAD_FOLDER_NAME}/";
                    //        string fileUrl = Path.Combine(currentLinkSite, Path.GetFileName(filePath)); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //                                                                                    // ------- END GET URL FOR FILE
                    //        filePaths.Add(filePath);

                    //        //Gán lại cho itemModel để mapper
                    //        item.LogoIMG = fileUrl;
                    //    }
                    //}

                    ////OG Image
                    //string fileOGImage = itemModel.OGImage;
                    //if (!string.IsNullOrEmpty(fileOGImage))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, fileOGImage);
                    //    // ------- START GET URL FOR FILE
                    //    string folderUploadPath = string.Empty;
                    //    var folderUpload = configuration.GetValue<string>("MySettings:FolderUpload");
                    //    folderUploadPath = Path.Combine(folderUpload, CoreContants.UPLOAD_FOLDER_NAME); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //    string fileUploadPath = Path.Combine(folderUploadPath, Path.GetFileName(filePath));
                    //    // Kiểm tra có tồn tại file trong temp chưa?
                    //    if (System.IO.File.Exists(filePath) && !System.IO.File.Exists(fileUploadPath))
                    //    {
                    //        FileUtilities.CreateDirectory(folderUploadPath);
                    //        FileUtilities.SaveToPath(fileUploadPath, System.IO.File.ReadAllBytes(filePath));
                    //        folderUploadPaths.Add(fileUploadPath);
                    //        var currentLinkSite = $"{Extensions.HttpContext.Current.Request.Scheme}://{Extensions.HttpContext.Current.Request.Host}/{CoreContants.UPLOAD_FOLDER_NAME}/";
                    //        string fileUrl = Path.Combine(currentLinkSite, Path.GetFileName(filePath)); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //                                                                                    // ------- END GET URL FOR FILE
                    //        filePaths.Add(filePath);

                    //        //Gán lại cho itemModel để mapper
                    //        item.OGImage = fileUrl;
                    //    }
                    //}

                    ////OG Twitter Image
                    //string fileOGTwitterImage = itemModel.OGTwitterImage;
                    //if (!string.IsNullOrEmpty(fileOGTwitterImage))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, fileOGTwitterImage);
                    //    // ------- START GET URL FOR FILE
                    //    string folderUploadPath = string.Empty;
                    //    var folderUpload = configuration.GetValue<string>("MySettings:FolderUpload");
                    //    folderUploadPath = Path.Combine(folderUpload, CoreContants.UPLOAD_FOLDER_NAME); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //    string fileUploadPath = Path.Combine(folderUploadPath, Path.GetFileName(filePath));
                    //    // Kiểm tra có tồn tại file trong temp chưa?
                    //    if (System.IO.File.Exists(filePath) && !System.IO.File.Exists(fileUploadPath))
                    //    {
                    //        FileUtilities.CreateDirectory(folderUploadPath);
                    //        FileUtilities.SaveToPath(fileUploadPath, System.IO.File.ReadAllBytes(filePath));
                    //        folderUploadPaths.Add(fileUploadPath);
                    //        var currentLinkSite = $"{Extensions.HttpContext.Current.Request.Scheme}://{Extensions.HttpContext.Current.Request.Host}/{CoreContants.UPLOAD_FOLDER_NAME}/";
                    //        string fileUrl = Path.Combine(currentLinkSite, Path.GetFileName(filePath)); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //                                                                                    // ------- END GET URL FOR FILE
                    //        filePaths.Add(filePath);

                    //        //Gán lại cho itemModel để mapper
                    //        item.OGTwitterImage = fileUrl;
                    //    }
                    //}

                    //// Banner Image
                    //string fileBannerIMG = itemModel.BannerIMG;
                    //if (!string.IsNullOrEmpty(fileBannerIMG))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, fileBannerIMG);
                    //    // ------- START GET URL FOR FILE
                    //    string folderUploadPath = string.Empty;
                    //    var folderUpload = configuration.GetValue<string>("MySettings:FolderUpload");
                    //    folderUploadPath = Path.Combine(folderUpload, CoreContants.UPLOAD_FOLDER_NAME); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //    string fileUploadPath = Path.Combine(folderUploadPath, Path.GetFileName(filePath));
                    //    // Kiểm tra có tồn tại file trong temp chưa?
                    //    if (System.IO.File.Exists(filePath) && !System.IO.File.Exists(fileUploadPath))
                    //    {
                    //        FileUtilities.CreateDirectory(folderUploadPath);
                    //        FileUtilities.SaveToPath(fileUploadPath, System.IO.File.ReadAllBytes(filePath));
                    //        folderUploadPaths.Add(fileUploadPath);
                    //        var currentLinkSite = $"{Extensions.HttpContext.Current.Request.Scheme}://{Extensions.HttpContext.Current.Request.Host}/{CoreContants.UPLOAD_FOLDER_NAME}/";
                    //        string fileUrl = Path.Combine(currentLinkSite, Path.GetFileName(filePath)); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //                                                                                    // ------- END GET URL FOR FILE
                    //        filePaths.Add(filePath);

                    //        //Gán lại cho itemModel để mapper
                    //        item.BannerIMG = fileUrl;
                    //    }
                    //}

                    //string fileBackgroundAuth = itemModel.BackgroundAuth;
                    //if (!string.IsNullOrEmpty(fileBackgroundAuth))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, fileBackgroundAuth);
                    //    // ------- START GET URL FOR FILE
                    //    string folderUploadPath = string.Empty;
                    //    var folderUpload = configuration.GetValue<string>("MySettings:FolderUpload");
                    //    folderUploadPath = Path.Combine(folderUpload, CoreContants.UPLOAD_FOLDER_NAME); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //    string fileUploadPath = Path.Combine(folderUploadPath, Path.GetFileName(filePath));
                    //    // Kiểm tra có tồn tại file trong temp chưa?
                    //    if (System.IO.File.Exists(filePath) && !System.IO.File.Exists(fileUploadPath))
                    //    {
                    //        FileUtilities.CreateDirectory(folderUploadPath);
                    //        FileUtilities.SaveToPath(fileUploadPath, System.IO.File.ReadAllBytes(filePath));
                    //        folderUploadPaths.Add(fileUploadPath);
                    //        var currentLinkSite = $"{Extensions.HttpContext.Current.Request.Scheme}://{Extensions.HttpContext.Current.Request.Host}/{CoreContants.UPLOAD_FOLDER_NAME}/";
                    //        string fileUrl = Path.Combine(currentLinkSite, Path.GetFileName(filePath)); //Có thể add tên thư mục vào đây để có thể đưa hình vào thư mục đó
                    //                                                                                    // ------- END GET URL FOR FILE
                    //        filePaths.Add(filePath);

                    //        //Gán lại cho itemModel để mapper
                    //        item.BackgroundAuth = fileUrl;
                    //    }
                    //}
                    #endregion
                    success = await this.domainService.UpdateAsync(item);
                    if (success)
                    {
                        appDomainResult.ResultCode = (int)HttpStatusCode.OK;
                    }
                    #region Response cũ
                    //if (success)
                    //{
                    //    appDomainResult.ResultCode = (int)HttpStatusCode.OK;

                    //// Remove file trong thư mục temp
                    //    if (filePaths.Any())
                    //    {
                    //        foreach (var filePath in filePaths)
                    //        {
                    //            System.IO.File.Delete(filePath);
                    //        }
                    //    }
                    //}

                    //else
                    //{
                    //    if (folderUploadPaths.Any())
                    //    {
                    //        foreach (var folderUploadPath in folderUploadPaths)
                    //        {
                    //            System.IO.File.Delete(folderUploadPath);
                    //        }
                    //    }
                    //    throw new Exception("Lỗi trong quá trình xử lý");
                    //}
                    #endregion
                    appDomainResult.Success = success;
                    await hubContext.Clients.All.ChangeTemp(true);
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
