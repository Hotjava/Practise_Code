using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportsStore.UnitTest
{
    [TestClass]
    public class AdminTest
    {
        [TestMethod]
        public void Index_Cotains_All_Product()
        {
            Mock<IProductRepository> mock =
                new Mock<IProductRepository>();
            mock.Setup(m => m.Products)
                .Returns(new Product[]
                             {
                                 new Product{ProductID = 1, Name = "P1"}, 
                                 new Product{ProductID = 2, Name = "P2"}, 
                                 new Product{ProductID = 3, Name = "P3"}
                             }.AsQueryable());


            AdminController target = new AdminController(mock.Object);

            Product[] result = ((IEnumerable<Product>) target.Index().ViewData.Model).ToArray();

            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("P1", result[0].Name);
            Assert.AreEqual("P2", result[1].Name);
            Assert.AreEqual("P3", result[2].Name);
        }

        //[TestMethod]

        //public void Can_Edit_Product()
        //{
        //    Mock<IProductRepository> mock = new Mock<IProductRepository>();
        //    mock.Setup(m => m.Products)
        //        .Returns(new Product[]
        //                     {
        //                         new Product {ProductID = 1, Name = "P1"}, 
        //                         new Product {ProductID = 2, Name = "P2"},
        //                         new Product {ProductID = 3, Name = "P3"}
        //                     }.AsQueryable());

        //    AdminController target = new AdminController(mock.Object);

        //    Product p1 = ((ViewResult)target.Edit(mock.)).ViewData.Model as Product;
        //    Product p2 = ((ViewResult)target.Edit(2)).ViewData.Model as Product;
        //    Product p3 = ((ViewResult)target.Edit(3)).ViewData.Model as Product; 

        //    Assert.AreEqual(1, p1.ProductID);
        //    Assert.AreEqual(2, p2.ProductID);


        //}

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            AdminController target = new AdminController(mock.Object);

            Product p = new Product{Name = "Test"};

            ActionResult result = target.Edit(p); 

            mock.Verify(m=>m.SaveProduct(p));

            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Product()
        {
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new Product[]
            //                                        {
            //                                            new Product {ProductID = 1, Name = "P1"}, 
            //                                            new Product {ProductID = 2, Name = "P2"}, 
            //                                            new Product {ProductID = 3, Name = "P3"}
            //                                        }.AsQueryable());

            //AdminController controller = new AdminController(mock.Object);

            //Product result = (Product) controller.Edit(4).ViewData.Model as Product; 
            
            //Assert.IsNull(result);
        }
    }
}
