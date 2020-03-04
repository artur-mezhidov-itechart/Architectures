using EquipmentManagement.Application.Equipments.Queries.Models;
using EquipmentManagement.Application.Requets.Queries.Models;

namespace EquipmentManagement.Web.ViewModels.Requests
{
    public class RequestDetailsViewModel
    {
        public RequestDetails RequestDetails { get; set; }

        public UserEquipmentInfo UserEquipmentInfo { get; set; }
    }
}
