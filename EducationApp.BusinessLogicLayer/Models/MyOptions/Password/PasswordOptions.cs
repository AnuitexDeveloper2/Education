﻿namespace EducationApp.BusinessLogicLayer.Models.MyOptions.Password
{
    public class PasswordOptions
    {
        public int RequiredLength { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireDigit { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
        public bool RequiredUniqueChars { get; set; }
    }
}
