using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chap8.MVP.Model;

namespace Chap8.MVP.Presentation
{
    public interface ICategoryProductView
    {
        Category Category { set; }
        int CategoryId { get; }
        IEnumerable<Product> CategoryProductList { set; }
        IEnumerable<Category> CategoriesList { set; } 
    }
}
