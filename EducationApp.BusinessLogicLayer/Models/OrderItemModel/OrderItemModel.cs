using EducationApp.BusinessLogicLayer.Models.Base;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Models.OrderItemModelItem
{
    public class OrderItemModel : BaseModel 
    {
        public ICollection<OrderItemModelItem> Items { get; set; } = new List<OrderItemModelItem>();
    }
}
