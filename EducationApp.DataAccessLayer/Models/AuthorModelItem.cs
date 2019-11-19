using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationApp.DataAccessLayer.Models
{
    public class AuthorModelItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PrintingEdition> printingEditions { get; set; }
    }
}
