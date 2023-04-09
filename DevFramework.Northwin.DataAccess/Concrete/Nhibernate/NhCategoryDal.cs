using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Northwin.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwin.DataAccess.Concrete.Nhibernate
{
    public class NhCategoryDal : NhEntityRepositoryBase<Category>, ICategoryDal
    {
        public NhCategoryDal(NhibernateHelper nhibernateHelper) : base(nhibernateHelper)
        {
        }
    }
}
