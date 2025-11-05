using System;
using System.Net;
using System.Net.Mail;
using ReceiptCommon;

namespace recieptlogicemail
{
    public class EmailLogic
    {
        public string SendEmail(ReceiptEmail info)
        {
            try
            {
                var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("58e5ac477b1ac0", "81f429603c134d"),
                    EnableSsl = true
                };

                client.Send(info.FromName, info.FromEmail, info.Subject, info.Body);
                return "Email Sent Successfully!";
            }
            catch (Exception ex)
            {
                return "Failed to send email: " + ex.Message;
            }
        }
    }
}
