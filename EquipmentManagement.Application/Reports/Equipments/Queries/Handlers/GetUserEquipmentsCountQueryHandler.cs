using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Reports.Equipments.Queries.Models;
using EquipmentManagement.Domain;
using EquipmentManagement.Domain.Data;

namespace EquipmentManagement.Application.Reports.Equipments.Queries.Handlers
{
    public class GetUserEquipmentsCountQueryHandler : QueryHandler<GetUserEquipmentsCountQuery, UserEquipmentsCount>
    {
        public GetUserEquipmentsCountQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override UserEquipmentsCount OnHandling(GetUserEquipmentsCountQuery query)
        {
            Dictionary<EquipmentType, UserEquipmentCount> equipments = GetUserEquipmentCount();

            return new UserEquipmentsCount
            {
                Furnitures = CreateUserEquipmentCount(EquipmentType.Furniture, equipments),
                Accessories = CreateUserEquipmentCount(EquipmentType.Accessory, equipments),
                Devices = CreateUserEquipmentCount(EquipmentType.Device, equipments),
                Tools = CreateUserEquipmentCount(EquipmentType.Tools, equipments)
            };
        }

        private Dictionary<EquipmentType, UserEquipmentCount> GetUserEquipmentCount()
        {
            return DataContext.Equipments
                .Include(i => i.UserEquipments)
                .GroupBy(i => i.Type)
                .Select(i => new UserEquipmentCount
                {
                    Type = i.Key,
                    TotalCount = i.Sum(k => k.UserEquipments.Count),
                    Items = i.SelectMany(j => j.UserEquipments)
                        .Select(j => new DateTime(j.ReceivedDate.Year, j.ReceivedDate.Month, 1))
                        .GroupBy(j => j)
                        .OrderBy(j => j.Key)
                        .Select(j => new UserEquipmentCountItem
                        {
                            Label = j.Key.ToString("Y"),
                            Value = j.Count()
                        })
                })
                .ToDictionary(i => i.Type, j => j);
        }

        private UserEquipmentCount CreateUserEquipmentCount(EquipmentType type, Dictionary<EquipmentType, UserEquipmentCount> equipments)
        {
            return equipments.ContainsKey(type)
                ? equipments[type]
                : new UserEquipmentCount
                    {
                        Type = type,
                        TotalCount = 0,
                        Items = new List<UserEquipmentCountItem>()
                    };
        }
    }
}
