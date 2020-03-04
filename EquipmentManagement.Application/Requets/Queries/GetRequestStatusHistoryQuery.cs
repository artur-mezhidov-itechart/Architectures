using EquipmentManagement.Application.Requets.Queries.Models;
using EquipmentManagement.Infrastructura.Queries;

namespace EquipmentManagement.Application.Requets.Queries
{
    public class GetRequestStatusHistoryQuery : QueryBase<RequestStatusHistory>
    {
        public int RequestId { get; }

        public GetRequestStatusHistoryQuery(int requestId)
        {
            RequestId = requestId;
        }
    }
}
