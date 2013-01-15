using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap3.Layered.Service;

namespace ASPPatterns.Chap3.Layered.Presentation
{
    public class ProductListPresenter
    {
        private IProductListView _productListView;
        private Service.ProductService _productService; 

        public ProductListPresenter(IProductListView productListView, Service.ProductService productService)
        {
            this._productListView = productListView;
            this._productService = productService;
        }

        public void Display()
        {
            ProductListRequest productListRequest = new ProductListRequest();
            productListRequest.CustomerType = _productListView.CustomerType;

            ProductListResponse productListResponse = _productService.GetAllProductFor(productListRequest);
            if (productListResponse.Success)
            {
                _productListView.Dispaly(productListResponse.Products);
            }
            else
            {
                _productListView.ErrorMessage=productListResponse.Message;
            }

        }
    }
}
