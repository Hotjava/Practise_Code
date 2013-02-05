using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chap8.MVP.Model;

namespace Chap8.MVP.UI.Web.Shared
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetCategoriesToDisplay(IEnumerable<Category> categories)
        {
            this.rptCategoryList.DataSource = categories; 
            this.rptCategoryList.DataBind();
        }
    }
}