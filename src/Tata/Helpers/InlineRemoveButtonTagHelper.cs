using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Tata.Helpers
{
    [HtmlTargetElement("inline-remove-button")]
    public class InlineRemoveButtonTagHelper : TagHelper
    {
        /// <summary>
        /// The element to remove on UI
        /// </summary>
        [HtmlAttributeName("asp-container-element")]
        public string ContainerElement { get; set; }

        /// <summary>
        /// The field (hidden element) to mark as delete so the server side knows
        /// </summary>
        [HtmlAttributeName("asp-mark-element")]
        public string DeleteElement { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var js = string.Format("javascript:handleInlineRemoveButtonTagHelper(this,'{0}','{1}');return false;", ContainerElement, DeleteElement);

            output.TagName = "button";
            output.Attributes.SetAttribute("type", "button");
            output.Attributes.Add("onclick", js);
        }
    }
}
