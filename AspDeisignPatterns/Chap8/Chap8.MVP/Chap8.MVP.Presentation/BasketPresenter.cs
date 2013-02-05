using Chap8.MVP.Model;
using Chap8.MVP.Presentation.Basket;

namespace Chap8.MVP.Presentation
{
    public class BasketPresenter:IBasketPresenter
    {

        private IBasketView _view;
        private ProductService _productService;
        private IBasket _basket;

        public BasketPresenter(IBasketView view, ProductService productService, IBasket basket)
        {
            _view = view;
            _productService = productService;
            _basket = basket;
        }


        public void Display()
        {
            _view.BasketItems = _basket.Items;
            _view.CategoryList = _productService.GetAllCategories();
        }
    }

    public interface IBasketPresenter
    {
        void Display();
    }
}