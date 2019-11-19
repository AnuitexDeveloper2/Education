using EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors;
using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Helpers.Author;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicLayer.Common.Consts.Consts.Errors;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<BaseModel> CreateAsync(AuthorModelItem authorModelItem)
        {
            var authorModel = new BaseModel();
            var author = AuthorsMapping.Map(authorModelItem);
            var result = await _authorRepository.CreateAsync(author);
            if (result < 1)
            {
                authorModel.Errors.Add(AuthorCreate);
                return authorModel;
            }
            return authorModel;
        }

        public async Task<BaseModel> UpdateAsync(AuthorModelItem authorModelItem)
        {
            var resultModel = new BaseModel();
            var author = AuthorsMapping.Map(authorModelItem);
            var result = await _authorRepository.UpdateAsync(author);
            if (!result)
            {
                resultModel.Errors.Add(AuthorUpdate);
            }
            return resultModel;
        }

        public async Task<BaseModel> RemoveAsync(AuthorModelItem authorModelItem)
        {
            var resultModel = new BaseModel();
            var author = AuthorsMapping.Map(authorModelItem);
            var excistAuthor = await _authorRepository.FindByIdAsync(author.Id);
            if (excistAuthor == null)
            {
                resultModel.Errors.Add(AuthorNotFound);
                return resultModel;
            }
            var result = await _authorRepository.RemoveAsync(excistAuthor);
            if (!result)
            {
                resultModel.Errors.Add(AuthorRemove);
            }
            return resultModel;
        }

        public async Task<AuthorModel> GetAuthors(AuthorFilterModel authorFilterModel)
        {
            var authors = _authorRepository.GetAuthors(authorFilterModel);
            AuthorModel authorsModel = new AuthorModel();
            for (int i = 0; i < authors.Count; i++)
            {
                authorsModel.Items.Add(AuthorsMapping.Map(authors[i]));
            }
            return authorsModel;
        }
    }
}
