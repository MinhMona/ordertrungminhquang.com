using NhapHangV2.Entities.Configuration;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.Services.Configuration
{
    public interface ISMSConfigurationService : IDomainService<SMSConfigurations, BaseSearch>
    {
        /// <summary>
        /// Gửi SMS qua SDT
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        Task<bool> SendSMS(string Phone, string Content);
    }
}
