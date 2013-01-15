using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Service
{
    public class ProductService
    {
        private Model.ProductService _productService;

        public ProductService(Model.ProductService productService)
        {
            _productService = productService;
        }

        public ProductListResponse GetAllProductFor(ProductListRequest request)
        {
            ProductListResponse productListResponse = new ProductListResponse();
            try
            {
                IList<Model.Product> productsEntities = _productService.GetAllProductFor(request.CustomerType);
                productListResponse.Products = productsEntities.ConvertToProductListViewModel();
                productListResponse.Success = true;
            }

            catch (Exception ex)
            {
                productListResponse.Success = false;

                productListResponse.Message = "An error occured";
            }
            return productListResponse;
        }
    }
}
