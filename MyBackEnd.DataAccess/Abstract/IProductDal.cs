using MyBackEnd.Core.DataAccess;
using MyBackEnd.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
    }
}
