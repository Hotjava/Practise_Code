using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chap8.MVP.Model;

namespace Chap8.MVP.Presentation
{
    public interface IHomeView 
    {
        IEnumerable<Product> TopSellingProduct { set; }
        IEnumerable<Category> CategoryList { set; } 

    }
}
