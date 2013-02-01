using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Chap8.MVP.Model;

namespace Chap8.MVP.Presentation.Basket
{
    public class Basket:IBasket
    {
        public IEnumerable<Product> Items {
            get { return GetBasketProdcut(); }
        }

        private IList<Product> GetBasketProdcut()
        {
            IList<Product> products = HttpContext.Current.Session["Basket"] as IList<Product>;
            if (products == null)
            {
                products = new List<Product>();
                HttpContext.Current.Session["Basket"] = products;
            }
            return products;
        }

        public void Add(Product product)
        {
            IList<Product> products = GetBasketProdcut();
            products.Add(product);

        }
    }
}
