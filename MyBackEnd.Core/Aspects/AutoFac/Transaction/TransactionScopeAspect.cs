using Castle.DynamicProxy;
using MyBackEnd.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MyBackEnd.Core.Aspects.AutoFac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transaction.Complete();
                }
                catch (System.Exception)
                {

                    transaction.Dispose();
                }
            }
        }
    }
}
