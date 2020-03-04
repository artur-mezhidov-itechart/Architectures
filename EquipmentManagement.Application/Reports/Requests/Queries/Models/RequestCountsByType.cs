namespace EquipmentManagement.Application.Reports.Requests.Queries.Models
{
    public class RequestCountsByType
    {
        public RequestCountByType FurnituresCount { get; set; }

        public RequestCountByType DevicesCount { get; set; }

        public RequestCountByType AccessoriesCount { get; set; }

        public RequestCountByType ToolsCount { get; set; }
    }
}
