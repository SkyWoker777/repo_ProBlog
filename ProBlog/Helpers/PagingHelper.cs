using ProBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProBlog.Helpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Pagination pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tagLi = new TagBuilder("li");
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                tagLi.InnerHtml = tag.ToString();

                if (i == pageInfo.PageNumber)
                {
                    tagLi.AddCssClass("active");
                }
                result.Append(tagLi.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}