using System.Collections.Generic;
using Chap8.MVP.Model;

namespace Chap8.MVP.Presentation
{
    public interface IBasketView
    {
        IEnumerable<Category> CategoryList { set; }
        IEnumerable<Product> BasketItems { set; } 
    }
}