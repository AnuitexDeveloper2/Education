﻿using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Models.Base;
using System;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;

namespace EducationApp.DataAccessLayer.Models
{
    public class OrderModel : BaseFilterModel<OrderModel>
    {
        public long Id { get; set; }
        public List<PrintingEdition> PrintingEdition { get; set; } //todo chenge this model
        //public TypeProduct TypeProduct { get; set; }
        public List<string> Title { get; set; }
        public decimal Amount { get; set; }
        public int CountOrdersModel { get; set; }
        public StatusType Status { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public DateTime DateTime { get; set; }
    }
}
