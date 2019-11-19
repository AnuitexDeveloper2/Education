using EducationApp.BusinessLogicLayer.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.Users
{
    public class UserModelItem : BaseModel //todo rename to UserModelItem
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Id { get; set; }
        public string Role { get; set; }
        public string SecurityStamp { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsRemoved { get; set; }
        public bool LockoutEnabled { get; set; }


    }
}
