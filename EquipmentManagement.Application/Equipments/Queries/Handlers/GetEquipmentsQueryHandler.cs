using System.Linq;
using Microsoft.EntityFrameworkCore;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Application.Equipments.Queries.Handlers
{
    public class GetEquipmentsQueryHandler : QueryHandler<GetEquipmentsQuery, IQueryable<Equipment>>
    {
        public GetEquipmentsQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override IQueryable<Equipment> OnHandling(GetEquipmentsQuery query)
        {
            return DataContext.Equipments.AsNoTracking();
        }
    }
}
