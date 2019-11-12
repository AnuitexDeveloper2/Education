using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Extention.BaseFilter
{

    public class FilterBase<TEntity>
    {
        public IQueryable<TEntity> Result { get; set; }

        public void FilterContains(Expression<Func<TEntity, string>> by, string text)
        {
            
        }
    }
}
