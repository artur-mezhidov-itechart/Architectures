using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Application.Equipments.Queries.Handlers
{
    public class GetEquipmentByIdQueryHandler : QueryHandler<GetEquipmentByIdQuery, Equipment>
    {
        public GetEquipmentByIdQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override Equipment OnHandling(GetEquipmentByIdQuery query)
        {
            return DataContext.Equipments.Find(query.Id);
        }
    }
}
