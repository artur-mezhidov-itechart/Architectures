using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EquipmentManagement.Application.Equipments.Queries;
using EquipmentManagement.Application.Requets.Commands;
using EquipmentManagement.Application.Requets.Queries;
using EquipmentManagement.Infrastructura.Commands.Contracts;
using EquipmentManagement.Infrastructura.Queries.Contracts;
using EquipmentManagement.Web.ViewModels.Equipments;
using EquipmentManagement.Web.ViewModels.Requests;

namespace EquipmentManagement.Web.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly IQueryDispatcher queryDispatcher;
        private readonly ICommandDispatcher commandDispatcher;

        public RequestController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult My()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Assigned()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RequestViewModel vm)
        {
            commandDispatcher.Execute(new CreateRequestCommand(vm.Message, vm.EquipmentType));
            return RedirectToAction(nameof(My));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var request = queryDispatcher.Execute(new GetRequestDetailsQuery(id));
            var equipment = queryDispatcher.Execute(new GetUserEquipmentByRequestQuery(id));

            var vm = new RequestDetailsViewModel
            {
                RequestDetails = request,
                UserEquipmentInfo = equipment
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Assigne(int id)
        {
            commandDispatcher.Execute(new AssigneRequestCommand(id));
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public IActionResult Approve(int id)
        {
            var request = queryDispatcher.Execute(new GetRequestDetailsQuery(id));
            var equipments = queryDispatcher.Execute(new GetEquipmentsByTypeQuery(request.EquipmentType));

            var vm = new RequestApproveViewModel
            {
                RequestId = id,
                Request = request,
                Equipments = new EquipmentSelectViewModel(equipments)
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Approve(RequestApproveViewModel vm)
        {
            commandDispatcher.Execute(new ApproveRequestCommand
            {
                RequestId = vm.RequestId,
                EquipmentId = vm.EquipmentId,
                ExpirationDate = vm.ExpirationDate,
                Message = vm.Message
            });

            return RedirectToAction(nameof(Details), new { id = vm.Id });
        }

        [HttpGet]
        public IActionResult Cancel(int id)
        {
            var request = queryDispatcher.Execute(new GetRequestDetailsQuery(id));
            return View(request);
        }

        [HttpPost]
        public IActionResult Cancel(RequestCancelViewModel vm)
        {
            commandDispatcher.Execute(new CancelRequestCommand(vm.Id, vm.Message));
            return RedirectToAction(nameof(Details), new { id = vm.Id });
        }

        [HttpGet]
        public IActionResult Decline(int id)
        {
            var request = queryDispatcher.Execute(new GetRequestDetailsQuery(id));
            return View(request);
        }

        [HttpPost]
        public IActionResult Decline(RequestDeclineViewModel vm)
        {
            commandDispatcher.Execute(new DeclineRequestCommand(vm.Id, vm.Message));
            return RedirectToAction(nameof(Details), new { id = vm.Id });
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            commandDispatcher.Execute(new CompleteRequestCommand(id));
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
