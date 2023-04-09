using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwin.DataAccess.Abstract;
using DevFramework.Northwind.Entities.ComplexType;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwin.DataAccess.Concrete.EntityFramework
{
    public class EF_ProductDal : EF_EntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        // entity frameworkte complex tiple çalışmak. 
        public List<ProductDetail> GetProductDetail()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.CategoryID
                             select new ProductDetail
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
           
        }
    }
}
