using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chap8.MVP.Model;
using Chap8.MVP.Presentation;
using Chap8.MVP.UI.Web.Shared;
using StructureMap;

namespace Chap8.MVP.UI.Web.Product
{
    partial class CategoryProducts : System.Web.UI.Page, ICategoryProductView

    {
        private ICategoryProductsPresenter _presenter;
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new CategoryProductPresenter(this, ObjectFactory.GetInstance<ProductService>());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.Display();
        }

        public Category Category { set { litCategoryName.Text = value.Name; } }
        public int CategoryId { get { return int.Parse(Request.QueryString["CategoryId"]); } }
        public IEnumerable<Model.Product> CategoryProductList { set{this.plCategoryProducts.SetProductToDisplay(value);} }
        public IEnumerable<Category> CategoriesList { set { Shop shopMaster = (Shop) Page.Master; shopMaster.CategoryListControl.SetCategoriesToDisplay(value); } }
    }
}