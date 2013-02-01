using Chap8.MVP.Model;

namespace Chap8.MVP.Presentation
{
    public class CategoryProductPresenter : ICategoryProductsPresenter
    {
        private ICategoryProductView _view;
        private ProductService _productService;

        public CategoryProductPresenter(ICategoryProductView view, ProductService productService)
        {
            _view = view;
            _productService = productService;
        }

        public void Display()
        {
            _view.CategoryProductList = _productService.GetAllProductsIn(_view.CategoryId);
            _view.Category = _productService.GetCategoryBy(_view.CategoryId);
            _view.CategoriesList = _productService.GetAllCategories();
        }
    }
    public interface ICategoryProductsPresenter
    {
        void Display();
    }
}