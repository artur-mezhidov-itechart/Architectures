using System.Collections.Generic;

namespace EquipmentManagement.Web.ViewModels.Reports
{
    public class AmChartDataViewModel
    {
        public int First { get; set; }

        public int Last { get; set; }

        public Dictionary<int, AmChartSectorViewModel[]> Sectors { get; set; }
    }
}
