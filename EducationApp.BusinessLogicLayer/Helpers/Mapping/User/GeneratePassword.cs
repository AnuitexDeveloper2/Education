using System;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.User
{
    public class GeneratePassword
    {
        private static string _validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string CreateRandomPassword(int length = 8)
        {
            var random = new Random();
           
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = _validChars[random.Next(0, _validChars.Length)];
            }
            return new string(chars);
        }
    }
}
