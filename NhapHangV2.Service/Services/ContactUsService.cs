using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.Search;
using NhapHangV2.Extensions;
using NhapHangV2.Interface.DbContext;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.Services.Auth;
using NhapHangV2.Interface.Services.Catalogue;
using NhapHangV2.Interface.Services.Configuration;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Request;
using NhapHangV2.Service.Services.Auth;
using NhapHangV2.Service.Services.Catalogue;
using NhapHangV2.Service.Services.Configurations;
using NhapHangV2.Service.Services.DomainServices;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Service.Services
{
    public class ContactUsService : DomainService<ContactUs, ContactUsSearch>, IContactUsService
    {
        protected readonly IAppDbContext Context;
        public ContactUsService(IServiceProvider serviceProvider, IAppUnitOfWork unitOfWork, IMapper mapper, IAppDbContext Context) : base(unitOfWork, mapper)
        {
            this.Context = Context;
        }
        protected override string GetStoreProcName()
        {
            return "ContactUs_GetPagingData";
        }

        public async Task<List<ContactUs>> UpdateListContactUs(List<int> contactUs)
        {
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    List<ContactUs> contactUsList = new List<ContactUs>();
                    foreach (var item in contactUs)
                    {
                        var contact = unitOfWork.Repository<ContactUs>().GetQueryable().Where(x => x.Id == item).FirstOrDefault();
                        contact.Status = true;
                        unitOfWork.Repository<ContactUs>().Update(contact);
                        contactUsList.Add(contact);
                    }
                    await unitOfWork.SaveAsync();
                    await dbContextTransaction.CommitAsync();
                    return contactUsList;
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                    throw new AppException(ex.Message);
                }
            }
        }
    }
}
