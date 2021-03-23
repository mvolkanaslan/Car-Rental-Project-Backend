using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            //Bu  iş kuralını exeption a dahil ettikten sonra business rule aktaracağım şimdilik deneme sağlasın diye burada
            var result = _rentalDal.GetAll();
            if (result.Where(r => r.CarId == rental.CarId && r.ReturnDate == null).Any())
                    return new ErrorResult(Messages.RentalInValid);
            else if (result.Where(r=> r.CarId == rental.CarId 
                    && r.ReturnDate.Value.Ticks>rental.RentDate.Ticks
                    && r.RentDate.Ticks < rental.ReturnDate.Value.Ticks).Any())
                    return new ErrorResult(Messages.RentalInValid);

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalValid);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeleteMsg);
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.ListMsg);
        }
        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(r=>r.Id==id),Messages.ListMsg);
        }
        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),Messages.ListMsg);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            return new SuccessResult(Messages.UpdateMsg);
        }
    }
}
