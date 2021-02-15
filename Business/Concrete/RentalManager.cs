using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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

        public IResult Add(Rental rental)
        {
            //Rentals tablosunda istenen araç var mı ve teslim edilmiş mi.
            if (_rentalDal.GetAll().Exists(r => r.CarId == rental.CarId && r.ReturnDate == null))
            {
                return new ErrorResult(Messages.RentalInValid);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalValid);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeleteMsg);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.ListMsg);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(r=>r.CarId==id),Messages.ListMsg);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),Messages.ListMsg);
        }

        public IResult Update(Rental rental)
        {
            return new SuccessResult(Messages.UpdateMsg);
        }
    }
}
