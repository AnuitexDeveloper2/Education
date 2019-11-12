using System;
using System.Text;
using EducationApp.DataAccessLayer.Entities.Enums;

namespace EducationApp.DataAccessLayer.Entities.Constants
{
    public partial class Constants
    {
        public class Roles
        {
            public const string Admin = "Admin";
            public const string User = "User";
            public const string FirstName = "Vladimir";
            public const string LastName = "Goncharuk";
        }

        public static explicit operator Constants(Enums.Enums.TypeProduct v)
        {
            throw new NotImplementedException();
        }
    }
}
