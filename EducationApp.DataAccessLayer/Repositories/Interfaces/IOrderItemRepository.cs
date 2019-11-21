using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Ropositories.Interfaces
{
    public interface IOrderItemRepository :IBaseEFRRepository<OrderItems>
    {
    }
}
