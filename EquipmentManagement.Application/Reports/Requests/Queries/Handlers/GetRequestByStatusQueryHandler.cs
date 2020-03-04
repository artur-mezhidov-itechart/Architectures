using System;
using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Reports.Requests.Queries.Models;
using EquipmentManagement.Domain.Data;

namespace EquipmentManagement.Application.Reports.Requests.Queries.Handlers
{
    public class GetRequestByStatusQueryHandler : QueryHandler<GetRequestByStatusQuery, RequestByStatuses>
    {
        public GetRequestByStatusQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override RequestByStatuses OnHandling(GetRequestByStatusQuery query)
        {
            var statuses = DataContext.RequestStatusInfo
                .GroupBy(i => i.RequestId)
                .Select(i => i
                    .OrderByDescending(k => k.UpdatedAt)
                    .First()
                )
                .ToList();

            RequestByStatuses result = new RequestByStatuses
            {
                Statuses = statuses
                    .GroupBy(i => i.UpdatedAt.Date.Year)
                    .OrderBy(i => i.Key)
                    .Select(i => new RequestByStatus
                    {
                        Year = i.Key,
                        Values = i
                            .GroupBy(j => j.Status)
                            .Select(j => new RequestByStatusValue
                            {
                                Status = j.Key,
                                Count = j.Count()
                            }).ToList()

                    }).ToList()
            };

            foreach (RequestByStatus status in result.Statuses)
            {
                int total = status.Values.Sum(i => i.Count);

                foreach (RequestByStatusValue value in status.Values)
                {
                    value.Percent = CalculatePercent(value.Count, total);
                }
            }

            return result;
        }

        private double CalculatePercent(int count, int total)
        {
            return Decimal.ToDouble(Math.Round(count * 100 / (decimal)total, 2));
        }
    }
}
