using Chap8.MVP.Model;

namespace Chap8.MVP.Presentation
{
    public class HomePagePresenter:IHomePagePresenter
    {
        private IHomeView _view;
        private ProductService _productService;


        public HomePagePresenter(IHomeView view, ProductService productService)
        {
            _view = view;
            _productService = productService;
        }

        public void Display()
        {
            _view.TopSellingProduct = _productService.GetBestSellingProducts();
            _view.CategoryList = _productService.GetAllCategories();
        }
    }

    public interface IHomePagePresenter
    {
        void Display();
    }
}