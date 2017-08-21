using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingAppStore.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, string[] items, object htmlAttributes = null)
        {
            var ul = new TagBuilder("ul");
            foreach (var item in items)
            {
                var li = new TagBuilder("li");
                li.InnerHtml = item;
                ul.InnerHtml += li.ToString();
            }
            ul.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return new MvcHtmlString(ul.ToString());
        }
        public static MvcHtmlString Image(this HtmlHelper html, string src, string alt)
        {
            var image = new TagBuilder("img");
            image.MergeAttribute("src", src);
            image.MergeAttribute("alt", alt);
            return MvcHtmlString.Create(image.ToString(TagRenderMode.SelfClosing));
        }
    }
}