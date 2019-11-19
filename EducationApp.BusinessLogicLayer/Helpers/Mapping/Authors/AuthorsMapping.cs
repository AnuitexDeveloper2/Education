using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors
{
    public static class AuthorsMapping
    {

        public static Author Map(this AuthorModelItem authorModelItem)
        {
            var author = new Author
            {
                Name = authorModelItem.Name,
                Id = authorModelItem.Id,
            };
            return author;
        }

        public static AuthorModelItem Map(this Author author)
        {
            var authorModelItem = new AuthorModelItem
            {
                Name = author.Name,
                Id = author.Id,
                IsRemoved = author.IsRemoved
            };
            return authorModelItem;
        }

        public static AuthorModel Map(this List<Author> authors)
        {
            AuthorModel authorsModel = new AuthorModel();
            foreach (var item in authors)
            {
                authorsModel.Items.Add(Map(item));
            }
            return authorsModel;
        }

        public static AuthorModelItem Map(this DataAccessLayer.Models.AuthorModelItem authorModelItem)
        {
            var author = new AuthorModelItem
            {
                Name = authorModelItem.Name,
                Id = authorModelItem.Id,
            };
            author.PrintingEditions = new Models.PrintingEditions.PrintingEditionModel();
            for (int i = 0; i < authorModelItem.printingEditions.Count; i++)
            {
                author.PrintingEditions.Items.Add(PrintingEditionMaping.Map(authorModelItem.printingEditions[i]));
            }
            return author;
        }
    }
}

