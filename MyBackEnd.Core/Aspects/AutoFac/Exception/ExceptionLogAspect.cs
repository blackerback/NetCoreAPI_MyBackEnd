using Castle.DynamicProxy;
using log4net.Repository.Hierarchy;
using MyBackEnd.Core.CrossCuttingConcerns.Logging;
using MyBackEnd.Core.CrossCuttingConcerns.Logging.Log4Net;
using MyBackEnd.Core.Utilities.Interceptors;
using MyBackEnd.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Core.Aspects.AutoFac.Exception
{
    public class ExceptionLogAspect:MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        
        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType!=typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLogType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnException(IInvocation ınvocation,System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(ınvocation);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation ınvocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < ınvocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = ınvocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = ınvocation.Arguments[i],
                    Type = ınvocation.Arguments[i].GetType().Name
                });
            }

            var logDetailException = new LogDetailWithException 
            {
                MethodName=ınvocation.Method.Name,
                LogParameters=logParameters
            };

            return logDetailException;
        }
    }
}
