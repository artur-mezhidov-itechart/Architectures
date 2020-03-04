using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Requets.Queries.Models
{
    public class RequestDetails
    {
        public int RequestId { get; set; }

        public string CreatedUserId { get; set; }

        public string CreatedUserName { get; set; }

        public string CreatedUserEmail { get; set; }

        public string RequestMessage { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public RequestStatusHistory StatusesHistory { get; set; }

        public bool IsAssignedToMe { get; set; }

        public bool IsMine { get; set; }

        public bool IsPending { get; set; }

        public bool IsInProgress { get; set; }

        public bool IsApproved { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsDeclined { get; set; }

        public bool IsCanceled { get; set; }
    }
}
