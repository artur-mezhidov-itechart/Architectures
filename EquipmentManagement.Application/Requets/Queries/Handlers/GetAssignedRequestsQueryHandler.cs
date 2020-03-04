using System.Collections.Generic;
using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Requets.Queries.Models;
using EquipmentManagement.Application.Requets.Queries.Results;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Queries.Contracts;
using EquipmentManagement.Security;

namespace EquipmentManagement.Application.Requets.Queries.Handlers
{
    public class GetAssignedRequestsQueryHandler : QueryHandler<GetAssignedRequestsQuery, GetAssignedRequestsQueryResult>
    {
        private readonly IUserContext userContext;
        private readonly IQueryDispatcher queryDispatcher;

        public GetAssignedRequestsQueryHandler(DataContext dataContext, IUserContext userContext, IQueryDispatcher queryDispatcher) : base(dataContext)
        {
            this.userContext = userContext;
            this.queryDispatcher = queryDispatcher;
        }

        protected override GetAssignedRequestsQueryResult OnHandling(GetAssignedRequestsQuery query)
        {
            List<ActiveRequestInfo> requests = queryDispatcher
                .Execute(new GetRequestsQuery())
                .Requests
                .Where(r => r.AssignedUserId == userContext.UserId)
                .ToList();

            return new GetAssignedRequestsQueryResult
            {
                MyRequests = requests
            };
        }
    }
}
