using EquipmentManagement.Application.Equipments.Queries.Models;
using EquipmentManagement.Infrastructura.Queries;

namespace EquipmentManagement.Application.Equipments.Queries
{
    public class GetUserEquipmentByRequestQuery : QueryBase<UserEquipmentInfo>
    {
        public int RequestId { get; }

        public GetUserEquipmentByRequestQuery(int requestId)
        {
            RequestId = requestId;
        }
    }
}
