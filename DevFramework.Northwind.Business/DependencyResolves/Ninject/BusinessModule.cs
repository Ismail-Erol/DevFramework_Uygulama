using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Northwin.DataAccess.Abstract;
using DevFramework.Northwin.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwin.DataAccess.Concrete.Nhibernate.Helpers;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Managers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.DependencyResolves.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EF_ProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();  
            Bind<IUserDal>().To<EF_UserDal>().InSingletonScope();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EF_QueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();

            Bind<NhibernateHelper>().To<SqlServerHelper>();
        }
    }
}
