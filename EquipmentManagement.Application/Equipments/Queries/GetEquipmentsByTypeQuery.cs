using System.Linq;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Infrastructura.Queries;

namespace EquipmentManagement.Application.Equipments.Queries
{
    public class GetEquipmentsByTypeQuery : QueryBase<IQueryable<Equipment>>
    {
        public EquipmentType Type { get; }

        public GetEquipmentsByTypeQuery(EquipmentType type)
        {
            Type = type;
        }
    }
}
