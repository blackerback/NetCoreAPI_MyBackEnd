using MyBackEnd.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyBackEnd.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaims> operationClaims);
    }
}
