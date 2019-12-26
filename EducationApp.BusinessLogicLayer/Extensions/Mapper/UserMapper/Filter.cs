namespace EducationApp.BusinessLogicLayer.Extention.Mapper.UserMapper
{
    public static partial class UserMapper
    {
        public static DataAccessLayer.Helpers.UserFilterModel Map(this Extention.User.UserFilterModel filterUser)
        {
            var userFilter = new DataAccessLayer.Helpers.UserFilterModel
            {
                SortType = (DataAccessLayer.Entities.Enums.Enums.SortType)filterUser.SortType,
                ColumnType = (DataAccessLayer.Entities.Enums.Enums.UsersSortType)filterUser.UserSortType,
                FilterType = (DataAccessLayer.Entities.Enums.Enums.UserFilterType)filterUser.UserFilterStatus,
                PageNumber = filterUser.PageNumber,
                PageSize = filterUser.PageSize,
                SearchString = filterUser.SearchString

            };
            return userFilter;

        }
    }
}
