using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Reports.Equipments.Queries.Models;
using EquipmentManagement.Domain.Data;

namespace EquipmentManagement.Application.Reports.Equipments.Queries.Handlers
{
    public class GetRatioOfEquipmentsCountQueryHandler : QueryHandler<GetRatioOfEquipmentsCountQuery, RatioOfEquipments>
    {
        public GetRatioOfEquipmentsCountQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override RatioOfEquipments OnHandling(GetRatioOfEquipmentsCountQuery query)
        {
            RatioOfEquipments ration = new RatioOfEquipments
            {
                Items = DataContext.UserEquipments
                    .Include(i => i.Equipment)
                    .AsNoTracking()
                    .GroupBy(i => i.Equipment.Type)
                    .Select(i => new RatioOfEquipment
                    {
                        Type = i.Key,
                        Value = i.Count()
                    })
                    .ToList()
            };

            ration.Total = ration.Items.Sum(i => i.Value);

            if (ration.Total > 0)
            {
                foreach (RatioOfEquipment item in ration.Items)
                {
                    item.PercentValue = Decimal.ToDouble(Math.Round((decimal)(item.Value * 100 / ration.Total), 2));
                }
            }

            return ration;
        }
    }
}
