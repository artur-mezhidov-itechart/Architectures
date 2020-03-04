namespace EquipmentManagement.Application.Reports.Requests.Queries.Models
{
    public class RequestReports
    {
            public RequestCountsByType RequestCountByType { get; set; }

            public RequestByMonthsList RequestByMonths { get; set; }

            public RequestByStatuses RequestByStatuses { get; set; }
    }
}
