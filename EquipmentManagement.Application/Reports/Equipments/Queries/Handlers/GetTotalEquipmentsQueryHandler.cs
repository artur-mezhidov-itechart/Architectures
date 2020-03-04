using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Reports.Equipments.Queries.Models;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;

namespace EquipmentManagement.Application.Reports.Equipments.Queries.Handlers
{
    public class GetTotalEquipmentsQueryHandler : QueryHandler<GetTotalEquipmentsQuery, TotalEquipments>
    {
        public GetTotalEquipmentsQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override TotalEquipments OnHandling(GetTotalEquipmentsQuery query)
        {
            return new TotalEquipments
            {
                Furnitures = DataContext.Equipments.Count(s => s.Type == EquipmentType.Furniture),
                Accessories = DataContext.Equipments.Count(s => s.Type == EquipmentType.Accessory),
                Devices = DataContext.Equipments.Count(s => s.Type == EquipmentType.Device),
                Tools = DataContext.Equipments.Count(s => s.Type == EquipmentType.Tools)
            };
        }
    }
}
