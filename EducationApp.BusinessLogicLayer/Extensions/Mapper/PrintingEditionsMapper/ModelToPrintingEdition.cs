using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using System;
using EducationApp.DataAccessLayer.Entities;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
using System.Collections.Generic;
using EducationApp.BusinessLogicLayer.Models.Authors;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping
{
    public static partial class PrintingEditionMapper
    {
        public static PrintingEdition Map(this PrintingEditionModelItem model)
        {
            var printingEdition = new PrintingEdition
            {
                Date = DateTime.Now,
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                ProductType = (TypeProduct)model.Type,
                Authors = Map(model.Authors)
            };
            return printingEdition;
        }

        private static List<Author> Map(AuthorModel authorModel)
        {
            var authors = new List<Author>();
            foreach (var item in authorModel.Items)
            {
                var author = new Author();
                author.Name = item.Name;
                authors.Add(author);
            }
            return authors;
        }

    }

}
