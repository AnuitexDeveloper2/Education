using EducationApp.BusinessLogicLayer.Models.Payments;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapper.OrderMapper
{
    public static class OrderMapper
    {
        public static Order Map(PaymentsModel paymentModel,long id)
        {
            var order = new Order
            {
                Description = paymentModel.Description,
                PaymentId = id,
                UserId = paymentModel.UserId
            };
            return order;
        }
    }
}
