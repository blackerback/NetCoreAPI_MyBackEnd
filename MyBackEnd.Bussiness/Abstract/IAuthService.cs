using MyBackEnd.Core.Entities.Concrete;
using MyBackEnd.Core.Utilities.Results;
using MyBackEnd.Core.Utilities.Security.Jwt;
using MyBackEnd.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Bussiness.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto,string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
