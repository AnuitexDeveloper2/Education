using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Models.Orders
{
    public class OrdersPresentationModel
    {
        public ICollection<OrdersPresentationModelItem> Items { get; set; }
        public int Count { get; set; }
    }
}
