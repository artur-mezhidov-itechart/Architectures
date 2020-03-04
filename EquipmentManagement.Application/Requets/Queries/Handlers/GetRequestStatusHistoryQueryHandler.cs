using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Requets.Queries.Models;
using EquipmentManagement.Domain.Data;

namespace EquipmentManagement.Application.Requets.Queries.Handlers
{
    public class GetRequestStatusHistoryQueryHandler : QueryHandler<GetRequestStatusHistoryQuery, RequestStatusHistory>
    {
        public GetRequestStatusHistoryQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override RequestStatusHistory OnHandling(GetRequestStatusHistoryQuery query)
        {
            var statuses = (from status in DataContext.RequestStatusInfo
                join user in DataContext.Users on status.UpdatedBy equals user.Id
                where status.RequestId == query.RequestId
                orderby status.UpdatedAt
                select new RequestStatusDetails
                {
                    Id = status.Id,
                    UpdatedUserId = status.UpdatedBy,
                    Message = status.Message,
                    UpdatedAt = status.UpdatedAt,
                    Status = status.Status,
                    UpdatedUserEmail = user.Email,
                    UpdatedUserName = $"{user.FirstName} {user.LastName}"
                })
                .ToArray();

            var currentStatus = statuses
                .OrderByDescending(i => i.UpdatedAt)
                .Select(i => i.Status)
                .FirstOrDefault();

            return new RequestStatusHistory
            {
                CurrentStatus = currentStatus,
                Statuses = statuses
            };
        }
    }
}
