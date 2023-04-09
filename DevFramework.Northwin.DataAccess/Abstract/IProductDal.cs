using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.ComplexType;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Data Access Layer. Veritabanındaki Product Tablosuna erişim için kullanacağız. 

namespace DevFramework.Northwin.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        // burada ürüne özgü metotlarımız olabilir. 
        List<ProductDetail> GetProductDetail();
    }
}
