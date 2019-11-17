using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors
{
    public static class AuthorsMapping
    {

        public static Author Map(this AuthorsModelItem authorModelItem)
        {
            var author = new Author
            {
                Name = authorModelItem.Name,
                Id = authorModelItem.Id,
                IsRemoved = authorModelItem.IsRemoved
            };
            return author;
        }

        public static AuthorsModelItem Map(this Author author)
        {
            var authorModelItem = new AuthorsModelItem
            {
                Name = author.Name,
                Id = author.Id,
                IsRemoved = author.IsRemoved
            };
            return authorModelItem;
        }

        public static List<AuthorsModelItem> Map(this List<Author> authors)
        {
            List<AuthorsModelItem> authorsModel = new List<AuthorsModelItem>();
            foreach (var item in authors)
            {
                authorsModel.Add(Map(item));
            }
            return authorsModel;
        }
    }
}

