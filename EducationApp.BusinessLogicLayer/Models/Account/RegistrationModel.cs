using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.Account
{
    public class RegistrationModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
