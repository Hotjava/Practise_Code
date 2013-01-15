using System.Collections.Generic;

namespace Chap5.DecoratorPattern
{
    public interface IProductRepository
    {
        IEnumerable<Product> FindAll();
    }
}