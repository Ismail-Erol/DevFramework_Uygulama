using DevFramework.Northwin.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwin.DataAccess.Concrete.Nhibernate;
using DevFramework.Northwin.DataAccess.Concrete.Nhibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevFramework.Northwind.DataAccess.Tests.NhibernateTests
{
    [TestClass]
    public class NhibernateTests
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            // burada normalde newlemek yasak ama test olduğu için bunu yapabiliriz. 
            NhProductDal ef_productdal = new NhProductDal(new SqlServerHelper());

            var result = ef_productdal.GetList();

            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            // burada normalde newlemek yasak ama test olduğu için bunu yapabiliriz. 
            NhProductDal ef_productdal = new NhProductDal(new SqlServerHelper());

            var result = ef_productdal.GetList(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
