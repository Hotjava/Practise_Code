using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Model
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository discountStrategy)
        {
            this._productRepository = discountStrategy;
        }

        public IList<Product> GetAllProductFor(CustomerType customerType)
        {
            IDiscountStrategy discountStrategy = DiscountFactory.GetDiscountStrtegyFor(customerType);
            IList<Product> products = _productRepository.Findall(); 
            products.Apply(discountStrategy);
            return products;

        }


    }
}
