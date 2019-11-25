using EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors;
using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Helpers.Author;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System.Threading.Tasks;
using errors = EducationApp.BusinessLogicLayer.Common.Consts.Consts.Errors;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        public AuthorService(IAuthorRepository authorRepository,IAuthorInPrintingEditionRepository authorInPrintingEditionRepository)
        {
            _authorRepository = authorRepository;
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
        }

        public async Task<BaseModel> CreateAsync(AuthorModelItem authorModelItem)
        {
            var resultModel = new BaseModel();
            var author = AuthorsMapping.Map(authorModelItem);
            var result = await _authorRepository.CreateAsync(author);
            if (result < 1)
            {
                resultModel.Errors.Add(errors.AuthorCreate);
            }
            return resultModel;
        }

        public async Task<BaseModel> UpdateAsync(long id)
        {
            var resultModel = new BaseModel();
            var author = await _authorRepository.FindByIdAsync(id);
            if (author == null)
            {
                resultModel.Errors.Add(errors.AuthorNotFound);
                return resultModel;
            }
            var result = await _authorRepository.UpdateAsync(author);
            if (!result)
            {
                resultModel.Errors.Add(errors.AuthorUpdate);
            }
            return resultModel;
        }

        public async Task<BaseModel> RemoveAsync(long id)
        {
            var resultModel = new BaseModel();
            var excistAuthor = await _authorRepository.FindByIdAsync(id);
            if (excistAuthor == null)
            {
                resultModel.Errors.Add(errors.AuthorNotFound);
                return resultModel;
            }
            var removeAuthor = await _authorRepository.RemoveAsync(excistAuthor); //todo rename to result
            if (!removeAuthor)
            {
                resultModel.Errors.Add(errors.AuthorRemove);
                return resultModel;
            }
            var removeAIP = await _authorInPrintingEditionRepository.RemoveByAuthorId(id); //todo rename
            if (!removeAIP)
            {
                resultModel.Errors.Add(errors.PIRemove);
            }
            return resultModel;
        }

        public async Task<AuthorModel> GetAuthorsAsync(AuthorFilterModel authorFilterModel)
        {
            var authors = await _authorRepository.GetAuthorsAsync(authorFilterModel);
            var authorsModel = new AuthorModel();
            for (int i = 0; i < authors.Count; i++)
            {
                authorsModel.Items.Add(AuthorsMapping.Map(authors.Data[i]));
            }
            return authorsModel;
        }
    }
}
