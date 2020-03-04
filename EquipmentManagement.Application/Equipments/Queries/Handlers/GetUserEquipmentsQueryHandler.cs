using System;
using System.Linq;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Equipments.Queries.Models;
using EquipmentManagement.Domain.Data;

namespace EquipmentManagement.Application.Equipments.Queries.Handlers
{
    public class GetUserEquipmentsQueryHandler : QueryHandler<GetUserEquipmentsQuery, IQueryable<UserEquipmentInfo>>
    {
        public GetUserEquipmentsQueryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        protected override IQueryable<UserEquipmentInfo> OnHandling(GetUserEquipmentsQuery query)
        {
            var linq = from equipment in DataContext.Equipments
                join userEquipment in DataContext.UserEquipments on equipment.Id equals userEquipment.EquipmentId
                select new UserEquipmentInfo
                {
                    EquipmentId = equipment.Id,
                    EquipmentName = equipment.Name,
                    EquipmentPrice = equipment.Price,
                    EquipmentType = equipment.Type,
                    UserId = userEquipment.UserId,
                    RequestId = userEquipment.RequestId,
                    UserEquipmentId = userEquipment.Id,
                    ReceivedDate = userEquipment.ReceivedDate,
                    ExpirationDate = userEquipment.ExpirationDate,
                    IsReturned = userEquipment.IsReturned,
                    IsExpired = userEquipment.ExpirationDate < DateTime.Now
                };

            return linq;
        }
    }
}
