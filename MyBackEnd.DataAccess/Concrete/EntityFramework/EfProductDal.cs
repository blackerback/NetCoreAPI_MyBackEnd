using MyBackEnd.Core.DataAccess.EntityFramework;
using MyBackEnd.DataAccess.Abstract;
using MyBackEnd.DataAccess.Concrete.EntityFramework.Contexts;
using MyBackEnd.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal: EfEntityRepositoryBase<MyDataContext, Product>,IProductDal
    {
    }
}
