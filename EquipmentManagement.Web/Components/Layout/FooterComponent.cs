using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.Web.Components.Layout
{
    public class FooterComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
