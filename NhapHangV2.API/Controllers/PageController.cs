using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
using NhapHangV2.Service.Services;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace NhapHangV2.API.Controllers
{
    [Route("api/page")]
    [ApiController]
    [Description("Danh sách bài viết")]
    public class PageController : BaseController<Page, PageModel, PageRequest, CatalogueSearch>
    {
        protected readonly IConfiguration configuration;
        protected readonly IPageService pageService;
        public PageController(IServiceProvider serviceProvider, ILogger<BaseController<Page, PageModel, PageRequest, CatalogueSearch>> logger, IWebHostEnvironment env, IConfiguration configuration) : base(serviceProvider, logger, env)
        {
            this.configuration = configuration;
            this.domainService = this.serviceProvider.GetRequiredService<IPageService>();
            pageService = serviceProvider.GetRequiredService<IPageService>();
        }

        /// <summary>
        /// Lấy thông tin theo code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("get-by-code")]
        public async Task<AppDomainResult> GetByCode(string code)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            if (string.IsNullOrEmpty(code))
            {
                throw new KeyNotFoundException("code không tồn tại");
            }
            var item = await pageService.GetByCodeAsync(code);
            if (item != null)
            {
                var itemModel = mapper.Map<PageModel>(item);
                appDomainResult = new AppDomainResult()
                {
                    Success = true,
                    Data = itemModel,
                    ResultCode = (int)HttpStatusCode.OK
                };
            }
            else
            {
                throw new KeyNotFoundException("Item không tồn tại");
            }
            return appDomainResult;
        }

        /// <summary>
        /// Thêm mới item
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AppAuthorize(new int[] { CoreContants.AddNew })]
        public override async Task<AppDomainResult> AddItem([FromBody] PageRequest itemModel)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = false;
            if (ModelState.IsValid)
            {
                itemModel.Code = AppUtilities.RemoveUnicode(itemModel.Title).ToLower().Replace(" ", "-");
                var item = mapper.Map<Page>(itemModel);
                if (item != null)
                {
                    // Kiểm tra item có tồn tại chưa?
                    var existCode = await this.domainService.GetAsync(x => !x.Deleted && x.Id != item.Id && x.Code == item.Code);
                    if (existCode.Count > 0)
                        throw new KeyNotFoundException("Mã đã tồn tại!");
                    #region Upload ảnh code cũ
                    //Hình ảnh
                    //List<string> filePaths = new List<string>();
                    //List<string> folderUploadPaths = new List<string>();

                    ////Ảnh đại diện
                    //string IMG = itemModel.IMG;
                    //if (!string.IsNullOrEmpty(IMG))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, IMG);
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
                    //        item.IMG = fileUrl;
                    //    }
                    //}

                    ////OG Image
                    //string OGImage = itemModel.OGImage;
                    //if (!string.IsNullOrEmpty(OGImage))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, OGImage);
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

                    ////OG Facebook IMG
                    //string OGFacebookIMG = itemModel.OGFacebookIMG;
                    //if (!string.IsNullOrEmpty(OGFacebookIMG))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, OGFacebookIMG);
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
                    //        item.OGFacebookIMG = fileUrl;
                    //    }
                    //}

                    ////OG Facebook IMG
                    //string OGTwitterIMG = itemModel.OGTwitterIMG;
                    //if (!string.IsNullOrEmpty(OGFacebookIMG))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, OGTwitterIMG);
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
                    //        item.OGTwitterIMG = fileUrl;
                    //    }
                    //}
                    #endregion

                    success = await this.domainService.CreateAsync(item);
                    if (success)
                    {
                        appDomainResult.ResultCode = (int)HttpStatusCode.OK;
                        appDomainResult.Data = item;
                    }
                    #region Response cũ
                    //if (success)
                    //{
                    //    appDomainResult.ResultCode = (int)HttpStatusCode.OK;
                    //    appDomainResult.Data = item;

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
        public override async Task<AppDomainResult> UpdateItem([FromBody] PageRequest itemModel)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = false;
            if (ModelState.IsValid)
            {
                itemModel.Code = AppUtilities.RemoveUnicode(itemModel.Title).ToLower().Replace(" ", "-");
                var item = mapper.Map<Page>(itemModel);
                if (item != null)
                {
                    // Kiểm tra item có tồn tại chưa?
                    var existCode = await this.domainService.GetAsync(x => !x.Deleted && x.Id != item.Id && x.Code == item.Code);
                    if (existCode.Count > 0)
                        throw new KeyNotFoundException("Mã đã tồn tại!");
                    #region Upload ảnh code cũ
                    //Hình ảnh
                    //List<string> filePaths = new List<string>();
                    //List<string> folderUploadPaths = new List<string>();

                    ////Ảnh đại diện
                    //string IMG = itemModel.IMG;
                    //if (!string.IsNullOrEmpty(IMG))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, IMG);
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
                    //        item.IMG = fileUrl;
                    //    }
                    //}

                    ////OG Image
                    //string OGImage = itemModel.OGImage;
                    //if (!string.IsNullOrEmpty(OGImage))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, OGImage);
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

                    ////OG Facebook IMG
                    //string OGFacebookIMG = itemModel.OGFacebookIMG;
                    //if (!string.IsNullOrEmpty(OGFacebookIMG))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, OGFacebookIMG);
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
                    //        item.OGFacebookIMG = fileUrl;
                    //    }
                    //}

                    ////OG Facebook IMG
                    //string OGTwitterIMG = itemModel.OGTwitterIMG;
                    //if (!string.IsNullOrEmpty(OGFacebookIMG))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, OGTwitterIMG);
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
                    //        item.OGTwitterIMG = fileUrl;
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
                throw new AppException(ModelState.GetErrorMessage());

            return appDomainResult;
        }
    }
}
