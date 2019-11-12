using EducationApp.BusinessLogicLayer.Models.Base;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Models.Users
{
    public class UsersModel : BaseModel
    {
        public ICollection<UserItemModel> Items = new List<UserItemModel>();
    }
}
