using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap8.MVP.Presentation
{
    public interface IProductListView
    {
        int ProductId { get; }
        string Name { set; }
        decimal Price { set; }
        IEnumerable<ICategoryProductView> CategoryList { set; }
    }
}
