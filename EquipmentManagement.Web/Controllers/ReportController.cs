using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EquipmentManagement.Application.Reports.Equipments.Queries;
using EquipmentManagement.Application.Reports.Equipments.Queries.Models;
using EquipmentManagement.Application.Reports.Requests.Queries;
using EquipmentManagement.Application.Reports.Requests.Queries.Models;
using EquipmentManagement.Infrastructura.Queries.Contracts;
using EquipmentManagement.Web.Extensions;
using EquipmentManagement.Web.ViewModels.Reports;

namespace EquipmentManagement.Web.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IQueryDispatcher queryDispatcher;

        public ReportController(IQueryDispatcher queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
        }

        public IActionResult Requests()
        {
            var reports = queryDispatcher.Execute(new GetRequestReportsQuery());
            return View(ToViewModel(reports));
        }

        public IActionResult Equipments()
        {
            var reports = queryDispatcher.Execute(new GetEquipmentReportsQuery());
            return View(ToViewModel(reports));
        }

        #region Helpers

        private EquipmentsViewModel ToViewModel(EquipmentReports reports)
        {
            return new EquipmentsViewModel
            {
                Total = reports.Total,
                UserFurnitures = CreateViewModel(reports.UserEquipmentsCount.Furnitures, "Furnitures"),
                UserDevices = CreateViewModel(reports.UserEquipmentsCount.Devices, "Devices"),
                UserAccessories = CreateViewModel(reports.UserEquipmentsCount.Accessories, "Accessories"),
                UserTools = CreateViewModel(reports.UserEquipmentsCount.Tools, "Tools"),
                RatioOfCount = CreateViewModel(reports.RatioOfCount, "count"),
                RatioOfPrice = CreateViewModel(reports.RatioOfPrice, "price", "$")
            };
        }

        private RatioDetailChartViewModel CreateViewModel(RatioOfEquipments model, string title, string symbol = null)
        {
            return new RatioDetailChartViewModel
            {
                Title = $"Ratio of user equipments {title}",
                ChartId = $"ratio-user-equipments-{title}",
                Symbol = symbol,
                Total = model.Total,
                Items = model.Items.Select(ToViewModel).ToList()
            };
        }

        private RatioDetailChartItemViewModel ToViewModel(RatioOfEquipment model)
        {
            return new RatioDetailChartItemViewModel
            {
                Label = model.Type.ToString(),
                Count = model.Value,
                Value = model.PercentValue,
                Type = model.Type.GetColorState()
            };
        }

        private UserEquipmentChartViewModel CreateViewModel(UserEquipmentCount count, string title)
        {
            return new UserEquipmentChartViewModel
            {
                UserEquipmentCount = count,
                Type = count.Type.GetColorState(),
                Title = $"User {title}",
                Label = $"Issued {title.ToLower()} count",
                ChartId = $"user-equipment-{title.ToLower()}-chart"
                
            };
        }

        private RequestsViewModel ToViewModel(RequestReports reports)
        {
            return new RequestsViewModel
            {
                FurnitureRequestCount = CreateViewModel(reports.RequestCountByType.FurnituresCount),
                AccessoryRequestCount = CreateViewModel(reports.RequestCountByType.AccessoriesCount),
                DeviceRequestCount = CreateViewModel(reports.RequestCountByType.DevicesCount),
                ToolsRequestCount = CreateViewModel(reports.RequestCountByType.ToolsCount),
                RequestsLineChartByEquipmentType = CreateViewModel(reports.RequestByMonths),
                AmChartByRequestStatus = CreateViewModel(reports.RequestByStatuses)
            };
        }

        private ProgressPercentChartViewModel CreateViewModel(RequestCountByType requests)
        {
            return new ProgressPercentChartViewModel
            {
                Value = requests.Count,
                Percent = requests.Percent,
                ColorState = requests.Type.GetColorState(),
                Title = $"Requests for {requests.Type.ToString().ToLower()}",
                SubTitle = $"All requests for {requests.Type.ToString().ToLower()}"
            };
        }

        private LineChartViewModel CreateViewModel(RequestByMonthsList list)
        {
            return new LineChartViewModel
            {
                Title = "Requests statistics",
                ChartTitle = "Requests line chart by equipment types",
                ChartSubTitle = "furnitures, accessories, devices, tools",
                ChartId = "requests-line-chart-by-equipment-type",
                Columns = list.Items
                    .Select(i => new LineChartColumnViewModel
                    {
                        Title = i.Type.ToString(),
                        Values = i.Counts
                            .Select(j => j.Count.ToString())
                    }),
                XValues = new LineChartColumnViewModel
                {
                    Title = "Month",
                    Values = list.Items
                        .FirstOrDefault()
                        ?.Counts
                        .Select(i => i.Date.ToString("Y"))
                }
            };
        }

        private AmChartViewModel CreateViewModel(RequestByStatuses statuses)
        {
            return new AmChartViewModel
            {
                Title = "Requests by statuses, yearly",
                ChartId = "requests-am-chart-by-statuses",
                Data = new AmChartDataViewModel
                {
                    Sectors = statuses.Statuses
                        .ToDictionary(i => i.Year, j => j.Values.Select(k => new AmChartSectorViewModel
                        {
                            Sector = k.Status.ToString(),
                            Size = k.Percent
                        }).ToArray()),
                    First = statuses.Statuses
                        .OrderBy(i => i.Year)
                        .First()
                        .Year,
                    Last = statuses.Statuses
                        .OrderBy(i => i.Year)
                        .Last()
                        .Year
                }
            };
        }

        #endregion
    }
}
