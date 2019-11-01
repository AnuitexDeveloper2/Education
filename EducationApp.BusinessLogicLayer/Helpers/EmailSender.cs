using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Helpers
{
    public class EmailSender : IEmailSender
    {
        public void SendingEmailAsync()
        {
            MailAddress from = new MailAddress("morgenshtern1988@gmail.com");
            MailAddress to = new MailAddress("educationappgoncharuk2019@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Body = "Письмо-тест 2 работы smtp-клиента";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("morgenshtern1988@gmail.com", "25012005");
            smtp.EnableSsl = true;
            smtp.Send(m);
            
        }

        
    }
}