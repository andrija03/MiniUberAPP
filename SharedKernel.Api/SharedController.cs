using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Commands;
using SharedKernel.Queries;


namespace SharedKernel.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class SharedController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SharedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestCommand command)
        {
            var zahtevId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRequestById), new { id = zahtevId }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(Guid id, [FromBody] UpdateRequestCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestById(Guid id)
        {
            var request = await _mediator.Send(new GetRequestByIdQuery { Id = id });
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }
    }
}
