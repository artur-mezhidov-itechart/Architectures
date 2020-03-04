using Microsoft.AspNetCore.Razor.TagHelpers;
using EquipmentManagement.Domain;
using EquipmentManagement.Web.Extensions;

namespace EquipmentManagement.Web.TagHelpers
{
    public class RequestStatusTagHelper : BackLinkTagHelper
    {
        public RequestStatus Status { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.Content.SetHtmlContent(BuildContent());
        }

        private string BuildContent()
        {
            return $@"
                <span class=""kt-badge kt-badge--{Status.GetColorState()} kt-badge--dot""></span>
                &nbsp;
                <span class=""kt-font-bold kt-font-{Status.GetColorState()}"">{Status}</span>";
        }
    }
}
