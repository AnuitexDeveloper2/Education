using System.Net;
using System.Net.Mail;
using static EducationApp.BusinessLogicLayer.Common.Consts.Constants.EmailRules;

namespace EducationApp.BusinessLogicLayer.Helpers
{
    public class EmailSender : IEmailSender
    {
        public void SendingEmailAsync(string email, string subject, string body)
        {
            var sender = new MailAddress(AdminEmail);
            var recipient = new MailAddress(email);
            var message = new MailMessage(sender, recipient);
            message.Subject = subject;
            message.Body = body;
            SmtpClient smtpClient = new SmtpClient(Host, Port);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(AdminEmail, AdminPassword);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
        }
    }
}
