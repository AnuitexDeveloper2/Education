using EducationApp.DataAccessLayer.Entities;
using System.Linq;
using static EducationApp.DataAccessLayer.Entities.Enums.Enums;
using System.Linq.Dynamic.Core;

namespace EducationApp.DataAccessLayer.Extention
{
    public static  class Extention
    {
        public static IQueryable<TEntity> Sorting<TEntity>(this IQueryable<PrintingEdition> printingEdition, IQueryable<TEntity> entities, string entitySortType, SortType sortType) 
        {
            var property = typeof(TEntity).GetProperty(entitySortType);
            entities = sortType == SortType.Asc ? entities.OrderBy(property.Name) : entities.OrderBy(property.Name + " descending");
            return entities;
        }
    }
}
