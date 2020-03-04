namespace EquipmentManagement.Application.Reports.Equipments.Queries.Models
{
    public class EquipmentReports
    {
        public TotalEquipments Total { get; set; }

        public UserEquipmentsCount UserEquipmentsCount { get; set; }

        public RatioOfEquipments RatioOfCount { get; set; }

        public RatioOfEquipments RatioOfPrice { get; set; }
    }
}
