using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using EquipmentManagement.Application.Requets.Queries.Models;

namespace EquipmentManagement.Web.ViewModels.Requests
{
    public class RequestApproveViewModel : ViewModelBase
    {
        public int RequestId { get; set; }

        public string Message { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int EquipmentId { get; set; }

        public RequestDetails Request { get; set; }

        public SelectList Equipments { get; set; }
    }
}
