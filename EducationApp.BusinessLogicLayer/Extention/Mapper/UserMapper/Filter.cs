namespace EducationApp.BusinessLogicLayer.Extention.Mapper.UserMapper
{
    public static partial class UserMapper
    {
        public static DataAccessLayer.Helpers.UserFilterModel Map(this Extention.User.UserFilterModel filterUser)
        {
            var userFilter = new DataAccessLayer.Helpers.UserFilterModel
            {
                SortType = (DataAccessLayer.Entities.Enums.Enums.SortType)filterUser.SortType,
                UsersSortType = (DataAccessLayer.Entities.Enums.Enums.UserSortType)filterUser.UserSortType,
                UsersFilterType = (DataAccessLayer.Entities.Enums.Enums.UserFilterType)filterUser.UsersFilterStatus,
                PageNumber = filterUser.PageNumber,
                PageSize = filterUser.PageSize,
                SearchString = filterUser.SearchString

            };
            return userFilter;

        }
    }
}
