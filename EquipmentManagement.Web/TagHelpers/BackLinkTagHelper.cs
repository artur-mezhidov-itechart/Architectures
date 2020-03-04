using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EquipmentManagement.Web.TagHelpers
{
    public class BackLinkTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("href", "javascript:history.back();");
            output.Attributes.Add("class", "btn btn-outline-brand");
            output.Content.SetHtmlContent("<i class=\"la la-arrow-left\"></i> Back");
        }
    }
}
