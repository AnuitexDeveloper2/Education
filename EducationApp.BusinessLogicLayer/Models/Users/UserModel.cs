using EducationApp.BusinessLogicLayer.Models.Base;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Models.Users
{
    public class UserModel : BaseModel
    {
        public ICollection<UserModelItem> Items = new List<UserModelItem>();
        public int Count { get; set; }
    }
}
