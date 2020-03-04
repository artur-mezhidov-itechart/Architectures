using Newtonsoft.Json;

namespace EquipmentManagement.Web.Converters
{
    public class CamelCaseJsonSerializerSettings : JsonSerializerSettings
    {
        public CamelCaseJsonSerializerSettings()
        {
            ContractResolver = new CamelCaseContractResolver();
            Formatting = Formatting.Indented;
        }
    }
}
