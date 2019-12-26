using EducationApp.BusinessLogicLayer.Extention.Author;

namespace EducationApp.BusinessLogicLayer.Extention.Mapper.AuthorMapper
{
    public static partial class AuthorMapper
    {
        public static DataAccessLayer.Helpers.Author.AuthorFilterModel Map(this AuthorFilterModel authorFilterModel)
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
