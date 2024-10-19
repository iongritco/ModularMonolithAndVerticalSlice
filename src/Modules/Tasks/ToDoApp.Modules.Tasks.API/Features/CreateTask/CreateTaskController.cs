using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Modules.Tasks.API.Features.CreateTask;

[Route("api/tasks")]
[ApiController]
[Authorize]
public class CreateTaskController : ControllerBase
{
	private readonly IMediator _mediator;

	public CreateTaskController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPost]
	public async Task<IActionResult> CreateTask(CreateTaskCommand command)
	{
		command.Username = User.Identity.Name;
		await _mediator.Send(command);
		return Ok();
	}
}