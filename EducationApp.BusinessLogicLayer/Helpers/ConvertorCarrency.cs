using System.Collections.Generic;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Helpers
{
    public class ConvertorCarrency
    {
        private readonly Dictionary<CurrencyType, decimal> _convertor = new Dictionary<CurrencyType, decimal>();

        private void ConvertorAdd()
        {
            _convertor.Add(CurrencyType.GBP, (decimal)1.4);
            _convertor.Add(CurrencyType.EUR, (decimal)1.2);
            _convertor.Add(CurrencyType.CHF, (decimal)12.5);
            _convertor.Add(CurrencyType.JPY, (decimal)2.3);
            _convertor.Add(CurrencyType.UAH, (decimal)25.0);
            _convertor.Add(CurrencyType.USD, (decimal)1.0);
        }

        public decimal Convertor(CurrencyType currencyType,decimal price)
        {
            ConvertorAdd();
            return price * _convertor[currencyType];
        }
    }
}
