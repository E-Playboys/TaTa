using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Tata.Helpers
{
    /// <summary>
    /// 
    /// <div class="switch form-control">
    ///  <div class="onoffswitch">
    ///    <input asp-for="IsHighlight" type="checkbox" class="onoffswitch-checkbox" id="isHighlight"/>
    ///    <label class="onoffswitch-label" for="isHighlight">
    ///      <span class="onoffswitch-inner"></span>
    ///      <span class="onoffswitch-switch"></span>
    ///    </label>
    ///  </div>
    /// </div>
    /// 
    /// </summary>
    [HtmlTargetElement("switch")]
    public class SwitchTagHelper : TagHelper
    {
        protected IHtmlGenerator Generator { get; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        public SwitchTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var ticks = DateTime.UtcNow.Ticks;
            var modelExplorer = this.For.ModelExplorer;

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "switch form-control");

            output.Content.AppendHtml(@"<div class=""onoffswitch"">");

            var checkBox = Generator.GenerateCheckBox(ViewContext, modelExplorer, For.Name, null, new { @class = "onoffswitch-checkbox", id = $"unique_{ticks}" });
            output.Content.AppendHtml(checkBox);

            output.Content.AppendHtml($@"<label class=""onoffswitch-label"" for=""unique_{ticks}"">
                                          <span class=""onoffswitch-inner""></span>
                                          <span class=""onoffswitch-switch""></span>
                                        </label>");

            output.Content.AppendHtml("</div>");
        }
    }
}
