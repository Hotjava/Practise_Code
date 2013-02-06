using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chap8.MVP.UI.Web.Shared
{
    public partial class Shop : System.Web.UI.MasterPage
    {
        protected voublic CategoryList CategoryListControl
        {
            get { return this.CategoryList1; }
        }rotected void Page_Load(object sender, EventArgs e)
        {

        }
              
        }
    }
}