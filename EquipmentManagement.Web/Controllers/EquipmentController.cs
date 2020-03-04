using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EquipmentManagement.Application.Equipments.Commands;
using EquipmentManagement.Application.Equipments.Queries;
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Infrastructura.Commands.Contracts;
using EquipmentManagement.Infrastructura.Queries.Contracts;
using EquipmentManagement.Web.ViewModels.Equipments;

namespace EquipmentManagement.Web.Controllers
{
    [Authorize]
    public class EquipmentController : Controller
    {
        private readonly ICommandDispatcher commandDispatcher;
        private readonly IQueryDispatcher queryDispatcher;

        public EquipmentController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
            this.queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyEquipments()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserEquipments()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EquipmentViewModel vm)
        {
            commandDispatcher.Execute(new AddEquipmentCommand(vm.Name, vm.Price, vm.Type));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Equipment equipment = queryDispatcher.Execute(new GetEquipmentByIdQuery(id));
            return View(ToViewModel(equipment));
        }

        [HttpPost]
        public IActionResult Edit(EquipmentViewModel vm)
        {
            commandDispatcher.Execute(new UpdateEquipmentCommand(vm.Id, vm.Name, vm.Price, vm.Type));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            commandDispatcher.Execute(new DeleteEquipmentCommand(id));
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Return(int requestId)
        {
            commandDispatcher.Execute(new ReturnEquipmentCommand(requestId));
            return RedirectToAction(nameof(RequestController.Details), "Request", new { id = requestId });
        }

        #region Helpers

        private EquipmentViewModel ToViewModel(Equipment equipment)
        {
            return new EquipmentViewModel
            {
                Id = equipment.Id,
                Name = equipment.Name,
                Price = equipment.Price,
                Type = equipment.Type
            };
        }

        #endregion
    }
}
