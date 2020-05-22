using Castle.DynamicProxy;
using MyBackEnd.Core.CrossCuttingConcerns.Caching;
using MyBackEnd.Core.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using MyBackEnd.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyBackEnd.Core.Aspects.AutoFac.Caching
{
    public class CacheAspect:MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration=60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",",arguments.Select(i=>i?.ToString()??"<Null>"))})";
            
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
            base.Intercept(invocation);
        }
    }
}
