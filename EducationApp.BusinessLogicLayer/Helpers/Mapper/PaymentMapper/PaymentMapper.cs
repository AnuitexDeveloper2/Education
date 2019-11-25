using EducationApp.BusinessLogicLayer.Models.Payments;
using EducationApp.DataAccessLayer.Entities;
using System;

namespace EducationApp.BusinessLogicLayer.Helpers.Mapper.PaymentMapper
{
    public static class PaymentMapper
    {
        public static Payment Map(PaymentsModel paymentsModel)
        {
            var payment = new Payment
            {
                TransactionId = paymentsModel.TransactionId,
                Date = DateTime.Now,
                Id = paymentsModel.Id
                
            };
            return payment;
        }
       
    }
}
