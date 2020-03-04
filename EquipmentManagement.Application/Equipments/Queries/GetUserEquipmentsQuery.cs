using System.Linq;
using EquipmentManagement.Application.Equipments.Queries.Models;
using EquipmentManagement.Infrastructura.Queries;

namespace EquipmentManagement.Application.Equipments.Queries
{
    public class GetUserEquipmentsQuery : QueryBase<IQueryable<UserEquipmentInfo>>
    {
    }
}
