using System.Collections.Generic;
using EquipmentManagement.Application.Requets.Queries.Models;

namespace EquipmentManagement.Application.Requets.Queries.Results
{
    public class GetAssignedRequestsQueryResult
    {
        public IEnumerable<ActiveRequestInfo> MyRequests { get; set; }
    }
}
