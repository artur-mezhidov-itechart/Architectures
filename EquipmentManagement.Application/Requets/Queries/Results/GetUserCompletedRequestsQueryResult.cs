using System.Linq;
using EquipmentManagement.Application.Requets.Queries.Models;

namespace EquipmentManagement.Application.Requets.Queries.Results
{
    public class GetUserCompletedRequestsQueryResult
    {
        public IQueryable<RequestInfo> Requests { get; set; }
    }
}
