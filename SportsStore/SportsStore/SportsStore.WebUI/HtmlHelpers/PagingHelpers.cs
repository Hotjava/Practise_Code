﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using System.Text;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl )
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1  ; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString(CultureInfo.InvariantCulture);
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }
                sb.Append(tag.ToString());

            }
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}