using System.Collections.Generic;
using EquipmentManagement.Application.Requets.Queries.Models;

namespace EquipmentManagement.Application.Requets.Queries.Results
{
    public class GetRequestsQueryResult
    {
        public IEnumerable<ActiveRequestInfo> Requests { get; set; }
    }
}
