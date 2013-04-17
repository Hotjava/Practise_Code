using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        //
        // GET: /Nav/
        private IProductRepository repository;
        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

       public PartialViewResult Menu(string category =null)
       {
           ViewBag.SelectedCategory = category; 
           IEnumerable<string> categories = from c in repository.Categories
                                            select c.Name;
           return PartialView(categories);

       }

    }
}
