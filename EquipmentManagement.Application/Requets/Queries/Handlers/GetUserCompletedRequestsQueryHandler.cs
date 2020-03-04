using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Requets.Queries.Models;
using EquipmentManagement.Application.Requets.Queries.Results;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Security;

namespace EquipmentManagement.Application.Requets.Queries.Handlers
{
    public class GetUserCompletedRequestsQueryHandler : QueryHandler<GetUserCompletedRequestsQuery, GetUserCompletedRequestsQueryResult>
    {
        private readonly IUserContext userContext;

        public GetUserCompletedRequestsQueryHandler(DataContext dataContext, IUserContext userContext) : base(dataContext)
        {
            this.userContext = userContext;
        }

        protected override GetUserCompletedRequestsQueryResult OnHandling(GetUserCompletedRequestsQuery query)
        {
            return new GetUserCompletedRequestsQueryResult
            {
                Requests = DataContext.Requests
                    .Where(i => i.UserId == userContext.UserId && i.RequestStatusInfos.Any(info => info.Status == RequestStatus.Completed))
                    .OrderByDescending(i => i.RequestedOn)
                    .Select(i => new RequestInfo
                    {
                        Id = i.Id,
                        Message = i.Message,
                        EquipmentType = i.EquipmentType,
                        Status = i.RequestStatusInfos.OrderByDescending(j => j.UpdatedAt).First().Status,
                        UpdatedOn = i.RequestStatusInfos.OrderByDescending(j => j.UpdatedAt).First().UpdatedAt
                    })
            };
        }
    }
}
