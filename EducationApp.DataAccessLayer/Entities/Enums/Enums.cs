using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities.Enums
{
    public partial class Enum
    {
        public class EntityEnums
        {

            public enum CurrencyEnum
            {
                USD,
                EUR,
                GBP,
                CHF,
                JPY,
                UAH
            }

            public enum StatusEnum
            {
                Paid,
                Unpaid
            }

            public enum TypeEnum
            {
                Book,
                Journal,
                Newspaper
            }
        }
    }
}
