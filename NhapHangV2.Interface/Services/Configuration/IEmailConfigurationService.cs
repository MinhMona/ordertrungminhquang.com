using NhapHangV2.Entities.Configuration;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services.DomainServices;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.Services.Configuration
{
    public interface IEmailConfigurationService : IDomainService<EmailConfigurations, BaseSearch>
    {
        Task<EmailSendConfigure> GetEmailConfig();
        EmailContent GetEmailContent();
        Task Send(string subject, string body, string[] Tos);
        Task Send(string subject, string body, string[] Tos, string[] CCs);
        Task Send(string subject, string body, string[] Tos, string[] CCs, string[] BCCs);
        Task Send(string subject, string[] Tos, string[] CCs, string[] BCCs, EmailContent emailContent);
        Task SendMail(string subject, string Tos, string[] CCs, string[] BCCs, EmailContent emailContent);
    }
}
