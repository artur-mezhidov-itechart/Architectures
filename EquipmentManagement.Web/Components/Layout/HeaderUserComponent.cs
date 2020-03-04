using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.Web.Components.Layout
{
    public class HeaderUserComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
