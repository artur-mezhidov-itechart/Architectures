using System;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Equipments.Queries.Models
{
    public class UserEquipmentInfo
    {
        public string UserId { get; set; }

        public int RequestId { get; set; }

        public int EquipmentId { get; set; }

        public string EquipmentName { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public double EquipmentPrice { get; set; }

        public int UserEquipmentId { get; set; }

        public bool IsReturned { get; set; }

        public bool IsExpired { get; set; }

        public DateTime ReceivedDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
