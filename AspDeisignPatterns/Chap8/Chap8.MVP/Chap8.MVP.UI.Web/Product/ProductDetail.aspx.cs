using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chap8.MVP.Model;
using Chap8.MVP.Presentation;
using Chap8.MVP.Presentation.Basket;
using Chap8.MVP.Presentation.Navigation;
using Chap8.MVP.UI.Web.Shared;
using StructureMap;

namespace Chap8.MVP.UI.Web.Product
{
    
    public partial class ProductDetail : System.Web.UI.Page, IProductDetailView
    {

        private IProductDetailPresenter _presenter;

        protected void Page_Init(Object sender, EventArgs e)
        {
            _presenter = new ProductDetailPresenter(this, ObjectFactory.GetInstance<ProductService>(), ObjectFactory.GetInstance<IBasket>(), ObjectFactory.GetInstance<IPageNavigator>() );
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.Display();
        }


        public int ProductId { get { return int.Parse(Request.QueryString["ProductId"]); } }
        public string Name { set { this.litName.Text = value; } }
        public decimal Price { set { this.litPrice.Text = string.Format("{0:C}",value); } }
        public string Description { set { litDescription.Text = value; } }
        public IEnumerable<Category> CategoryList
        {
            set { 
                Shop ShopMaster = (Shop) Page.Master;
                ShopMaster.CategoryListControl.SetCategoriesToDisplay(value);
            }
            
        }

        protected void btnAddToBasket_Click(object sender, EventArgs e)
        {
            _presenter.AddProductToBasketAndShowBasketPage();
        }
    }
}