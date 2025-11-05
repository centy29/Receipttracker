using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using ReceiptCommon;

namespace recieptlogicemail
{
    public class ReceiptEmailService
    {
        private readonly IConfiguration _config;

        public ReceiptEmailService(IConfiguration config)
        {
            _config = config;
        }

        public string SendEmail(ReceiptEmail info)
        {
            try
            {
                var smtpHost = _config["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_config["EmailSettings:SmtpPort"]);
                var smtpUser = _config["EmailSettings:Username"];
                var smtpPass = _config["EmailSettings:Password"];
                var fromEmail = _config["EmailSettings:FromEmail"];
                var fromName = _config["EmailSettings:FromName"];

                var client = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUser, smtpPass),
                    EnableSsl = true
                };

                var mail = new MailMessage
                {
                    From = new MailAddress(fromEmail, fromName),
                    Subject = info.Subject,
                    Body = info.Body
                };

                mail.To.Add(info.ToEmail);

                client.Send(mail);
                return "Email Sent Successfully!";
            }
            catch (Exception ex)
            {
                return "Failed to send email: " + ex.Message;
            }
        }
    }
}
