using System;
using System.Collections.Generic;
using System.Text;
using EducationApp.BusinessLogicLayer.Extention.BaseFilter;
using EducationApp.DataAccessLayer.Entities.Enums;
using static EducationApp.BusinessLogicLayer.Extention.Enums.Enums;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.User
{
    public class UserFilterModel :BaseFilterModel
    {
        public UsersFilterType UsersFilterStatus { get; set; }
        public UserSortType UserSortType { get; set; }
    }
}
