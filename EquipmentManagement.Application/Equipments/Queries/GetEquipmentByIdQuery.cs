using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Infrastructura.Queries;

namespace EquipmentManagement.Application.Equipments.Queries
{
    public class GetEquipmentByIdQuery : QueryBase<Equipment>
    {
        public int Id { get; }

        public GetEquipmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
