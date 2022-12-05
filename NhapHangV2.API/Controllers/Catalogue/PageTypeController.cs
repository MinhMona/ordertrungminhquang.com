using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Extensions;
using NhapHangV2.Interface.Services.Catalogue;
using NhapHangV2.Models.Catalogue;
using NhapHangV2.Request.Catalogue;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NhapHangV2.API.Controllers.Catalogue
{
    [Route("api/page-type")]
    [ApiController]
    [Description("Danh sách chuyên mục")]
    public class PageTypeController : ControllerBase
    {
        protected IMapper mapper;
        protected IWebHostEnvironment env;
        protected IConfiguration configuration;

        protected readonly IPageTypeService pageTypeService;
        public PageTypeController(IServiceProvider serviceProvider, ILogger<PageTypeController> logger, IWebHostEnvironment env, IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.env = env;
            this.configuration = configuration;

            pageTypeService = serviceProvider.GetRequiredService<IPageTypeService>();
        }

        /// <summary>
        /// Lấy thông tin theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<AppDomainResult> GetById(int id)
        {
            AppDomainResult appDomainResult = new AppDomainResult();

            var item = await pageTypeService.GetByIdAsync(id);
            if (item != null)
            {
                var itemModel = mapper.Map<PageTypeModel>(item);
                appDomainResult = new AppDomainResult()
                {
                    Success = true,
                    Data = itemModel,
                    ResultCode = (int)HttpStatusCode.OK
                };
            }
            else
                throw new KeyNotFoundException("Item không tồn tại");

            return appDomainResult;
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

            var item = await pageTypeService.GetByCodeAsync(code);
            if (item != null)
            {
                var itemModel = mapper.Map<PageTypeModel>(item);
                appDomainResult = new AppDomainResult()
                {
                    Success = true,
                    Data = itemModel,
                    ResultCode = (int)HttpStatusCode.OK
                };
            }
            else
                throw new KeyNotFoundException("Item không tồn tại");

            return appDomainResult;
        }

        /// <summary>
        /// Thêm mới item
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AppAuthorize(new int[] { CoreContants.AddNew })]
        public async Task<AppDomainResult> AddItem([FromBody] PageTypeRequest itemModel)
        {
            AppDomainResult appDomainResult = new AppDomainResult();

            bool success = false;
            if (ModelState.IsValid)
            {
                itemModel.Code = AppUtilities.RemoveUnicode(itemModel.Name).ToLower().Replace(" ", "-");
                var item = mapper.Map<PageType>(itemModel);
                if (item != null)
                {
                    // Kiểm tra item có tồn tại chưa?
                    var messageUserCheck = await pageTypeService.GetExistItemMessage(item);
                    if (!string.IsNullOrEmpty(messageUserCheck))
                        throw new KeyNotFoundException(messageUserCheck);

                    #region Upload ảnh code cũ
                    //Hình ảnh
                    //List<string> filePaths = new List<string>();
                    //List<string> folderUploadPaths = new List<string>();

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
                    //if (!string.IsNullOrEmpty(OGTwitterIMG))
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

                    success = await pageTypeService.CreateAsync(item);
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
                throw new AppException(ModelState.GetErrorMessage());

            return appDomainResult;
        }

        /// <summary>
        /// Cập nhật thông tin item
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPut]
        [AppAuthorize(new int[] { CoreContants.Update })]
        public async Task<AppDomainResult> UpdateItem([FromBody] PageTypeRequest itemModel)
        {
            AppDomainResult appDomainResult = new AppDomainResult();

            bool success = false;
            if (ModelState.IsValid)
            {
                itemModel.Code = AppUtilities.RemoveUnicode(itemModel.Name).ToLower().Replace(" ", "-");
                var item = mapper.Map<PageType>(itemModel);
                if (item != null)
                {
                    // Kiểm tra item có tồn tại chưa?
                    var messageUserCheck = await pageTypeService.GetExistItemMessage(item);
                    if (!string.IsNullOrEmpty(messageUserCheck))
                        throw new KeyNotFoundException(messageUserCheck);
                    #region Upload ảnh code cũ
                    //Hình ảnh
                    //List<string> filePaths = new List<string>();
                    //List<string> folderUploadPaths = new List<string>();

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
                    //if (!string.IsNullOrEmpty(OGTwitterIMG))
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

                    success = await pageTypeService.UpdateAsync(item);
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

        /// <summary>
        /// Xóa item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [AppAuthorize(new int[] { CoreContants.Delete })]
        public async Task<AppDomainResult> DeleteItem(int id)
        {
            AppDomainResult appDomainResult = new AppDomainResult();

            bool success = await pageTypeService.DeleteAsync(id);
            if (success)
            {
                appDomainResult.ResultCode = (int)HttpStatusCode.OK;
                appDomainResult.Success = success;
            }
            else
                throw new Exception("Lỗi trong quá trình xử lý");
            return appDomainResult;
        }

        /// <summary>
        /// Lấy danh sách item phân trang
        /// </summary>
        /// <param name="baseSearch"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AppDomainResult> Get([FromQuery] CatalogueSearch baseSearch)
        {
            AppDomainResult appDomainResult = new AppDomainResult();

            if (ModelState.IsValid)
            {
                PagedList<PageType> pagedData = await pageTypeService.GetPagedListData(baseSearch);
                PagedList<PageTypeModel> pagedDataModel = mapper.Map<PagedList<PageTypeModel>>(pagedData);
                appDomainResult = new AppDomainResult
                {
                    Data = pagedDataModel,
                    Success = true,
                    ResultCode = (int)HttpStatusCode.OK
                };
            }
            else
                throw new AppException(ModelState.GetErrorMessage());

            return appDomainResult;
        }
    }
}
