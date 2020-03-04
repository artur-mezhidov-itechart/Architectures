using EquipmentManagement.Domain;

namespace EquipmentManagement.Web.ViewModels.Equipments
{
    public class EquipmentViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public EquipmentType Type { get; set; }
    }
}
