using MyBackEnd.Core.Entities.Concrete;
using MyBackEnd.Core.Utilities.Results;
using MyBackEnd.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Bussiness.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetList();
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<OperationClaims>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
    }
}
