using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.Web.Components.Layout
{
    public class HeaderQuickActionComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}