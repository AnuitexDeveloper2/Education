﻿using System;
using static EducationApp.BusinessLogicLayer.Models.Enums.Enums;

namespace EducationApp.BusinessLogicLayer.Models.Orders
{
    public class OrdersPresentationModelItem
    {
        public long Id { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public decimal Amount { get; set; }
        public int CountOrdersModel { get; set; }
        public string Title { get; set; }
        public  OrderStatusType OrderStatusType { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public DateTime DateTime { get; set; }
    }
}