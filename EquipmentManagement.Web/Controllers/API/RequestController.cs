using Microsoft.AspNetCore.Mvc;
using EquipmentManagement.Application.Requets.Queries;
using EquipmentManagement.Infrastructura.Queries.Contracts;

namespace EquipmentManagement.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IQueryDispatcher queryDispatcher;

        public RequestController(IQueryDispatcher queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public IActionResult GetRequests()
        {
            var requests = queryDispatcher.Execute(new GetRequestsQuery());
            return Ok(requests.Requests);
        }

        [HttpGet("assigned")]
        public IActionResult GetAssignedRequests()
        {
            var requests = queryDispatcher.Execute(new GetAssignedRequestsQuery());
            return Ok(requests.MyRequests);
        }

        [HttpGet("active")]
        public IActionResult GetUserActiveRequests()
        {
            var requests = queryDispatcher.Execute(new GetUserActiveRequestsQuery());
            return Ok(requests.Requests);
        }

        [HttpGet("completed")]
        public IActionResult GetUserCompletedRequests()
        {
            var requests = queryDispatcher.Execute(new GetUserCompletedRequestsQuery());
            return Ok(requests.Requests);
        }
    }
}
