using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.Services.DomainServices
{
    public interface ICatalogueService<T, E> : IDomainService<T, E> where T: AppDomainCatalogue where E : BaseSearch
    {
        T GetByCode(string code);
        Task<T> GetByCodeAsync(string code);
        Task<AppDomainImportResult> ImportTemplateFile(Stream stream, string createdBy);
    }
}
