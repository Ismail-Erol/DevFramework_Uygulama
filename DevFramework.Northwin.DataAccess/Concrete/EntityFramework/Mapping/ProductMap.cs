using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwin.DataAccess.Concrete.EntityFramework.Mapping
{
    // veritabani ile senlelerin karşılaştırılmasını yada ilişkilendirilmesini sağlar. 
    // dephensive programming için kullanılmasında fayda var. 
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        // konfigürasyonları burada yapıyoruz. 

        public ProductMap()
        {
            ToTable(@"Products",@"dbo"); // tablo adı ve şema ,
            HasKey(x => x.ProductId);

            Property(x=> x.ProductId).HasColumnName("ProductId");
            Property(x => x.CategoryId).HasColumnName("CategoryId");
            Property(x => x.SupplierID).HasColumnName("SupplierID");
            Property(x => x.ProductName).HasColumnName("ProductName");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice");
            Property(x => x.UnitsInStock).HasColumnName("UnitsInStock");
            Property(x => x.UnitsOnOrder).HasColumnName("UnitsOnOrder");
            Property(x => x.ReorderLevel).HasColumnName("ReorderLevel");
            Property(x => x.Discontinued).HasColumnName("Discontinued");

        }
    }
}
