using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.Web.Components.Layout
{
    public class AsideComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
