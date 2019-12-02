using EducationApp.BusinessLogicLayer.Extention.Author;
using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors
{
    public static class AuthorsMapper
    {
        public static Author Map(this AuthorModelItem author)
        {
            var authorModelItem = new Author
            {
                Name = author.Name,
                Id = author.Id,
                Date = DateTime.Now
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

        public static AuthorModel Map(this IEnumerable<Author> authors)
        {
            AuthorModel authorsModel = new AuthorModel();
            foreach (var item in authors)
            {
                authorsModel.Items.Add(Map(item));
            }
            return authorsModel;
        }

        public static DataAccessLayer.Helpers.Author.AuthorFilterModel Map(AuthorFilterModel authorFilterModel)
        {
            var resultModel = new DataAccessLayer.Helpers.Author.AuthorFilterModel
            {
                SortType = (DataAccessLayer.Entities.Enums.Enums.SortType)authorFilterModel.SortType,
                PageNumber = authorFilterModel.PageNumber,
                PageSize = authorFilterModel.PageSize,
                SearchString = authorFilterModel.SearchString
            };
            return resultModel;
        }
    }
}

