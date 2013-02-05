using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chap8.MVP.Model;

namespace Chap8.MVP.Presentation
{
    public interface IProductDetailView
    {
        int ProductId { get; set; }
        string Name { get; set; }
        decimal Price { set; }
        string Description { set; }
        IEnumerable<Category> CategoryList { set; }
    }
}
