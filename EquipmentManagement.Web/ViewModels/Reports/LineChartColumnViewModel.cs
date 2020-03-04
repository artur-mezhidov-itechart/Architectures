using System.Collections.Generic;

namespace EquipmentManagement.Web.ViewModels.Reports
{
    public class LineChartColumnViewModel
    {
        public string Title { get; set; }

        public IEnumerable<string> Values { get; set; }
    }
}
