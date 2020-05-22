using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyBackEnd.Bussiness.Conctants;
using MyBackEnd.Core.Extensions;
using MyBackEnd.Core.Utilities.Interceptors;
using MyBackEnd.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Bussiness.BussinessAspect.AutoFac
{
    public class SecurityOperation:MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;


        public SecurityOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation ınvocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var item in _roles)
            {
                if (roleClaims.Contains(item))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthDenied);
        }
    }
}
