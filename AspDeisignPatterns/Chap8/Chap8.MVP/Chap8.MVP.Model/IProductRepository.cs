using System.Collections.Generic;

namespace Chap8.MVP.Model
{
    public interface IProductRepository
    {
        IEnumerable<Product> FindAll();
        Product FindBy(int Id);
    }

}