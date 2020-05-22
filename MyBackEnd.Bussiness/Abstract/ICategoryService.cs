using MyBackEnd.Core.Utilities.Results;
using MyBackEnd.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Bussiness.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int categoryId);
        IDataResult<List<Category>> GetList();
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
