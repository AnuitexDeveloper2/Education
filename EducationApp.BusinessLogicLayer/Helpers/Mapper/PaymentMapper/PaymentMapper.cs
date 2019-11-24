using EducationApp.DataAccessLayer.Entities;
using System;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapper.PaymentMapper
{
    public static class PaymentMapper
    {
        public static Payment Map(long id)
        {
            var payment = new Payment
            {
                TransactionId = id,
                Date = DateTime.Now
            };
            return payment;
        }
    }
}
