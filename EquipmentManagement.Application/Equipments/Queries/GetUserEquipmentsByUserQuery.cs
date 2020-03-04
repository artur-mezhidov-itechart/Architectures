using System.Linq;
using EquipmentManagement.Application.Equipments.Queries.Models;
using EquipmentManagement.Infrastructura.Queries;

namespace EquipmentManagement.Application.Equipments.Queries
{
    public class GetUserEquipmentsByUserQuery : QueryBase<IQueryable<UserEquipmentInfo>>
    {
        public string UserId { get; }

        public GetUserEquipmentsByUserQuery(string userId)
        {
            UserId = userId;
        }
    }
}
