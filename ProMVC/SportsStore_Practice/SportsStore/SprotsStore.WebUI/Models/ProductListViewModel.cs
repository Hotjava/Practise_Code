using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class ProductListViewModel
    {
        public string CurrentCategory { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}