using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Equipments.Queries.Models;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Queries.Contracts;

namespace EquipmentManagement.Application.Equipments.Queries.Handlers
{
    public class GetUserEquipmentsByUserQueryHandler : QueryHandler<GetUserEquipmentsByUserQuery, IQueryable<UserEquipmentInfo>>
    {
        private readonly IQueryDispatcher queryDispatcher;

        public GetUserEquipmentsByUserQueryHandler(DataContext dataContext, IQueryDispatcher queryDispatcher) : base(dataContext)
        {
            this.queryDispatcher = queryDispatcher;
        }

        protected override IQueryable<UserEquipmentInfo> OnHandling(GetUserEquipmentsByUserQuery query)
        {
            return queryDispatcher
                .Execute(new GetUserEquipmentsQuery())
                .Where(i => i.UserId == query.UserId);
        }
    }
}
