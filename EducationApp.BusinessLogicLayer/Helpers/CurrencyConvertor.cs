using System.Collections.Generic;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers
{
    public static class CurrencyConvertor
    {
        private static readonly Dictionary<CurrencyType, decimal> _convertor = new Dictionary<CurrencyType, decimal>()
        {
            { CurrencyType.GBP, (decimal)0.7 },
            { CurrencyType.EUR, (decimal)0.8 },
            { CurrencyType.CHF, (decimal)1.0 },
            { CurrencyType.JPY, (decimal)2.3 },
            { CurrencyType.UAH, (decimal)25.0 },
            { CurrencyType.USD, (decimal)1.0 }
        
        };

        public static decimal Convertor(CurrencyType from,CurrencyType to, decimal price)
        {
            var current = price / _convertor[from] * _convertor[to];
            return price / _convertor[from] * _convertor[to];
        }
    }
}
