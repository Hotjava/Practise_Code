using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportsStore.UnitTest
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Can_Add_To_Cart()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                                                    {
                                                        new Product {ProductID = 1, Name = "P1", Category = "Apples"}
                                                    }.AsQueryable());
            Cart cart = new Cart();

            Mock<IOrderProcessor> mockProcessor = new Mock<IOrderProcessor>();
           

            CartController target = new CartController( mock.Object, null);

            target.AddToCart(cart, 1, null);

            Assert.AreEqual(cart.Lines.Count(),1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductID, 1);
        }

        [TestMethod]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] { 
                new Product {ProductID = 1, Name = "P1", Category = "Apples"}
            }.AsQueryable());

            Cart cart = new Cart();

            CartController controller = new CartController(mock.Object,null);

            RedirectToRouteResult result = controller.AddToCart(cart, 2, "myUrl");

            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"],"myUrl");

        }

        [TestMethod]
        public void Can_Add_New_Lines()
        {
            Product p1 = new Product() {ProductID = 1, Name = "P1"};
            Product p2 = new Product() {ProductID = 2, Name = "P2"}; 

            Cart cart = new Cart();

            cart.AddItem(p1,1);
            cart.AddItem(p2,1);

            CartLine[] lines = cart.Lines.ToArray(); 

            Assert.AreEqual(lines.Length,2);
            Assert.AreEqual(lines[0].Product, p1);
            Assert.AreEqual(lines[1].Product, p2);

        }
        [TestMethod]
        public void Can_Add_New_Lines_On_Existing()
        {
            Product p1 = new Product() { ProductID = 1, Name = "P1" };
            Product p2 = new Product() { ProductID = 2, Name = "P2" };

            Cart cart = new Cart();

            cart.AddItem(p1, 1);
            cart.AddItem(p2, 1);
            cart.AddItem(p1, 2);

            CartLine[] lines = cart.Lines.ToArray();

            Assert.AreEqual(lines.Length,2);
            Assert.AreEqual(lines[0].Product, p1);
            Assert.AreEqual(lines[1].Product, p2);
            Assert.AreEqual(lines[0].Quantity, 3);
        }

        [TestMethod]
        public void Can_Remove_Line()
        {
            Product p1 = new Product() { ProductID = 1, Name = "P1" };
            Product p2 = new Product() { ProductID = 2, Name = "P2" };

            Cart cart = new Cart();

            cart.AddItem(p1, 1);
            cart.AddItem(p2, 1);
            cart.AddItem(p1, 2);

            cart.RemoveLine(p1);

            Assert.AreEqual(cart.Lines.Count(p => p.Product==p1),0);
            Assert.AreEqual(cart.Lines.Count(),1);

           
        }

        [TestMethod]
        public void Cannot_Checkout_EmptyCart()
        {
            //arrange - Create a mock order process

            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            Cart cart = new Cart();

            ShippingDetails shippingDetails = new ShippingDetails();
            CartController controller = new CartController(null, mock.Object );

            ViewResult result = controller.Checkout(cart, shippingDetails); 

            mock.Verify(m=>m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.AtLeastOnce());
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }
        [TestMethod]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);

            CartController target = new CartController(null,mock.Object);

            target.ModelState.AddModelError("error", "error");
            ViewResult result = target.Checkout(cart, new ShippingDetails());

            mock.Verify(m=>m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);

        }

        [TestMethod]

        public void Can_CheckOut_And_Submit_Order()
        {
            
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);

            CartController controller = new CartController(null, mock.Object);

            ViewResult result = controller.Checkout(cart, new ShippingDetails());

            mock.Verify(m=>m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Once());

            Assert.AreEqual("Completed", result.ViewName);
            Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
        }
    }
}
