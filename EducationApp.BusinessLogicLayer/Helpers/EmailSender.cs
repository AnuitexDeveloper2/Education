using System.Net;
using System.Net.Mail;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.EmailConsts;

namespace EducationApp.BusinessLogicLayer.Helpers
{
    public class EmailSender : IEmailSender
    {
         public void SendingEmailAsync(string email,string subject,string body)
        {
            MailAddress from = new MailAddress(AdminEmail);
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Body = body;
            SmtpClient smtp = new SmtpClient(Host, Port);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(AdminEmail, AdminPassword);
            smtp.EnableSsl = true;
            smtp.Send(m);

                
        }

        //public Task Execute(string apiKey, string subject, string message, string email)
        //{
        //    var client = new SendGridClient(apiKey);
        //    var msg = new SendGridMessage()
        //    {
        //        From = new EmailAddress("Joe@contoso.com", Options.SendGridUser),
        //        Subject = subject,
        //        PlainTextContent = message,
        //        HtmlContent = message
        //    };
        //    msg.AddTo(new EmailAddress(email));


        }
    }