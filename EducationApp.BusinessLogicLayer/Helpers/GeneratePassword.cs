using System;
using password = EducationApp.BusinessLogicLayer.Common.Consts.Constants.RandomPassword;

namespace EducationApp.BusinessLogicLayer.Helpers.GeneratePassword
{
    public class GeneratePassword
    {
        private static readonly string _validChars =password.AvailableChar;

        public static string CreateRandomPassword(int passwordLength)
        {
            var random = new Random();

            char[] chars = new char[passwordLength];

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = _validChars[random.Next(0, _validChars.Length)];
            }
            return new string(chars);
        }
    }
}
