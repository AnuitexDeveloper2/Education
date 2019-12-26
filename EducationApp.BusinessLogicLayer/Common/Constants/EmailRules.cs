namespace EducationApp.BusinessLogicLayer.Common.Consts
{
    public partial class Constants
    {
        public class EmailRules
        {
            public const string Error = "Error";
            public const string UserPassword = "Education2019";
            public const string MailSubject = "Registration";
            public const string UserEmail = "educationappgoncharuk2019@gmail.com";
            public const string UserName = "User";
            public const string AdminEmail = "morgenshtern1988@gmail.com";
            public const string Host = "smtp.gmail.com";
            public const int Port = 587;
            public const string AdminPassword = "25012005";
            public const string callbackUrl = "https://localhost:50285/account/confirmEmail";
            public const string MailBody = "Confirm registration by clicking on the link: <a href='{callbackUrl}'>link</a>";
            public const string Invalid = "You entered an invalid / inactive username or password";
            public const string ResetPassword = "This is your new paswword";
        }
    }
}
