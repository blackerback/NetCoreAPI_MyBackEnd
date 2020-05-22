using Castle.DynamicProxy;
using FluentValidation;
using MyBackEnd.Core.CrossCuttingConcerns.Valition;
using MyBackEnd.Core.Utilities.Interceptors;
using MyBackEnd.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBackEnd.Core.Aspects.AutoFac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation ınvocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var parameters = ınvocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var item in parameters)
            {
                ValidationTool.Validate(validator, item);
            }
        }
    }
}
