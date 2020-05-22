using MyBackEnd.Bussiness.Abstract;
using MyBackEnd.Bussiness.Conctants;
using MyBackEnd.Core.Entities.Concrete;
using MyBackEnd.Core.Utilities.Results;
using MyBackEnd.Core.Utilities.Security.Hashing;
using MyBackEnd.Core.Utilities.Security.Jwt;
using MyBackEnd.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Bussiness.Concrete
{
    public class AuthService : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthService(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            try
            {
                var claims = _userService.GetClaims(user).Data;
                var accessToken=_tokenHelper.CreateToken(user,claims==null?new List<OperationClaims>():claims);
                return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreater);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<AccessToken>(exception.Message);
            }
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            try
            {
                var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;

                if (userToCheck==null)
                    return new ErrorDataResult<User>(Messages.UserNotFound);

                if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                    return new ErrorDataResult<User>(Messages.UserPasswordError);

                return new SuccessDataResult<User>(userToCheck,Messages.SuccessLogin);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<User>(exception.Message);
            }
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password,out passwordHash,out passwordSalt);

                var user = new User { Email = userForRegisterDto.Email, FirstName = userForRegisterDto.
                    FirstName, LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash, PasswordSalt = passwordSalt,Status = true };

                _userService.Add(user);

                return new SuccessDataResult<User>(user,Messages.SuccessUserAdded);

            }
            catch (Exception exception)
            {

                return new ErrorDataResult<User>(exception.Message);
            }
        }

        public IResult UserExists(string email)
        {
            try
            {
                if (_userService.GetByMail(email).Data != null)
                    return new ErrorResult(Messages.UserAlready);
                return new SuccessResult();
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
        }
    }
}
