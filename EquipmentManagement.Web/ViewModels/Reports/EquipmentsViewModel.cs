using EquipmentManagement.Application.Reports.Equipments.Queries.Models;

namespace EquipmentManagement.Web.ViewModels.Reports
{
    public class EquipmentsViewModel : LayoutViewModel
    {
        public TotalEquipments Total { get; set; }

        public UserEquipmentChartViewModel UserFurnitures { get; set; }

        public UserEquipmentChartViewModel UserDevices { get; set; }

        public UserEquipmentChartViewModel UserAccessories { get; set; }

        public UserEquipmentChartViewModel UserTools { get; set; }

        public RatioDetailChartViewModel RatioOfCount { get; set; }

        public RatioDetailChartViewModel RatioOfPrice { get; set; }
    }
}
