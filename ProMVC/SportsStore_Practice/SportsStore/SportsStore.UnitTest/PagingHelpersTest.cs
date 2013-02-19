using SportsStore.WebUI.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for PagingHelpersTest and is intended
    ///to contain all PagingHelpersTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PagingHelpersTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for PageLink
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        //[TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("D:\\Code\\trunk\\ProMVC\\SportsStore_Practice\\SportsStore\\SprotsStore.WebUI", "/")]
        //[UrlToTest("http://localhost:9004/")]
        public void PageLinkTest()
        {
            HtmlHelper html = null; // TODO: Initialize to an appropriate value
            PageInfo pageInfo = new PageInfo()
                                    {
                                        CurrentPage = 2,
                                        TotalItem = 28,
                                        ItemPerPage = 10
                                    };// TODO: Initialize to an appropriate value
            Func<int, string> pageUrl = i=>"Page "+i;

            MvcHtmlString result = html.PageLink(pageInfo, pageUrl); 

            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>");




        }
    }
}
