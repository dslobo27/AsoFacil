using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AsoFacil.Helpers.Email
{
    public class EmailService
    {
        private readonly EmailConfig _emailConfig;

        public EmailService(IOptions<EmailConfig> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public async Task EnviarEmailAsync(EmailRequest emailRequest)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress(_emailConfig.Mail, _emailConfig.DisplayName);
                message.To.Add(new MailAddress(emailRequest.Destinatario));
                
                message.Subject = emailRequest.Assunto;
                message.IsBodyHtml = true;
                message.Body = emailRequest.Mensagem;
                smtp.Port = _emailConfig.Port;
                smtp.Host = _emailConfig.Host;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_emailConfig.Mail, _emailConfig.Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                EmailRequestExtension.DisableCertificateValidation();
                await smtp.SendMailAsync(message);
            }
            catch (System.Exception)
            {
            }
        }
    }
}
