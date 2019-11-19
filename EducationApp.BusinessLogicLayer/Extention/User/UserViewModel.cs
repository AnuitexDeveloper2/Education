using EducationApp.BusinessLogicLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Extention.User
{
    public class UserViewModel
    {
        public IEnumerable<UserModelItem> Users { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
