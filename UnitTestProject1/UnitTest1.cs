using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Controllers;
using Store.Models;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProductController controller = new ProductController();
            var result = controller.SingleProduct(3) as System.Web.Mvc.ViewResult;
            Assert.IsNotNull(result.Model);
        }
    }
}
