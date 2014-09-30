using System;
using System.Configuration;
using System.Net.Mail;
using System.Text;

namespace Sending_Emails
{
    public class Email
    {
        private string from { get; set; }
        private string to { get; set; }
        private string subject { get; set; }
        private string message { get; set; }
        public MailMessage mailMessage;

        public Email()
        {
        }

        public Email(string from, string to, string subject, string message)
        {
            this.from = from;
            this.to = to;
            this.subject = subject;
            this.message = message;
        }

        public void Send()
        {
            //var smtpClient = getSmtpClient();
            mailMessage = CreateMailMessage();
            //smtpClient.Send(mailMessage);
        }

        private MailMessage CreateMailMessage()
        {
            var mail = new MailMessage(from, to, subject, message)
            {
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8,
                Priority = MailPriority.Normal
            };
            return mail;
        }

        private SmtpClient getSmtpClient()
        {
            var client = new SmtpClient
            {
                UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]),
                Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
                Host = ConfigurationManager.AppSettings["Host"],
                EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"])
            };
            return client;
        }
    }
}
