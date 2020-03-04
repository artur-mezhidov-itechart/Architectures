using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Application.Equipments.Queries.Handlers
{
    public class GetEquipmentsByTypeQueryHandler : QueryHandler<GetEquipmentsByTypeQuery, IQueryable<Equipment>>
    {
        public GetEquipmentsByTypeQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override IQueryable<Equipment> OnHandling(GetEquipmentsByTypeQuery query)
        {
            return DataContext.Equipments.Where(i => i.Type == query.Type);
        }
    }
}
