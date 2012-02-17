using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Web.UI
{
    public static class HtmlExtensions
    {
        private const string Nbsp = "&nbsp;";

        private const string SelectedAttribute = " selected='selected'";

        public static MvcHtmlString Controller(this HtmlHelper helper)
        {
            return MvcHtmlString.Create((string)helper.ViewContext.RouteData.Values["controller"]);
        }

        public static MvcHtmlString MenuItem(this HtmlHelper helper, string linkText,
                            string actionName, string controllerName, string selectedClass, bool controllerDesplay)
        {
            string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            var builder = new TagBuilder("li");
            if (controllerDesplay)
            {
                if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase))
                    builder.AddCssClass(selectedClass);
            }
            else
            {
                if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase)
                    && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
                    builder.AddCssClass(selectedClass);
            }

            builder.InnerHtml = LinkExtensions.ActionLink(helper, linkText, actionName, controllerName).ToHtmlString();
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString MenuItem(this HtmlHelper helper, string linkText,
                                  string actionName, string controllerName, string selectedClass)
        {
            return MenuItem(helper, linkText, actionName, controllerName, selectedClass, false);
        }

        public static MvcHtmlString NbspIfEmpty(this HtmlHelper helper, string value)
        {
            return new MvcHtmlString(string.IsNullOrEmpty(value) ? Nbsp : value);
        }

        public static MvcHtmlString SelectedIfMatch(this HtmlHelper helper, object expected, object actual)
        {
            return new MvcHtmlString(Equals(expected, actual) ? SelectedAttribute : string.Empty);
        }

        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }

    }
}