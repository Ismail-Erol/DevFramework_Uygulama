using DevFramework.Northwin.DataAccess.Concrete.EntityFramework.Mapping;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwin.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
            // veritabanının kod tarafından üretilmesini engellemek için bu yöntemi kullanıyoruz. 
            Database.SetInitializer<NorthwindContext>(null);
        }
        public DbSet<Product> Products { get; set; }
        // diğer nesneler için aynı şekidle oluşturmaya devam edebiliriz. 

        // productMap için hazırladığımız kısmı burada ayağa kaldırıyoruz. 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());

            // ekleyecek olduğumuz diğer Map'lar için aynı şekidle burada configüre etmemiz gerekecektir. 
        }
    }
}
