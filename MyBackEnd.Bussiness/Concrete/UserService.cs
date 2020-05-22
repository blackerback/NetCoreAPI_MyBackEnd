using MyBackEnd.Bussiness.Abstract;
using MyBackEnd.Bussiness.Conctants;
using MyBackEnd.Core.Entities.Concrete;
using MyBackEnd.Core.Utilities.Results;
using MyBackEnd.DataAccess.Abstract;
using MyBackEnd.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBackEnd.Bussiness.Concrete
{
    public class UserService : IUserService
    {
        IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.SuccessUserAdded);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
        }

        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.SuccessUserDeleted);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
        }

        public IDataResult<User> GetById(int userId)
        {
            try
            {
                var result = _userDal.Get(i=>i.Id==userId);
                return new SuccessDataResult<User>(result);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<User>(exception.Message);
            }
        }

        public IDataResult<User> GetByMail(string email)
        {
            try
            {
                var result = _userDal.Get(i => i.Email.ToLower()==email.ToLower());
                return new SuccessDataResult<User>(result);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<User>(exception.Message);
            }
        }

        public IDataResult<List<OperationClaims>> GetClaims(User user)
        {
            try
            {
                var result=_userDal.GetClaims(user);
                return new SuccessDataResult<List<OperationClaims>>(result);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<OperationClaims>>(exception.Message);
            }
        }

        public IDataResult<List<User>> GetList()
        {
            try
            {
                var result = _userDal.GetList().ToList();
                return new SuccessDataResult<List<User>>(result);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<User>>(exception.Message);
            }
        }

        public IResult Update(User user)
        {
            try
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.SuccessUserDeleted);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
        }
    }
}
