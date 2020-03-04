using Microsoft.AspNetCore.Mvc;
using EquipmentManagement.Infrastructura.Queries.Contracts;
using EquipmentManagement.Application.Equipments.Queries;

namespace EquipmentManagement.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IQueryDispatcher queryDispatcher;

        public EquipmentController(IQueryDispatcher queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public IActionResult All()
        {
            var data = queryDispatcher.Execute(new GetEquipmentsQuery());
            return Ok(data);
        }

        [HttpGet("my")]
        public IActionResult My()
        {
            var data = queryDispatcher.Execute(new GetMyEquipmentsQuery());
            return Ok(data);
        }

        [HttpGet("users")]
        public IActionResult Users()
        {
            var data = queryDispatcher.Execute(new GetUserEquipmentsQuery());
            return Ok(data);
        }
    }
}
