namespace EducationApp.BusinessLogicLayer.Models.Email
{
    public class EmailModel
    {
        public string MailBody { get; set; }
        public string MailSubject { get; set; }
        public string AdminEmail { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string AdminPassword { get; set; }
    }
}
