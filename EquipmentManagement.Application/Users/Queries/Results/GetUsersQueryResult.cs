using System.Linq;
using EquipmentManagement.Application.Users.Queries.Models;

namespace EquipmentManagement.Application.Users.Queries.Results
{
    public class GetUsersQueryResult
    {
        public IQueryable<UserInfo> Users { get; set; }
    }
}
