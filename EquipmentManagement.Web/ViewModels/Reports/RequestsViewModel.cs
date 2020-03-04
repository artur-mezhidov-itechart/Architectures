namespace EquipmentManagement.Web.ViewModels.Reports
{
    public class RequestsViewModel
    {
        public ProgressPercentChartViewModel FurnitureRequestCount { get; set; }

        public ProgressPercentChartViewModel DeviceRequestCount { get; set; }

        public ProgressPercentChartViewModel AccessoryRequestCount { get; set; }

        public ProgressPercentChartViewModel ToolsRequestCount { get; set; }

        public LineChartViewModel RequestsLineChartByEquipmentType { get; set; }

        public AmChartViewModel AmChartByRequestStatus { get; set; }
    }
}
