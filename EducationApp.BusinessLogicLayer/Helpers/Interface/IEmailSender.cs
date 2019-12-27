namespace EducationApp.BusinessLogicLayer.Helpers
{
    public interface IEmailSender
    {
        void SendingEmailAsync(string email);

    }
}
