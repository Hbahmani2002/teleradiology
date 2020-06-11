using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Util.Email
{
    public class EmailService
    {
        public string InfoMailSenderEmail { get; set; }
        public string InfoMailSenderDisplayName { get; set; }
        public string InfoMailSenderPassword { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public EmailService(string ınfoMailSenderEmail, string ınfoMailSenderPassword, string smtpServer, int smtpPort)
        {
            InfoMailSenderEmail = ınfoMailSenderEmail;
            InfoMailSenderPassword = ınfoMailSenderPassword;
            SmtpServer = smtpServer;
            SmtpPort = smtpPort;
            InfoMailSenderDisplayName = "Project(Uyari)";
        }

        // TODO MUSTAFA
        public bool SendEmail(string message, string baslik, string displayName, string receiver)
        {
            return SendEmail(message, baslik, displayName, new[] { receiver });
        }
        public bool SendEmail(string message, string baslik, string displayName, string[] receiverList)
        {
            if (ConfigurationManager.AppSettings["Enable_Email"] != "1")
            {
                throw new System.Exception("Email Aktif Değil(İletişim:Yazılım)");
            }

            var from = new MailAddress(InfoMailSenderEmail, displayName);
            var to = new MailAddress(InfoMailSenderEmail);
            var mailMessage = new MailMessage(from, to)
            {
                BodyEncoding = Encoding.UTF8,
                HeadersEncoding = Encoding.UTF8,
                IsBodyHtml = true,
                Subject = baslik,
                Body = message
            };
            receiverList
                .ToList()
                .ForEach(o => mailMessage.CC.Add(o));
            return SendEmail(mailMessage);
        }

        private bool SendEmail(MailMessage mailMessage)
        {
            if (ConfigurationManager.AppSettings["Enable_Email"] != "1")
            {
                return true;
            }

            mailMessage.From = new MailAddress(InfoMailSenderEmail, InfoMailSenderDisplayName);
            if (!mailMessage.To.Any())
            {
                mailMessage.To.Add(new MailAddress(InfoMailSenderEmail));
            }

            var smtpClient = new SmtpClient(SmtpServer, SmtpPort);
            var credentials = new NetworkCredential(InfoMailSenderEmail, InfoMailSenderPassword);
            smtpClient.EnableSsl = false;
            smtpClient.Credentials = credentials;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Send(mailMessage);
            return true;
        }
    }
}
