using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return new SuccessResult();
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<List<CreditCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(p => p.CustomerId == customerId));
        }

        public IDataResult<CreditCard> GetById(int Id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.Id == Id));
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        public IResult CheckCreditCardExist(CreditCard creditCard) 
        {
            var result = _creditCardDal.GetAll(p => p.CustomerId == creditCard.CustomerId);
            if(!result.Any())
            {
                return new ErrorResult(Messages.NotExist);
            }else if(!result.Where(p=>p.CreditCardNumber==creditCard.CreditCardNumber &&
            p.ExpirationDate==creditCard.ExpirationDate && p.SecurityCode==creditCard.SecurityCode).Any())
            {
                return new ErrorResult(Messages.CreditCardError);
            }
            return new SuccessResult();
        }

        
    }
}
