using System.Collections.Generic;

namespace EquipmentManagement.Web.ViewModels.Reports
{
    public class LineChartViewModel
    {
        public string Title { get; set; }

        public string ChartTitle { get; set; }

        public string ChartSubTitle { get; set; }

        public string ChartId { get; set; }

        public LineChartColumnViewModel XValues { get; set; }

        public IEnumerable<LineChartColumnViewModel> Columns { get; set; }
    }
}
