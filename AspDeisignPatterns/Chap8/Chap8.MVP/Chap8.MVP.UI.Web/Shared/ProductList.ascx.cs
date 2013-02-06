using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chap8.MVP.Model;

namespace Chap8.MVP.UI.Web.Shared
{
    public partial class ProductList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void SetProductToDisplay(IEnumerable<Product> productsModel.)
        {
            this.rptProducts.DataSource = products; 
            this.rptProducts.DataBind();
        }
    }
}
        protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}