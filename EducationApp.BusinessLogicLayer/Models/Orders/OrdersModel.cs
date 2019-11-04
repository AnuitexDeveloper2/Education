using EducationApp.BusinessLogicLayer.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.Orders
{
    public class OrdersModel : BaseModel
    {
        public ICollection<OrderItemModel> Items = new List<OrderItemModel>();

    }
}
