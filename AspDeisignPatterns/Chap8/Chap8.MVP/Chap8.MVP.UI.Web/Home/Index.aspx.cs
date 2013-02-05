using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chap8.MVP.Model;
using Chap8.MVP.Presentation;
using StructureMap;

namespace Chap8.MVP.UI.Web.Home
{
    public partial class Index : System.Web.UI.Page, IHomeView
    {
        private IHomePagePresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Product> TopSellingProduct { set; private get; }
        public IEnumerable<Category> CategoryList { set; private get; }
    }
}