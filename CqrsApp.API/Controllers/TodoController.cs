using CqrsApp.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CqrsApp.API.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodoController : ControllerBase
    {
        public readonly IMediator _mediator;

        public TodoController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetTodosById.Query(id));

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAll.Query());

            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Commands.AddTodo.Command command)
        {
            var response = await _mediator.Send(command);

            return response == null ? NotFound() : Ok(response);
        }
    }
}