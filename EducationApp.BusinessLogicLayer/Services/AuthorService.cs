using EducationApp.BusinessLogicLayer.Helpers.Mapping.Authors;
using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Ropositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }


        public async Task<bool> CreateAsync(AuthorsModelItem authorModelItem)
        {
            var author = AuthorsMapping.Map(authorModelItem);
            var result = await _authorRepository.CreateAsync(author);
            return result;
        }

        public async Task<bool> UpdateAsync(AuthorsModelItem authorModelItem)
        {
            var author = AuthorsMapping.Map(authorModelItem);
            var result = await _authorRepository.UpdateAsync(author);
            return result;
        }

        public async Task<bool> RemoveAsync(AuthorsModelItem authorModelItem)
        {
            var printingEdition = AuthorsMapping.Map(authorModelItem);
            var excist = await _authorRepository.FindByIdAsync(printingEdition.Id);
            if (excist == null)
            {
                return false;
            }
            var result = await _authorRepository.RemoveAsync(excist);
            return result;
        }

        public async Task<AuthorsModelItem> GetByIdAsync(long id)
        {
            var author = await _authorRepository.FindByIdAsync(id);
            return AuthorsMapping.Map(author);
        }


        public async Task<List<AuthorsModelItem>> GetAuthors()
        {
            var authors = _authorRepository.GetAll();
            List<AuthorsModelItem> authorsModelItems = new List<AuthorsModelItem>();
            for (int i = 0; i < authors.Count; i++)
            {
                authorsModelItems.Add(AuthorsMapping.Map(authors[i]));
            }
            return authorsModelItems;
        }
    }
}
