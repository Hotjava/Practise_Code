using System;
using System.Text;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLink(this HtmlHelper html, PageInfo pageInfo, Func<int,string> pageUrl)
        {
            StringBuilder sb = new StringBuilder();

            for (int i =1; i < pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                var test = pageUrl(i);
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString(); 
               
                if(i==pageInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }
                sb.Append(tag.ToString());
            }
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}