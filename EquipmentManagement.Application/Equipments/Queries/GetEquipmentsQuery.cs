using System.Linq;
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Infrastructura.Queries;

namespace EquipmentManagement.Application.Equipments.Queries
{
    public class GetEquipmentsQuery : QueryBase<IQueryable<Equipment>>
    {
    }
}
