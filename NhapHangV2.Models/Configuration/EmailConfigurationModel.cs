using NhapHangV2.Models.DomainModels;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NhapHangV2.Models.Configuration
{
    /// <summary>
    /// Cấu hình email
    /// </summary>
    public class EmailConfigurationModel : AppDomainModel
    {
        /// <summary>
        /// SMTP Server
        /// </summary>
        public string SmtpServer { set; get; }

        /// <summary>
        /// Port 
        /// </summary>
        public int Port { set; get; }

        /// <summary>
        /// Cờ mở SSL
        /// </summary>
        public bool EnableSsl { set; get; }

        /// <summary>
        /// Loại connect
        /// </summary>
        public int ConnectType { set; get; }

        /// <summary>
        /// Tên hiển thị
        /// </summary>
        public string DisplayName { set; get; }

        /// <summary>
        /// Tên đăng nhập cấu hình
        /// </summary>
        public string UserName { set; get; }

        public string Email { get; set; }

        public string Password { set; get; }

        public int ItemSendCount { get; set; }

        public int TimeSend { get; set; }

        public void EncryptPassword()
        {
            Password = StringCipher.Encrypt(Password, StringCipher.PassPhrase);
        }
    }
}
