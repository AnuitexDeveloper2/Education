using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Models.Users;
using System;
using System.Collections.Generic;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.PrintingEditions
{
    public class PrintingEditionModelItem
    {
        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } //todo fix
        public decimal Price { get; set; }
        public CurrencyType Currency { get; set; } //todo rename prop Currency
        public ProductType Type { get; set; } //todo public ProductType Type { get; set; }
        public DateTime Date { get; set; }
        public AuthorModel Authors { get; set; }

    }
}
