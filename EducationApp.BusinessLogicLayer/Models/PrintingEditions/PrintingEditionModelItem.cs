
using EducationApp.BusinessLogicLayer.Models.Authors;
using System;
using System.Collections.Generic;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.PrintingEditions
{
    public class PrintingEditionModelItem
    {
        public string Author { get; set; }
        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public string Title { get; set; }
        public string Desccription { get; set; }
        public decimal Price { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public DateTime Date { get; set; }
        public List<AuthorsModelItem> Authors { get; set; }

    }
}
