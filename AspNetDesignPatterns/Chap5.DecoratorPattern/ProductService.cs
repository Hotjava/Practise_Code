using System.Collections.Generic;

namespace Chap5.DecoratorPattern
{
    public class ProductService
    {
        private IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> products = _repository.FindAll(); 
            products.ApplyTradDiscount();
            products.ApplyCurrencyDiscount();
            return products;
        }
    }
}