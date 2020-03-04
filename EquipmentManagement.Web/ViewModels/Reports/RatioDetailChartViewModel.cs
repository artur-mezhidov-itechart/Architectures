using System.Collections.Generic;

namespace EquipmentManagement.Web.ViewModels.Reports
{
    public class RatioDetailChartViewModel
    {
        public string Title { get; set; }

        public string ChartId { get; set; }

        public double? Total { get; set; }

        public string Symbol { get; set; }

        public List<RatioDetailChartItemViewModel> Items { get; set; }
    }
}
