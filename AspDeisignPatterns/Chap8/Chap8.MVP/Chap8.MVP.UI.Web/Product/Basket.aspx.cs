using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chap8.MVP.Model;
using Chap8.MVP.Presentation;
using Chap8.MVP.Presentation.Basket;
using Chap8.MVP.UI.Web.Shared;
using StructureMap;

namespace Chap8.MVP.UI.Web.Product
{
    public partial class Basket : System.Web.UI.Page, IBasketView
    {
        private IBasketPresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new BasketPresenter(this, ObjectFactory.GetInstance<ProductService>(), ObjectFactory.GetInstance<IBasket>());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.Display();
        }

        public IEnumerable<Category> CategoryList
        {
            set { 
                Shop shopMaster = (Shop) Page.Master;
                shopMaster.CategoryListControl.SetCategoriesToDisplay(value);
            }
        }
        public IEnumerable<Model.Product> BasketItems { set { this.rptBasket.DataSource = value; 
        this.rptBasket.DataBind();} 
        }
    }
}