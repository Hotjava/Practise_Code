using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        private IProductRepository _productRepository;

        public CategoryController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult Index()
        {
            return View(_productRepository.Categories);
        }

    }
}
