using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Core.Utilities.Interceptors
{
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation ınvocation) { }

        protected virtual void OnAfter(IInvocation ınvocation) { }

        protected virtual void OnException(IInvocation ınvocation,System.Exception e) { }

        protected virtual void OnSuccess(IInvocation ınvocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var issuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                issuccess = false;
                OnException(invocation,e);
                throw e;
            }
            finally
            {
                if (issuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
