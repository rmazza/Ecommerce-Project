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
        public void TestSingleProductController()
        {
            ProductController controller = new ProductController();
            var result = controller.SingleProduct(3) as System.Web.Mvc.ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void TestVerifyAddressIsNotNull()
        {
            CheckoutController controller = new CheckoutController();
            var result = controller.VerifyAddress("1 millstone circle", "Andover", "Ma", 01810).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCheckoutModel()
        {
            CheckoutController controller = new CheckoutController();

            CheckoutModel model =
                new CheckoutModel
                {
                    streetName = "8 Lavender Hill Ln",
                    city = "Andover",
                    state = "Ma",
                    zipcode = 01810
                };

            //var result =  controller.Checkout(model) as System.Web.Mvc.ViewResult;

        }

        //[TestMethod]
        //public void TestVerityAddressEqualsGivenAddress()
        //{
        //    CheckoutController controller = new CheckoutController();
        //    var result = controller.VerifyAddress("1 millstone circle", "Andover", "Ma", 01810);
            
        //}
    }
}
