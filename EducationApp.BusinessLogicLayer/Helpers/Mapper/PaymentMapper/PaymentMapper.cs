using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapper.PaymentMapper
{
    public static class PaymentMapper
    {
        public static Payment Map(long id)
        {
            var payment = new Payment
            {
                TransactionId = id
            };
            return payment;
        }
    }
}
