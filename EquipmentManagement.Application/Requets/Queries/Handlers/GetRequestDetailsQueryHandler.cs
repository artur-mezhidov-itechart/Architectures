using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Requets.Queries.Models;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Infrastructura.Queries.Contracts;
using EquipmentManagement.Security;

namespace EquipmentManagement.Application.Requets.Queries.Handlers
{
    public class GetRequestDetailsQueryHandler : QueryHandler<GetRequestDetailsQuery, RequestDetails>
    {
        private readonly IUserContext userContext;
        private readonly IQueryDispatcher queryDispatcher;

        public GetRequestDetailsQueryHandler(DataContext dataContext, IUserContext userContext, IQueryDispatcher queryDispatcher) : base(dataContext)
        {
            this.userContext = userContext;
            this.queryDispatcher = queryDispatcher;
        }

        protected override RequestDetails OnHandling(GetRequestDetailsQuery query)
        {
            Request request = DataContext.Requests.Find(query.Id);
            ApplicationUser user = DataContext.Users.Find(request.UserId);
            RequestStatusHistory statuses = queryDispatcher.Execute(new GetRequestStatusHistoryQuery(query.Id));

            return new RequestDetails
            {
                RequestId = request.Id,
                CreatedUserId = user.Id,
                CreatedUserEmail = user.Email,
                CreatedUserName = $"{user.FirstName} {user.LastName}",
                EquipmentType = request.EquipmentType,
                RequestMessage = request.Message,
                StatusesHistory = statuses,
                IsAssignedToMe = userContext.UserId == request.AssignedUserId,
                IsMine = userContext.UserId == request.UserId,
                IsPending = statuses.CurrentStatus == RequestStatus.Pending,
                IsInProgress = statuses.CurrentStatus == RequestStatus.InProgress,
                IsApproved = statuses.CurrentStatus == RequestStatus.Approved,
                IsCompleted = statuses.CurrentStatus == RequestStatus.Completed,
                IsDeclined = statuses.CurrentStatus == RequestStatus.Declined,
                IsCanceled = statuses.CurrentStatus == RequestStatus.Canceled,
            };
        }
    }
}
