using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities.Enums
{
    public partial class Enums
    {
        public enum FilterState
        {
            IsRemovedTrue = 0,
            IsRemovedFalse = 1,
            LockoutEnabledTrue = 2,
            LockoutEnabledFalse = 3
        }
    }
}
