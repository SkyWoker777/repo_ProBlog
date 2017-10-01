using ProBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace ProBlog.Helpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Pagination pageInfo,
            Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder tagLiPrev = new TagBuilder("li");
            TagBuilder tagPrev = new TagBuilder("a");
            tagPrev.InnerHtml = "Previous";
            if (pageInfo.PageNumber == 1)
            {
                tagLiPrev.AddCssClass("disabled");
            }
            else { tagPrev.MergeAttribute("href", pageUrl(pageInfo.PageNumber - 1)); }

            tagLiPrev.InnerHtml = tagPrev.ToString();
            result.Append(tagLiPrev.ToString());

            int startIndex = 1;
            for (int i = startIndex; i <= pageInfo.TotalPages; i++)
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

            TagBuilder tagLiNext = new TagBuilder("li");
            TagBuilder tagNext = new TagBuilder("a");
            if (pageInfo.PageNumber < pageInfo.TotalPages)
            {
                tagNext.MergeAttribute("href", pageUrl(pageInfo.PageNumber + 1));
            }
            else { tagLiNext.AddCssClass("disabled"); }
            tagNext.InnerHtml = "Next";
            tagLiNext.InnerHtml = tagNext.ToString();

            result.Append(tagLiNext.ToString());

            return MvcHtmlString.Create(result.ToString());
        }
    }
}