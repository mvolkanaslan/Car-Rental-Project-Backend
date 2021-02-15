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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2 || user.LastName.Length<2) 
            {
                return new ErrorResult(Messages.AddErrorMsg);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.Add_Msg);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.DeleteMsg);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.ListMsg);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.GetById(u=>u.Id==id), Messages.ListMsg);
        }

        public IResult Update(User user)
        {
            return new SuccessResult(Messages.UpdateMsg);
        }
    }
}
