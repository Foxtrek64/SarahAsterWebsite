using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SarahAsterWebsite.Web.TagHelpers
{
    [HtmlTargetElement("a", Attributes=ExternalAttributeName)]
    public sealed class ExternalLinkTagHelper : TagHelper
    {
        private const string ExternalAttributeName = "is-external";
        private const string ShowIconAttributeName = "show-icon";
        public override int Order => -1500;

        [HtmlAttributeName(ExternalAttributeName)]
        public bool External {get; set;}

        [HtmlAttributeName(ShowIconAttributeName)]
        public bool ShowIcon {get; set;} = true;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            var content = await output.GetChildContentAsync();
            
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;
            if (External)
            {
                if (ShowIcon)
                {
                    output.AddClass("external", HtmlEncoder.Default);
                }                
                output.Attributes.Add("target", "_blank");
                output.Attributes.Add("rel", "noopener");
            }
            output.Content.SetHtmlContent(content);
        }
    }
}