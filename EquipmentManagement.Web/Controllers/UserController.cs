using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EquipmentManagement.Infrastructura.Queries.Contracts;
using EquipmentManagement.Web.ViewModels.Users;
using EquipmentManagement.Application.Users.Queries;

namespace EquipmentManagement.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IQueryDispatcher queryDispatcher;

        public UserController(IQueryDispatcher queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = queryDispatcher.Execute(new GetUsersQuery());
            var vm = new UserListViewModel { Users = users.Users };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Profile(string id)
        {
            return View(nameof(Index));
        }
    }
}
