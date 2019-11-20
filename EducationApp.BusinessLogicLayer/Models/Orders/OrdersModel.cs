using EducationApp.BusinessLogicLayer.Models.Base;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Models.Orders
{
    public class OrdersModel : BaseModel
    {
        public ICollection<OrdersItemModel> Items = new List<OrdersItemModel>();

    }
}
