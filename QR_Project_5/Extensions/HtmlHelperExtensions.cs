using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace QR_Project_5.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString SidebarElement(string controller, string text)
        {
            string link = "/" + controller;
            //<a id="Departamentoes" class="sidebar-button" href="Departamentoes" onclick="select(this)">Services</a>
            var anchor = new TagBuilder("a");
            anchor.AddCssClass("sidebar-button");
            anchor.MergeAttribute("id", controller);
            anchor.MergeAttribute("href", link);
            //anchor.MergeAttribute("onclick", "select(this)");
            anchor.SetInnerText(text);
            var html = anchor.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(html);
        }
    }
}