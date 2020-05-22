using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using MyBackEnd.Bussiness.Abstract;
using MyBackEnd.Bussiness.Concrete;
using MyBackEnd.Core.Utilities.Interceptors;
using MyBackEnd.Core.Utilities.Security.Jwt;
using MyBackEnd.DataAccess.Abstract;
using MyBackEnd.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Bussiness.DependencyResolvers.AutoFac
{
    public class AutoFacBussinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService> ();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthService>().As<IAuthService>();
    

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions() 
                {
                    Selector=new AspectInterceptorSelecter()
                }).SingleInstance();
        }
    }
}
