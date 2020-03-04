using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Equipments.Queries.Models;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Queries.Contracts;
using EquipmentManagement.Security;

namespace EquipmentManagement.Application.Equipments.Queries.Handlers
{
    public class GetMyEquipmentsQueryHandler : QueryHandler<GetMyEquipmentsQuery, IQueryable<UserEquipmentInfo>>
    {
        private readonly IUserContext userContext;
        private readonly IQueryDispatcher queryDispatcher;

        public GetMyEquipmentsQueryHandler(DataContext dataContext, IUserContext userContext, IQueryDispatcher queryDispatcher) : base(dataContext)
        {
            this.userContext = userContext;
            this.queryDispatcher = queryDispatcher;
        }

        protected override IQueryable<UserEquipmentInfo> OnHandling(GetMyEquipmentsQuery query)
        {
            return queryDispatcher.Execute(new GetUserEquipmentsByUserQuery(userContext.UserId));
        }
    }
}
