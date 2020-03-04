using EquipmentManagement.Application.Common;
using EquipmentManagement.Application.Reports.Equipments.Queries.Models;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Queries.Contracts;

namespace EquipmentManagement.Application.Reports.Equipments.Queries.Handlers
{
    public class GetEquipmentReportsQueryHandler : QueryHandler<GetEquipmentReportsQuery, EquipmentReports>
    {
        private readonly IQueryDispatcher queryDispatcher;

        public GetEquipmentReportsQueryHandler(DataContext dataContext, IQueryDispatcher queryDispatcher) : base(dataContext)
        {
            this.queryDispatcher = queryDispatcher;
        }

        protected override EquipmentReports OnHandling(GetEquipmentReportsQuery query)
        {
             return new EquipmentReports
             {
                 Total = queryDispatcher.Execute(new GetTotalEquipmentsQuery()),
                 UserEquipmentsCount = queryDispatcher.Execute(new GetUserEquipmentsCountQuery()),
                 RatioOfCount = queryDispatcher.Execute(new GetRatioOfEquipmentsCountQuery()),
                 RatioOfPrice = queryDispatcher.Execute(new GetRatioOfEquipmentsPriceQuery())
             };
        }
    }
}
