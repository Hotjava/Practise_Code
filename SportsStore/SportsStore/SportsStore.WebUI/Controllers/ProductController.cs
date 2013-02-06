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
        private IProductRepository repository;

        public int PageSize = 1;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        //public  ViewResult  List()
        //{
        //    return View(repository.Products);
        //}

        //public ViewResult List(int page=1)
        //{
        //    ProductsListViewModel viewModel = new ProductsListViewModel()
        //                                          {
        //                                              Products =
        //                                                  repository.Products.OrderBy(p => p.ProductID).Skip((page - 1)*
        //                                                                                                     PageSize).
        //                                                  Take(PageSize),
        //                                              PagingInfo =
        //                                                  new PagingInfo()
        //                                                      {
        //                                                          CurrentPage = page,
        //                                                          ItemsPerPage = PageSize,
        //                                                          TotalItems = repository.Products.Count()
        //                                                      }
        //                                          };
        //    return View(viewModel);
        //}

        public ViewResult List(string category, int page=1)
        {
          var products =
                repository.Products.Where(p => string.IsNullOrEmpty(category) || p.Category == category).OrderBy(p => p.ProductID);
                    
            ProductsListViewModel viewModel = new ProductsListViewModel()
                                                  {
                                                      Products = products.Skip((page - 1)*PageSize).Take(PageSize),
                                                      PagingInfo =
                                                          new PagingInfo
                                                              {
                                                                  CurrentPage = page,
                                                                  ItemsPerPage = PageSize,
                                                                  TotalItems = products.Count()
                                                              },
                                                      CurrentCategory = category
                                                  };

            return View(viewModel);
        }
    }
}
