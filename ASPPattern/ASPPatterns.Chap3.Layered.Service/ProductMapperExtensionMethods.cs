using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Service
{
    public static class ProductMapperExtensionMethods
    {

        public static IList<ProductViewModel> ConvertToProductListViewModel(this IList<Model.Product> products)
        {
            return products.Select(p => (p.ConvertToProductViewModel())).ToList();
        }

        public static ProductViewModel ConvertToProductViewModel(this Model.Product product)
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.ProductId = product.Id;
            viewModel.RRP = string.Format("{0:C}", product.Price.RRP);
            viewModel.SellingPrice = string.Format("{0:C}", product.Price.SellingPrice);

            if (product.Price.Discount > 0)
                viewModel.Discount = string.Format("{0:C}", product.Price.Discount);
            if (product.Price.Savings < 1 && product.Price.Savings > 0)
            {
                viewModel.Saving = product.Price.Savings.ToString("#%");
            }

            return viewModel;

        }
    }

    
}
