using System;
using System.Collections.Generic;
using System.Text;
using EducationApp.DataAccessLayer.Entities.Enums;
using static EducationApp.BusinessLogicLayer.Extention.Enums.Enums;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Extention.User
{
    public class UserActionModel
    {
        public SortState SortState { get; set; }
        public FilterState FilterState { get; set; }

      
    }
}
