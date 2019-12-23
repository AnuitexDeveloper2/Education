using EducationApp.BusinessLogicLayer.Models.Authors;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.PrintingEditions
{
    public class PrintingEditionModelItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CurrencyType Currency { get; set; }
        public ProductType Type { get; set; }
        public AuthorModel Authors { get; set; }

    }
}
