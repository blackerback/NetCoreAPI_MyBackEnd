using Microsoft.EntityFrameworkCore;
using MyBackEnd.Core.DataAccess.EntityFramework;
using MyBackEnd.Core.Entities.Concrete;
using MyBackEnd.DataAccess.Abstract;
using MyBackEnd.DataAccess.Concrete.EntityFramework.Contexts;
using MyBackEnd.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBackEnd.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<MyDataContext, User>, IUserDal
    {
        public List<OperationClaims> GetClaims(User user)
        {
            using (var context=new MyDataContext())
            {
                var result = context.Users.Where(i => i.Id == user.Id).Include(i => i.OperationClaims).Select(i => i.OperationClaims)?.FirstOrDefault();
                return result;

            }
        }
    }
}
