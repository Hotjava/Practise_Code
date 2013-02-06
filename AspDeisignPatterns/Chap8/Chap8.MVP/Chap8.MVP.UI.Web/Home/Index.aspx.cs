using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chap8.MVP.Model;
using Chap8.MVP.Presentation;
using StructurChap8.MVP.UI.Web.Shared StructureMap;

namespace Chap8.MVP.UI.Web.Home
{
    public partial class Index : System.Web.UI.Page, IHomeView
    {
        private IHomePagePresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

      _presenter = new HomePagePresenter(this, ObjectFactory.GetInstance<ProductService>());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.Display();
        }

        public IEnumerable<Model.Product> TopSellingProduct
        {
            set
            {
                plBestSellingProducts.SetProductToDisplay(value);
            }
        }
        public IEnumerable<Category> CategoryList { 
            set { 
                Shop shopMasterPage = (Shop) Page.Master;
                shopMasterPage.CategoryListControl.SetCategoriesToDisplay(value);
            } 
        }
    }
}