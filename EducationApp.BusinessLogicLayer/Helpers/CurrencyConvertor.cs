using System.Collections.Generic;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers
{
    public class CurrencyConvertor
    {
        private readonly Dictionary<CurrencyType, decimal> _convertor = new Dictionary<CurrencyType, decimal>()
        {
            { CurrencyType.GBP, (decimal)1.4 },
            { CurrencyType.EUR, (decimal)1.2 },
            { CurrencyType.CHF, (decimal)12.5 },
            { CurrencyType.JPY, (decimal)2.3 },
            { CurrencyType.UAH, (decimal)25.0 },
            { CurrencyType.USD, (decimal)1.0 }
        
        };

        public decimal Convertor(CurrencyType from,CurrencyType to, decimal price)
        {
            return price / _convertor[from] * _convertor[to];
        }
    }
}
