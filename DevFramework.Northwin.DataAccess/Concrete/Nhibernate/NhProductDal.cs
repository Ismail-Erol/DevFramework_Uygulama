using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Northwin.DataAccess.Abstract;
using DevFramework.Northwind.Entities.ComplexType;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwin.DataAccess.Concrete.Nhibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        private NhibernateHelper _nhibernateHelper;
        public NhProductDal(NhibernateHelper nhibernateHelper) : base(nhibernateHelper)
        {
            _nhibernateHelper = nhibernateHelper;
        }

        public List<ProductDetail> GetProductDetail()
        {
            using (var session = _nhibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>() on p.CategoryId equals c.CategoryID
                             select new ProductDetail
                             {
                                 ProductId = p.ProductId,
                                 CategoryName = c.CategoryName,
                                 ProductName = p.ProductName
                             };
                return result.ToList();

            }
        }
    }
}
