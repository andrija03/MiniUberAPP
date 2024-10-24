using MediatR;
using Microsoft.AspNetCore.Mvc;
using DriverService.Application.Commands;
using DriverService.Application.Queries;

[ApiController]
[Route("api/[controller]")]
public class DriverController : ControllerBase
{
    private readonly IMediator _mediator;

    public DriverController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterDriver([FromBody] RegisterDriverCommand command)
    {
        var driverId = await _mediator.Send(command);
        return Ok(driverId);
    }

    [HttpPost("register-vehicle")]
    public async Task<IActionResult> RegisterVehicle([FromBody] RegisterVehicleCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var vehicleId = await _mediator.Send(command);
        return Ok(vehicleId);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableDrivers()
    {
        var drivers = await _mediator.Send(new GetAvailableDriversQuery());
        return Ok(drivers);
    }

    [HttpPost("respond")]
    public async Task<ActionResult<bool>> RespondToRequest([FromBody] RespondToRideRequestCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPost("request-driver")]
    public async Task<IActionResult> RequestDriver([FromBody] SendRequestToDriverCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var success = await _mediator.Send(command);
        return success ? Ok() : BadRequest("Failed to send request to driver.");
    }
}

