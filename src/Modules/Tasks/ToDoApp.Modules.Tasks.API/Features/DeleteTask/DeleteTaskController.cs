using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Modules.Tasks.API.Features.DeleteTask;

[Route("api/tasks")]
[ApiController]
[Authorize]
public class DeleteTaskController : ControllerBase
{
	private readonly IMediator _mediator;

	public DeleteTaskController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpDelete]
	[Route("{id:guid}")]
	public async Task<IActionResult> DeleteTask(Guid id)
	{
		var command = new DeleteToDoCommand(id, User.Identity.Name);
		await _mediator.Send(command);
		return Ok();
	}
}