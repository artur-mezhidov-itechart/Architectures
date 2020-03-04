using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Requets.Queries.Models;
using EquipmentManagement.Application.Requets.Queries.Results;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Security;

namespace EquipmentManagement.Application.Requets.Queries.Handlers
{
    public class GetUserActiveRequestsQueryHandler : QueryHandler<GetUserActiveRequestsQuery, GetUserActiveRequestsQueryResult>
    {
        private readonly IUserContext userContext;

        public GetUserActiveRequestsQueryHandler(DataContext dataContext, IUserContext userContext) : base(dataContext)
        {
            this.userContext = userContext;
        }

        protected override GetUserActiveRequestsQueryResult OnHandling(GetUserActiveRequestsQuery query)
        {
            return new GetUserActiveRequestsQueryResult
            {
                Requests = DataContext.Requests
                    .Where(i => i.UserId == userContext.UserId && i.RequestStatusInfos.All(info => info.Status != RequestStatus.Completed))
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
