using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors
{
    public static class AuthorsMapping
    {
        public static Author Map(this AuthorModelItem author)
        {
            var authorModelItem = new Author
            {
                Name = author.Name,
                Id = author.Id,
            };
            return authorModelItem;
        }


        public static AuthorModelItem Map(this Author author)
        {
            var authorModelItem = new AuthorModelItem
            {
                Name = author.Name,
                Id = author.Id,
            };
            authorModelItem.BooksTitle = new List<string>();
            foreach (var item in author.PrintingEditions)
            {
                authorModelItem.BooksTitle.Add(item.Title);
            }
            return authorModelItem;
        }

        public static AuthorModel Map(this IEnumerable<Author> authors)
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
            //author.PrintingEditions = new Models.PrintingEditions.PrintingEditionModel();
            //for (int i = 0; i < authorModelItem.printingEditions.Count; i++)
            //{
            //    author.PrintingEditions.Items.Add(PrintingEditionMaping.Map(authorModelItem.printingEditions[i]));
            //}
            return author;
        }
    }
}

