using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();
        ProductController controller ;
        [TestInitialize]
        public void Setup()
        {
            mock.Setup(m => m.Products).Returns(new Product[] { 
            new Product {ProductID = 1, Name = "P1"}, 
            new Product {ProductID = 2, Name = "P2"}, 
            new Product {ProductID = 3, Name = "P3"}, 
            new Product {ProductID = 4, Name = "P4"}, 
            new Product {ProductID = 5, Name = "P5"} 
            }.AsQueryable());

            controller = new ProductController(mock.Object);
         }


        [TestMethod]
        public void  Can_Paginate()
        {
           

            //ProductController controller = new ProductController(mock.Object);
            //controller.PageSize = 1;

            //IEnumerable<Product> result = (IEnumerable<Product>) controller.List(2).Model;

            //Product[] prodArray = result.ToArray(); 
            //Assert.IsTrue(prodArray.Length==1);
            //Assert.IsTrue(prodArray[0].Name=="P2");


        }

         [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            controller.PageSize = 3;

            ProductListViewModel result = (ProductListViewModel) controller.List(null, 2).Model;

            PageInfo info = result.PageInfo; 

            Assert.AreEqual(info.CurrentPage,2);
            Assert.AreEqual(info.TotalPages,2);
            Assert.AreEqual(info.ItemPerPage ,3 );

        }
    }
}
