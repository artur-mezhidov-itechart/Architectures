using Microsoft.AspNetCore.Razor.TagHelpers;
using EquipmentManagement.Domain;
using EquipmentManagement.Web.Extensions;

namespace EquipmentManagement.Web.TagHelpers
{
    public class EquipmentTypeTagHelper : BackLinkTagHelper
    {
        public EquipmentType Type { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.Attributes.Add("class", BuildCssClass());
            output.Content.SetContent(Type.ToString());
        }

        private string BuildCssClass()
        {
            return $"kt-badge kt-badge--inline kt-badge--pill kt-badge--{Type.GetColorState()}";
        }
    }
}
