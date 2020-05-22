using MyBackEnd.Bussiness.Abstract;
using MyBackEnd.Bussiness.Conctants;
using MyBackEnd.Core.Utilities.Results;
using MyBackEnd.DataAccess.Abstract;
using MyBackEnd.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBackEnd.Bussiness.Concrete
{
    public class CategoryService : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            try
            {
                _categoryDal.Add(category);
                return new SuccessResult(Messages.SuccessCategoryAdded);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
        }

        public IResult Delete(Category category)
        {
            try
            {
                _categoryDal.Delete(category);
                return new SuccessResult(Messages.SuccessCategoryDeleted);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            try
            {
                return new SuccessDataResult<Category>(_categoryDal.Get(i => i.CategoryId == categoryId));
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<Category>(exception.Message);
            }
        }

        public IDataResult<List<Category>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<Category>>(exception.Message);
            }
        }

        public IResult Update(Category category)
        {
            try
            {
                _categoryDal.Update(category);
                return new SuccessResult(Messages.SuccessCategoryUpdated);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
        }
    }
}
