using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Requets.Queries.Models;
using EquipmentManagement.Application.Requets.Queries.Results;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;

namespace EquipmentManagement.Application.Requets.Queries.Handlers
{
    public class GetRequestsQueryHandler : QueryHandler<GetRequestsQuery, GetRequestsQueryResult>
    {
        public GetRequestsQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override GetRequestsQueryResult OnHandling(GetRequestsQuery query)
        {
            List<ActiveRequestInfo> requests = (from request in DataContext.Requests
                join user in DataContext.Users on request.UserId equals user.Id
                join assignedUserJoin in DataContext.Users on request.AssignedUserId equals assignedUserJoin.Id into assignedUsers
                    from assignedUser in assignedUsers.DefaultIfEmpty()
                orderby request.RequestedOn descending
                select new ActiveRequestInfo
                {
                    RequestId = request.Id,
                    RequestMessage = request.Message,
                    EquipmentType = request.EquipmentType,
                    UserId = request.UserId,
                    UserName = $"{user.FirstName} {user.LastName}",
                    UserEmail = user.Email,
                    AssignedUserId = request.AssignedUserId,
                    AssignedUserName = assignedUser == null ? "Unknown" : $"{assignedUser.FirstName} {assignedUser.LastName}",
                    AssignedUserEmail = assignedUser == null ? String.Empty : assignedUser.Email,
                    CurrentStatus = request.RequestStatusInfos.OrderByDescending(s => s.UpdatedAt).FirstOrDefault().Status,
                    StatusMessage = request.RequestStatusInfos.OrderByDescending(s => s.UpdatedAt).FirstOrDefault().Message,
                    CreatedOn = request.RequestStatusInfos.FirstOrDefault(s => s.Status == RequestStatus.Pending).UpdatedAt.ToString("g"),
                    UpdatedOn = request.RequestStatusInfos.OrderByDescending(s => s.UpdatedAt).FirstOrDefault().UpdatedAt.ToString("g")
                }).ToList();

            return new GetRequestsQueryResult
            {
                Requests = requests
            };
        }
    }
}
