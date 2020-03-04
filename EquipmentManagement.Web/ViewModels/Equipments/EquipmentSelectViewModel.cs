using System.Collections.Generic;
using EquipmentManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EquipmentManagement.Web.ViewModels.Equipments
{
    public class EquipmentSelectViewModel : SelectList
    {
        public EquipmentSelectViewModel(IEnumerable<Equipment> equipments) : base(equipments, "Id", "Name")
        {
        }
    }
}
