using EducationApp.BusinessLogicLayer.Models.MyOptions.Email;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace EducationApp.BusinessLogicLayer.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions _emailModel;
        public EmailSender( IOptions<EmailOptions> options)
        {
            _emailModel = options.Value;
        }
        public void SendingEmailAsync(string email)
        {
            var sender = new MailAddress(_emailModel.AdminEmail);
            var recipient = new MailAddress(email);
            var message = new MailMessage(sender, recipient)
            {
                Subject = _emailModel.MailSubject,
                Body = _emailModel.MailBody
            };
            var smtpClient = new SmtpClient(_emailModel.Host, _emailModel.Port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailModel.AdminEmail, _emailModel.AdminPassword),
                EnableSsl = true
            };
            smtpClient.Send(message);
        }
    }
}
