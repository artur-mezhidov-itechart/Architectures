using EquipmentManagement.Domain;

namespace EquipmentManagement.Web.Extensions
{
    public static class EnumExtensions
    {
        public static string GetColorState(this EquipmentType type)
        {
            switch (type)
            {
                case EquipmentType.Furniture: return "brand";
                case EquipmentType.Device: return "danger";
                case EquipmentType.Accessory: return "warning";
                default: return "success";
            }
        }

        public static string GetColorState(this RequestStatus status)
        {
            switch (status)
            {
                case RequestStatus.Pending: return "warning";
                case RequestStatus.InProgress: return "info";
                case RequestStatus.Approved: return "success";
                case RequestStatus.Declined: return "danger";
                case RequestStatus.Completed: return "primary";
                default: return "dark";
            }
        }
    }
}
