using System;
using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Reports.Requests.Queries.Models;
using EquipmentManagement.Domain.Data;

namespace EquipmentManagement.Application.Reports.Requests.Queries.Handlers
{
    public class GetRequestByMonthsQueryHandler : QueryHandler<GetRequestByMonthsQuery, RequestByMonthsList>
    {
        public GetRequestByMonthsQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override RequestByMonthsList OnHandling(GetRequestByMonthsQuery query)
        {
             return new RequestByMonthsList
             {
                 Items = DataContext.Requests
                    .GroupBy(i => i.EquipmentType)
                    .Select(i => new RequestByMonths
                     {
                         Type = i.Key,
                         Counts = i.Select(j => new DateTime(j.RequestedOn.Year, j.RequestedOn.Month, 1))
                            .GroupBy(j => j)
                            .OrderBy(j => j.Key)
                            .Select(j => new RequestCountByMonth
                             {
                                 Date = j.Key,
                                 Count = j.Count()
                             })
                     }).ToList()
             };
        }
    }
}
