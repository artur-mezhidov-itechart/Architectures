using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Equipments.Queries.Models;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Queries.Contracts;

namespace EquipmentManagement.Application.Equipments.Queries.Handlers
{
    public class GetUserEquipmentByRequestQueryHandler : QueryHandler<GetUserEquipmentByRequestQuery, UserEquipmentInfo>
    {
        private readonly IQueryDispatcher queryDispatcher;

        public GetUserEquipmentByRequestQueryHandler(DataContext dataContext, IQueryDispatcher queryDispatcher) : base(dataContext)
        {
            this.queryDispatcher = queryDispatcher;
        }

        protected override UserEquipmentInfo OnHandling(GetUserEquipmentByRequestQuery query)
        {
            return queryDispatcher
                .Execute(new GetUserEquipmentsQuery())
                .FirstOrDefault(i => i.RequestId == query.RequestId);
        }
    }
}
