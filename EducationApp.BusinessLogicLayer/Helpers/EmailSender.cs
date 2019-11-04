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
            MailAddress to = new MailAddress("educationappgoncharuk2019@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Body = "Письмо-тест 2 работы smtp-клиента";
            SmtpClient smtp = new SmtpClient(Host, Port);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(AdminEmail, AdminPassword);
            smtp.EnableSsl = true;
            smtp.Send(m);
            

        }

        
    }
}