using System;
using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Requets.Commands
{
    public class ApproveRequestCommand : CommandBase
    {
        public int RequestId { get; set; }

        public string Message { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int EquipmentId { get; set; }
    }
}
