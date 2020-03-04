using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EquipmentManagement.Application.Profile.Commands;
using EquipmentManagement.Infrastructura.Commands.Contracts;
using EquipmentManagement.Security;
using EquipmentManagement.Web.ViewModels.Profile;

namespace EquipmentManagement.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserContext userContext;
        private readonly ICommandDispatcher commandDispatcher;

        public ProfileController(IUserContext userContext, ICommandDispatcher commandDispatcher)
        {
            this.userContext = userContext;
            this.commandDispatcher = commandDispatcher;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Personal()
        {
            PersonalViewModel vm = new PersonalViewModel
            {
                Email = userContext.Email,
                PhoneNumber = userContext.PhoneNumber,
                FirstName = userContext.FirstName,
                LastName = userContext.LastName,
                CompanyName = userContext.CompanyName,
                CompanySite = userContext.CompanySite,
                Post = userContext.Post,
                About = userContext.About
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Personal(PersonalViewModel vm)
        {
            commandDispatcher.Execute(new UpdatePersonalCommand
            {
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                CompanyName = vm.CompanyName,
                CompanySite = vm.CompanySite,
                Post = vm.Post,
                About = vm.About
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Location()
        {
            LocationViewModel vm = new LocationViewModel
            {
                Country = userContext.Country,
                StreetAddress = userContext.StreetAddress,
                Locality = userContext.Locality,
                StateOrProvince = userContext.StateOrProvince,
                Postcode = userContext.Postcode
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Location(LocationViewModel vm)
        {
            commandDispatcher.Execute(new UpdateLocationCommand
            {
                Country = vm.Country,
                StreetAddress = vm.StreetAddress,
                Locality = vm.Locality,
                StateOrProvince = vm.StateOrProvince,
                Postcode = vm.Postcode
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
