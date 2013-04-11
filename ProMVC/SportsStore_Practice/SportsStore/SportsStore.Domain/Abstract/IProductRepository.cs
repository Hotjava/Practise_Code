using System.Linq;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
         IQueryable<Product> Products { get; }
        IQueryable<Category> Categories { get; }
        void SaveProduct(Product p);
    }
}