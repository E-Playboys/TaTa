using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tata.Entities.Enums;

namespace Tata.Areas.Backend.Helpers
{
    public static class HtmlHelpers
    {
        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this IHtmlHelper htmlHelper)
        {
            string currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

        public static string GetStatusClass(this IHtmlHelper html, string status)
        {
            switch (status)
            {
                case "Enable":
                case "Paid":
                case "Done":
                    return "primary";
                case "LowStock":
                case "Processing":
                    return "warning";
                default:
                    return "danger";
            }
        }
    }
}
