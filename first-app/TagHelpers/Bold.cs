using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ContactUs.TagHelpers
{
    [HtmlTargetElement(Attributes = "bold")]
    public class Bold:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("style", "font-weight:900");
            base.Process(context, output);
        }
    }
}