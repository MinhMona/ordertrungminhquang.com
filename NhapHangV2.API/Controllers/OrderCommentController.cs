using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Search;
using NhapHangV2.Extensions;
using NhapHangV2.Interface.Services;
using NhapHangV2.Models;
using NhapHangV2.Request;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NhapHangV2.API.Controllers
{
    [Route("api/order-comment")]
    [ApiController]
    [Description("Nhắn tin ở đơn hàng")]
    [Authorize]
    public class OrderCommentController : BaseController<OrderComment, OrderCommentModel, OrderCommentRequest, OrderCommentSearch>
    {
        protected readonly IConfiguration configuration;
        public OrderCommentController(IServiceProvider serviceProvider, ILogger<BaseController<OrderComment, OrderCommentModel, OrderCommentRequest, OrderCommentSearch>> logger, IWebHostEnvironment env, IConfiguration configuration) : base(serviceProvider, logger, env)
        {
            this.configuration = configuration;
            this.domainService = this.serviceProvider.GetRequiredService<IOrderCommentService>();
        }

        /// <summary>
        /// Thêm mới item
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AppAuthorize(new int[] { CoreContants.AddNew })]
        public override async Task<AppDomainResult> AddItem([FromBody] OrderCommentRequest itemModel)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = false;
            if (ModelState.IsValid)
            {
                var item = mapper.Map<OrderComment>(itemModel);
                if (item != null)
                {
                    // Kiểm tra item có tồn tại chưa?
                    var messageUserCheck = await this.domainService.GetExistItemMessage(item);
                    if (!string.IsNullOrEmpty(messageUserCheck))
                        throw new KeyNotFoundException(messageUserCheck);
                    #region Upload ảnh code cũ
                    //File
                    //List<string> filePaths = new List<string>();
                    //List<string> folderUploadPaths = new List<string>();
                    //string file = itemModel.FileLink;
                    //if (!string.IsNullOrEmpty(file))
                    //{
                    //    string filePath = Path.Combine(env.ContentRootPath, CoreContants.UPLOAD_FOLDER_NAME, CoreContants.TEMP_FOLDER_NAME, file);
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
                    //        item.FileLink = fileUrl;
                    //    }
                    //}
                    #endregion

                    success = await this.domainService.CreateAsync(item);
                    if (success)
                    {
                        appDomainResult.ResultCode = (int)HttpStatusCode.OK;
                        appDomainResult.Data = mapper.Map<OrderCommentModel>(item);
                    }
                    #region Response cũ
                    //if (success)
                    //{
                    //    appDomainResult.ResultCode = (int)HttpStatusCode.OK;
                    //    appDomainResult.Data = mapper.Map<OrderCommentModel>(item);

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
    }
}
