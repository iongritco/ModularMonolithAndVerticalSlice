using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Modules.Tasks.API.Features.UpdateTask;

[Route("api/tasks")]
[ApiController]
[Authorize]
public class UpdateTaskController : ControllerBase
{
	private readonly IMediator _mediator;

	public UpdateTaskController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPut]
	public async Task<IActionResult> UpdateTask(UpdateTaskCommand command)
	{
		command.Username = User.Identity.Name;
		await _mediator.Send(command);
		return Ok();
	}
}