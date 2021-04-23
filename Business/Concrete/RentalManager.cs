using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        ICustomerService _customerService;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal,ICustomerService customerService,ICarService carService)
        {
            _rentalDal = rentalDal;
            _customerService = customerService;
            _carService = carService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(IsRentable(rental));
            if (result != null)
            {
                return result;
            }
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

        public IResult IsRentable(Rental rental)
        {
            
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId
                    && r.ReturnDate >= rental.RentDate
                    && r.RentDate <= rental.ReturnDate).Any();
            if (result)
                return new ErrorResult(Messages.RentalInValid);
            return new SuccessResult(Messages.CarIsRentable);
        }
        public IResult CheckFindexScore(int customerId, int carId)
        {
            var userFindexScore = _customerService.GetById(customerId).Data.FindexScore;
            var carFindexScore = _carService.GetById(carId).Data.FindexScore;
            if (carFindexScore <= userFindexScore)
            {
                return new SuccessResult("Insufficient FindexScore");
            }
            return new ErrorResult("Your Findex Score are Insufficient to Rent This Car");
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            return new SuccessResult(Messages.UpdateMsg);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCustomerId(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CustomerId == id), Messages.ListMsg);
        }
    }
}
