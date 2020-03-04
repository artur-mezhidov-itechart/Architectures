using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;
using EquipmentManagement.Web.Converters;

namespace EquipmentManagement.Web.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent ToJson(this IHtmlHelper html, object obj)
        {
            return html.Raw(JsonConvert.SerializeObject(obj, new CamelCaseJsonSerializerSettings()));
        }
    }
}
