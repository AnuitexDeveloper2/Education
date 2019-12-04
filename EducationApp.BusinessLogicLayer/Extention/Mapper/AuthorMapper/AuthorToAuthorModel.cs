using EducationApp.BusinessLogicLayer.Models.Authors;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Extention.Mapper.AuthorMapper
{
    public static class AuthorMaper
    {

        public static AuthorModel Map(IEnumerable<DataAccessLayer.Entities.Author> authors)
        {
            AuthorModel authorsModel = new AuthorModel();
            foreach (var item in authors)
            {
                authorsModel.Items.Add(Map(item));
            }
            return authorsModel;
        }

        public static AuthorModelItem Map(this DataAccessLayer.Entities.Author author)
        {
            var authorModelItem = new AuthorModelItem
            {
                Name = author.Name,
                Id = author.Id,
            };
            if (author.PrintingEditions == null)
            {
                return authorModelItem;
            }
            authorModelItem.BookTitles = new List<string>();
            foreach (var item in author.PrintingEditions)
            {
                authorModelItem.BookTitles.Add(item.Title);
            }
            return authorModelItem;
        }

    }
}
