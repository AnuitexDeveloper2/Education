﻿using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.DataAccessLayer.Helpers.Author;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorService 
    {
        Task<BaseModel> CreateAsync(AuthorModelItem authorModelItem);
        Task<BaseModel> UpdateAsync(long id);
        Task<BaseModel> RemoveAsync(long id);
        Task<AuthorModel> GetAuthorsAsync(AuthorFilterModel authorFilterModel);
    }
}
