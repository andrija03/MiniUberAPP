using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands;
using UserService.Application.Dtos; 
using UserService.Application.Services; 
using System;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly CreateUserService _createUserService; 

    public UserController(IMediator mediator, CreateUserService createUserService) 
    {
        _mediator = mediator;
        _createUserService = createUserService; 
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
    {
        await _createUserService.CreateUserAsync(userDto); 
        return Ok(); 
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _mediator.Send(new GetUsersQuery());
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery { Id = id });
        return user != null ? Ok(user) : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _mediator.Send(new DeleteUserCommand { Id = id });
        return NoContent();
    }

    [HttpPost("request")]
    public async Task<ActionResult<bool>> RequestDriver([FromBody] SendRequestToDriverCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
