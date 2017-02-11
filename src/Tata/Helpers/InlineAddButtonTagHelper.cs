using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Tata.Helpers
{
    [HtmlTargetElement("inline-add-button")]
    public class InlineAddButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-container-element")]
        public string ContainerElement { get; set; }

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeName("asp-content")]
        public IHtmlContent Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var writer = new StringWriter();
            Content.WriteTo(writer, HtmlEncoder.Default);
            var htmlContent = writer.ToString().JsEncode();

            var js = string.Format("javascript:handleInlineAddButtonTagHelper('{0}', '{1}', '{2}');return false;", ContainerElement, For.Name, htmlContent);

            output.TagName = "button";
            output.Attributes.SetAttribute("type", "button");
            output.Attributes.Add("onclick", js);
        }
    }
}
