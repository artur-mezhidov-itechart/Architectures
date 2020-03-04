using EquipmentManagement.Application.Reports.Equipments.Queries.Models;

namespace EquipmentManagement.Web.ViewModels.Reports
{
    public class UserEquipmentChartViewModel
    {
        public string Title { get; set; }

        public string Label { get; set; }

        public string ChartId { get; set; }

        public string Type { get; set; }

        public UserEquipmentCount UserEquipmentCount { get; set; }
    }
}
