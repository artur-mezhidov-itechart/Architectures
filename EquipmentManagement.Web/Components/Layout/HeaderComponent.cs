﻿using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.Web.Components.Layout
{
    public class HeaderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
