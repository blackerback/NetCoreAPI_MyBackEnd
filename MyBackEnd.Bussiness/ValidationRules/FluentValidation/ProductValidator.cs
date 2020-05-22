using FluentValidation;
using MyBackEnd.Bussiness.Conctants;
using MyBackEnd.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Bussiness.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(i => i.ProductName).NotEmpty().WithMessage(Messages.ProductName);
            //RuleFor(i => i.ProductName).Must(StartWitnWithA);
        }

        private bool StartWitnWithA(string word)
        {
            return word.StartsWith("A");
        }
    }
}
