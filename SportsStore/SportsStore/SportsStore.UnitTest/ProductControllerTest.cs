using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Language.Flow;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTest
{
    [TestClass]
    public class ProductControllerTest
    {
       
        [TestMethod]
        //public void TestMethod1()
        //{
        //    //Arrange

        //    Mock<IProductRepository> mock;
        //    SetUp(out mock);

        //    // create a controller and make the page size 3 items
        //    ProductController controller = new ProductController(mock.Object);
        //    controller.PageSize = 3;

        //    IEnumerable<Product> result = (IEnumerable<Product>) controller.List(2).Model;

        //    //Assert 
        //    Product[] prodArray = result.ToArray();
        //    Assert.IsTrue(prodArray.Length == 2);
        //    Assert.AreEqual(prodArray[0].Name, "P4");
        //    Assert.AreEqual(prodArray[1].Name, "P5");



        //}

        //[TestMethod]
        //public void Can_Send_Pagination_View_Model()
        //{
        //    Mock<IProductRepository> mock; 
        //    SetUp(out mock);

        //    ProductController controller = new ProductController(mock.Object);

        //    controller.PageSize = 3;

        //    ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

        //    PagingInfo pageInfo = result.PagingInfo;

        //    Assert.AreEqual(pageInfo.CurrentPage,2);
        //    Assert.AreEqual(pageInfo.ItemsPerPage,3);
        //    Assert.AreEqual(pageInfo.TotalItems, 5);
        //    Assert.AreEqual(pageInfo.TotalPages,2);


        //}

        private static void SetUp(out Mock<IProductRepository> mock)
        {
            mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                                                    {
                                                        new Product {ProductID = 1, Name = "P1"},
                                                        new Product {ProductID = 2, Name = "P2"},
                                                        new Product {ProductID = 3, Name = "P3"},
                                                        new Product {ProductID = 4, Name = "P4"},
                                                        new Product {ProductID = 5, Name = "P5"}
                                                    }.AsQueryable());
        }

        [TestMethod]
        public  void Can_Generate_Page_Link()
        {
            //Arrage - define an HTML helper 
            HtmlHelper myHelper = null;

            PagingInfo pagingInfo = new PagingInfo
                                        {
                                            CurrentPage = 2,
                                            TotalItems = 28,
                                            ItemsPerPage = 10
                                        };

            Func<int ,string>
            pageUrlDelegate = i =>"Page" + i;

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>");



        }
    }
}
