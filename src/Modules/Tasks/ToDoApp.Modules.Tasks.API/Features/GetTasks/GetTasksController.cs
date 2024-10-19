using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Modules.Tasks.API.Features.GetTasks;

[Route("api/tasks")]
[ApiController]
[Authorize]
public class GetTasksController : ControllerBase
{
	private readonly IMediator _mediator;

	public GetTasksController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetTasks()
	{
		var result = await _mediator.Send(new GetTasksQuery(User.Identity.Name));
		return Ok(result);
	}
}