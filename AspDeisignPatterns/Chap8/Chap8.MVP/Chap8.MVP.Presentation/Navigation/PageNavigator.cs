using System;
using System.Web;

namespace Chap8.MVP.Presentation.Navigation
{
    public class PageNavigator:IPageNavigator
    {
        public void NavigateTo(PageDirectory page)
        {
            switch (page)
            {
                case PageDirectory.Basket:
                        HttpContCurrent.Response.Redirect("/Views/BasketProducx");
                    break;
                    
                default:
                    throw  new ApplicationException("Cannot navigate to" + page.ToString());
            }
        }
    }
}