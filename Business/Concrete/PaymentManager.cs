using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   
    public class PaymentManager : IPaymentService
    {
        public IResult IsPaymentValid(Payment payment)
        {
            /*
            if( payment.CardNumber==FakeCard.CardNUmber
                && payment.MounthOfExp==FakeCard.MounthOfExp
                && payment.YearOfExp==FakeCard.YearOfExp
                && payment.CVV==FakeCard.CVV
                && payment.Amount <= FakeCard.Amount)
            {
                return new SuccessResult(Messages.PaymentSuccessful);
            }

          return new ErrorResult(Messages.PaymentUnSeccessful);
            */

            return new SuccessResult(Messages.PaymentSuccessful);
        }
    }
}
