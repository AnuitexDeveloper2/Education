using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.DataAccessLayer.Entities;
using System;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors
{
    public static partial class AuthorMapper
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
    }
}

