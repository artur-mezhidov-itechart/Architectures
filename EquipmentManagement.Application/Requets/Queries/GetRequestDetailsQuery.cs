using EquipmentManagement.Application.Requets.Queries.Models;
using EquipmentManagement.Infrastructura.Queries;

namespace EquipmentManagement.Application.Requets.Queries
{
    public class GetRequestDetailsQuery : QueryBase<RequestDetails>
    {
        public int Id { get; }

        public GetRequestDetailsQuery(int id)
        {
            Id = id;
        }
    }
}
