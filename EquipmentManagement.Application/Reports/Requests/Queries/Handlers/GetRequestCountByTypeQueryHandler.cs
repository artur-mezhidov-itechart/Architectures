using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Reports.Requests.Queries.Models;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;

namespace EquipmentManagement.Application.Reports.Requests.Queries.Handlers
{
    public class GGetRequestCountByTypeQueryHandler : QueryHandler<GetRequestCountByTypeQuery, RequestCountsByType>
    {
        public GGetRequestCountByTypeQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override RequestCountsByType OnHandling(GetRequestCountByTypeQuery query)
        {
            Dictionary<EquipmentType, RequestCountByType> counts = DataContext.Requests
                .GroupBy(i => i.EquipmentType)
                .Select(i => new RequestCountByType
                {
                    Type = i.Key,
                    Count = i.Count()
                })
                .ToDictionary(i => i.Type, j => j);

            RequestCountsByType result = new RequestCountsByType
            {
                FurnituresCount = GetCountByType(counts, EquipmentType.Furniture),
                AccessoriesCount = GetCountByType(counts, EquipmentType.Accessory),
                DevicesCount = GetCountByType(counts, EquipmentType.Device),
                ToolsCount = GetCountByType(counts, EquipmentType.Tools),
            };

            return result;
        }

        private RequestCountByType GetCountByType(Dictionary<EquipmentType, RequestCountByType> counts, EquipmentType type)
        {
            if (counts.ContainsKey(type))
            {
                RequestCountByType count = counts[type];
                count.Percent = CalculatePercent(count.Count, counts.Sum(i => i.Value.Count));
                return count;
            }

            return new RequestCountByType
            {
                Type = type
            };
        }

        private double CalculatePercent(int count, int total)
        {
            return Decimal.ToDouble(Math.Round(count * 100 / (decimal)total, 2));
        }
    }
}
