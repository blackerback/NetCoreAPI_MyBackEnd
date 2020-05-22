using Autofac.Core;
using Microsoft.AspNetCore.Http;
using MyBackEnd.Bussiness.Abstract;
using MyBackEnd.Bussiness.BussinessAspect.AutoFac;
using MyBackEnd.Bussiness.Conctants;
using MyBackEnd.Bussiness.ValidationRules.FluentValidation;
using MyBackEnd.Core.Aspects.AutoFac.Caching;
using MyBackEnd.Core.Aspects.AutoFac.Exception;
using MyBackEnd.Core.Aspects.AutoFac.Logging;
using MyBackEnd.Core.Aspects.AutoFac.Performance;
using MyBackEnd.Core.Aspects.AutoFac.Transaction;
using MyBackEnd.Core.Aspects.AutoFac.Validation;
using MyBackEnd.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using MyBackEnd.Core.CrossCuttingConcerns.Valition;
using MyBackEnd.Core.Utilities.Bussiness;
using MyBackEnd.Core.Utilities.IoC;
using MyBackEnd.Core.Utilities.Results;
using MyBackEnd.DataAccess.Abstract;
using MyBackEnd.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyBackEnd.Bussiness.Concrete
{
    public class ProductService : IProductService
    {
        IProductDal _productDal;
        
      

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;   
        }

        [ValidationAspect(typeof(ProductValidator),Priority =1)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            try
            {
                var result=BussinessRules.Run(CheckIfProductNameExists(product.ProductName));
                if (!result.Success)
                {
                    return result;
                }
                _productDal.Add(product);
                return new SuccessResult(Messages.SuccessProductAdded);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
        }

        public IResult Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
                return new SuccessDataResult<Product>(Messages.SuccessProductDeleted);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<Product>(exception.Message);
            }
        }

        [LogAspect(typeof(DatabaseLogger))] 
        public IDataResult<Product> GetById(int productId)
        {
            try
            {
                return new SuccessDataResult<Product>(_productDal.Get(i => i.ProductId == productId),"Başarılı");
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<Product>(exception.Message);
            }
            
        }

        [CacheAspect(duration:25)]
        [PerformanceAspect(5)]
        public IDataResult<List<Product>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList(),"Başarılı");
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<Product>>(exception.Message);
            }
        }

        [SecurityOperation("Product.List,Admin")]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            try
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetList(i => i.CategoryId == categoryId).ToList(),"Başarılı");
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<Product>>(exception.Message);
            }
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            try
            {
                _productDal.Add(product);
                _productDal.Update(product);
                return new SuccessResult(Messages.SuccessProductUpdated);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
        }

        public IResult Update(Product product)
        {
            try
            {
                _productDal.Update(product);
                return new SuccessResult(Messages.SuccessProductUpdated);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            if (_productDal.Get(p=>p.ProductName==productName)!=null)
            {
                return new ErrorResult(Messages.AlreadyProduct);
            }
            return new SuccessResult();
        }
    }
}
