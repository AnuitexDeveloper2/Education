﻿using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.AuthorInPrintingEditionMapper
{
    public static class AuthorInPrintingEditionMapper
    {
        public static List<AuthorInPrintingEdition> Map(long printingEditionId,ICollection< AuthorModelItem> authors)
        {
            var result = new List<AuthorInPrintingEdition>();
            foreach (var item in authors)
            {
                var authorInPrintingEdition = new AuthorInPrintingEdition { AuthorId = item.Id, PrintingEditionId = printingEditionId };
                result.Add(authorInPrintingEdition);
            }
            return result;
        }
    }
}
