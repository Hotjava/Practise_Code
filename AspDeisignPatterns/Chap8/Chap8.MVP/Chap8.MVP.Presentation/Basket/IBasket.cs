using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chap8.MVP.Model;

namespace Chap8.MVP.Presentation.Basket
{
    public interface IBasket
    {
        IEnumerable<Product> Items { get; }
        void Add(Product product);
    }
}
