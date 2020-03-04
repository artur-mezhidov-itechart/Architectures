using System;
using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Equipments.Commands
{
    public class AddUserEquipmentCommand : CommandBase
    {
        public int EquipmentId { get; set; }

        public int RequestId { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
