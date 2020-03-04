using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Reports.Requests.Queries.Models;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Queries.Contracts;

namespace EquipmentManagement.Application.Reports.Requests.Queries.Handlers
{
    public class GetRequestReportsQueryHandler : QueryHandler<GetRequestReportsQuery, RequestReports>
    {
        private readonly IQueryDispatcher queryDispatcher;

        public GetRequestReportsQueryHandler(DataContext dataContext, IQueryDispatcher queryDispatcher) : base(dataContext)
        {
            this.queryDispatcher = queryDispatcher;
        }

        protected override RequestReports OnHandling(GetRequestReportsQuery query)
        {
             return new RequestReports
             {
                 RequestCountByType = queryDispatcher.Execute(new GetRequestCountByTypeQuery()),
                 RequestByMonths = queryDispatcher.Execute(new GetRequestByMonthsQuery()),
                 RequestByStatuses = queryDispatcher.Execute(new GetRequestByStatusQuery())
             };
        }
    }
}
