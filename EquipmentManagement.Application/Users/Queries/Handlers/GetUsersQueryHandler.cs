using System.Linq;
using Microsoft.EntityFrameworkCore;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Users.Queries.Models;
using EquipmentManagement.Application.Users.Queries.Results;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Users.Queries.Handlers
{
    public class GetUsersQueryHandler : QueryHandler<GetUsersQuery, GetUsersQueryResult>
    {
        public GetUsersQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override GetUsersQueryResult OnHandling(GetUsersQuery query)
        {
            var linq = DataContext.Users
                .Select(user => new UserInfo
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    CompanyName = user.CompanyName,
                    CompanySite = user.CompanySite,
                    Country = user.Country,
                    Locality = user.Locality,
                    Post = user.Post,
                    Postcode = user.Postcode,
                    StateOrProvince = user.StateOrProvince,
                    StreetAddress = user.StreetAddress,
                    About = user.About,
                    FurnituresCount = DataContext.UserEquipments.Include(e => e.Equipment)
                        .Count(e => e.UserId == user.Id && e.Equipment.Type == EquipmentType.Furniture),
                    AccessoriesCount = DataContext.UserEquipments.Include(e => e.Equipment)
                        .Count(e => e.UserId == user.Id && e.Equipment.Type == EquipmentType.Accessory),
                    DevicesCount = DataContext.UserEquipments.Include(e => e.Equipment)
                        .Count(e => e.UserId == user.Id && e.Equipment.Type == EquipmentType.Device),
                    ToolsCount = DataContext.UserEquipments.Include(e => e.Equipment)
                        .Count(e => e.UserId == user.Id && e.Equipment.Type == EquipmentType.Tools),
                    Expenses = DataContext.UserEquipments.Include(e => e.Equipment)
                        .Where(e => e.UserId == user.Id).Sum(e => e.Equipment.Price),
                    PendingRequestsCount = DataContext.Requests.Include(r => r.RequestStatusInfos)
                        .Count(r => r.RequestStatusInfos.All(s => s.Status == RequestStatus.Pending))
                });

            return new GetUsersQueryResult
            {
                Users = linq
            };
        }
    }
}
