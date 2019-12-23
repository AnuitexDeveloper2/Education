using EducationApp.BusinessLogicLayer.Extention.Author;
using EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors;
using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Models.Base;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System.Threading.Tasks;
using errors = EducationApp.BusinessLogicLayer.Common.Consts.Consts.Errors;
using EducationApp.BusinessLogicLayer.Extention.Mapper.AuthorMapper;
using EducationApp.DataAccessLayer.Entities;
using System;

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

        public async Task<BaseModel> CreateAsync(string name)
        {
            var resultModel = new BaseModel();

            if (name == null)
            {
                resultModel.Errors.Add(errors.EmptyField);
                return resultModel;
            }

            var author = new Author { Name = name, Date = DateTime.Now };

            var resultCreate = await _authorRepository.CreateAsync(author);

            if (resultCreate < 1)
            {
                resultModel.Errors.Add(errors.AuthorCreate);
            }

            return resultModel;
        }

        public async Task<BaseModel> UpdateAsync(long id,string name)
        {
            var resultModel = new BaseModel();

            if (name == null)
            {
                resultModel.Errors.Add(errors.EmptyField);
                return resultModel;
            }

            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
            {
                resultModel.Errors.Add(errors.AuthorNotFound);
                return resultModel;
            }
            author.Name = name;
            var wasUpdateAuthor = await _authorRepository.UpdateAsync(author);

            if (!wasUpdateAuthor)
            {
                resultModel.Errors.Add(errors.AuthorUpdate);
            }

            return resultModel;
        }

        public async Task<BaseModel> RemoveAsync(long id)
        {
            var resultModel = new BaseModel();

            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
            {
                resultModel.Errors.Add(errors.AuthorNotFound);
                return resultModel;
            }

            var hasRemoved = await _authorRepository.MarkRemoveAsync(author);

            if (!hasRemoved)
            {
                resultModel.Errors.Add(errors.AuthorRemove);
                return resultModel;
            }

            hasRemoved = await _authorInPrintingEditionRepository.RemoveRangeAsync(x => x.AuthorId == author.Id);

            if (!hasRemoved)
            {
                resultModel.Errors.Add(errors.PIRemove);
            }

            return resultModel;
        }



        public async Task<AuthorModel> GetAuthorsAsync(AuthorFilterModel authorFilterModel)
        {
            var filter = authorFilterModel.Map();

            var authors = await _authorRepository.GetAuthorsAsync(filter);

            var authorsModel = new AuthorModel();

            if (authors == null)
            {
                authorsModel.Errors.Add(errors.AuthorNotFound);
                return authorsModel;
            }

            for (int i = 0; i < authors.Data.Count; i++)
            {
                authorsModel.Items.Add(authors.Data[i].Map());
            }

            authorsModel.Count = authors.Count;

            return authorsModel;
        }

        public async Task<AuthorModel> GetAll()
        {
            var resultModel = new AuthorModel();

            var authors = await _authorRepository.GetAllAsync();

            foreach (var item in authors)
            {
                resultModel.Items.Add(item.Map());
            }
            return resultModel;
        }
    }
}
