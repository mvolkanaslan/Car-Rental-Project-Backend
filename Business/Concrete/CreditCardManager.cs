using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
        public class CreditCardManager : ICreditCardService
        {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.Add_Msg);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.DeleteMsg);
        }

        public IDataResult<List<CreditCard>> GetByCustomerId(int id)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c=>c.CustomerId==id),Messages.ListMsg);
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.GetById(c => c.CustomerId == id), Messages.ListMsg);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.UpdateMsg);
        }
    }
}
