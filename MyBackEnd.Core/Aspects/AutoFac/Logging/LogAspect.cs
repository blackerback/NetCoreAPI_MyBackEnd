using Castle.DynamicProxy;
using log4net.Repository.Hierarchy;
using MyBackEnd.Core.CrossCuttingConcerns.Logging;
using MyBackEnd.Core.CrossCuttingConcerns.Logging.Log4Net;
using MyBackEnd.Core.Utilities.Interceptors;
using MyBackEnd.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBackEnd.Core.Aspects.AutoFac.Logging
{
    public class LogAspect:MethodInterception
    {
        LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType!=typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLogType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation ınvocation)
        {
            _loggerServiceBase.Info(GetLogDetail(ınvocation));
        }

        private LogDetail GetLogDetail(IInvocation ınvocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < ınvocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter 
                {
                    Name=ınvocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value=ınvocation.Arguments[i],
                    Type=ınvocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new LogDetail() 
            {
                MethodName=ınvocation.Method.Name,
                LogParameters=logParameters
            };

            return logDetail;
        }
    }
}
