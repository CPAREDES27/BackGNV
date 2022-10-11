using Application.Dto;
using Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(EmailDTO emailDto)
        {
            bool result = false;

            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    MailMessage message = new MailMessage();
                    string fromEmail = _configuration["EmailConfiguration:FromEmail"];
                    string host = _configuration["EmailConfiguration:Host"];
                    string userName = _configuration["EmailConfiguration:UserName"];
                    string password = _configuration["EmailConfiguration:Password"];
                    string port = _configuration["EmailConfiguration:Port"];
                    string CC = _configuration["EmailConfiguration:CC"];

                    message.From = new MailAddress(fromEmail);

                    foreach (var item in emailDto.ListRecipients)
                    {
                        message.To.Add(new MailAddress(item));
                    }

                    message.Subject = emailDto.Subject;
                    message.CC.Add(CC);
                    message.IsBodyHtml = true;
                    message.Body = emailDto.Body;
                    smtp.Port = int.Parse(port);
                    smtp.Host = host;
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(userName, password);
                    //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    await smtp.SendMailAsync(message);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
