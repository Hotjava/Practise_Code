using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public int PageSize = 4;
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult List(string category, int page=1)
        {

            var product = (IEnumerable<Product>)
                          _productRepository.Products.Where(p => category == null || p.Category == category);
            ProductListViewModel model = new ProductListViewModel()
                                             {
                                                 Products = product.OrderBy(p => p.ProductID).Skip((page -1)*PageSize)
                                                     .Take(PageSize),
                                                 PageInfo =
                                                     new PageInfo()
                                                         {
                                                             CurrentPage = page,
                                                             ItemPerPage = PageSize,
                                                             TotalItem = product.Count()
                                                         },
                                                 CurrentCategory = category

                                             };
            return View(model);
           
            
        }

    }
}
