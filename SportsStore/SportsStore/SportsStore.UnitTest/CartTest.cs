using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportsStore.UnitTest
{
    /// <summary>
    /// Summary description for CartTest
    /// </summary>
    [TestClass]
    public class CartTest
    {
        public CartTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Can_Add_New_Line()
        {
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new Product[]
            //                                        {
            //                                            new Product{ProductID = 1, Name = "p1", Category = "Apples"},
            //                                            new Product{ProductID = 2, Name = "p2", Category = "Apples"}
            //                                        }.AsQueryable());
            
            //Cart cart = new Cart();
            //CartController target = new CartController(mock.Object);

            //target.AddToCart(cart, 1, null);

            //Assert.IsTrue(cart.Lines.Count() == 1);
           
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Line()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);

            CartLine[] lines = target.Lines.ToArray();

            Assert.IsTrue(lines.Length==2);
            Assert.IsTrue(lines[0].Quantity == 11);
        }

        [TestMethod]
        public void Can_Remove_Line()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);

            target.RemoveLine(p1);


            CartLine[] lines = target.Lines.ToArray();

            Assert.IsTrue(lines.Length == 1);
            Assert.IsTrue(lines[0].Quantity == 1);
        }

    }
}
