using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace MVC.Models
{
    public class EmailServices : IEmailServices
    {
        private const string templatePath = @"EmailTemplate/{0}.html";
        private readonly SMTFConfig _SMTFConfig;
        public async Task SendTestEmail(List<UserEmailOptions> userEmailOptions)
        {
            //userEmailOptions.Subject = "This email from car system management";
            //userEmailOptions.Body = GetEmailBody("TestEmail");

            for (int i = 0; i < userEmailOptions.Count();i++ ){
                await SendEmail(userEmailOptions[i]);
            }

        }

        public EmailServices(IOptions<SMTFConfig> _smtp)
        {
            this._SMTFConfig = _smtp.Value;
        }

        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_SMTFConfig.SenderAddress, _SMTFConfig.SenderDisplayName),
                IsBodyHtml = _SMTFConfig.IsBodyHTML
            };

            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }
            NetworkCredential networkCredential = new NetworkCredential(_SMTFConfig.UserName, _SMTFConfig.Password);
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _SMTFConfig.Host,
                Port = _SMTFConfig.Port,
                EnableSsl = _SMTFConfig.EnableSSL,
                UseDefaultCredentials = _SMTFConfig.UseDefaultCredentials,
                Credentials = networkCredential
            };

            mail.BodyEncoding = Encoding.Default;

            await smtpClient.SendMailAsync(mail);
        }

        public string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;

        }
    }
}
