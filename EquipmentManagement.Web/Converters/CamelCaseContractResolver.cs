using Newtonsoft.Json.Serialization;

namespace EquipmentManagement.Web.Converters
{
    public class CamelCaseContractResolver : DefaultContractResolver
    {
        public CamelCaseContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy();
        }
    }
}
