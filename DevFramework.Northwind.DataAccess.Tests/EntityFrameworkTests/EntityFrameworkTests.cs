using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevFramework.Northwin.DataAccess.Concrete.EntityFramework;



namespace DevFramework.Northwind.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTests
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            // burada normalde newlemek yasak ama test olduğu için bunu yapabiliriz. 
            EF_ProductDal ef_productdal = new EF_ProductDal();

            var result = ef_productdal.GetList();

            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            // burada normalde newlemek yasak ama test olduğu için bunu yapabiliriz. 
            EF_ProductDal ef_productdal = new EF_ProductDal();

            var result = ef_productdal.GetList(p=> p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
