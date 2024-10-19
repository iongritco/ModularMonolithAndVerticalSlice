using MediatR;

namespace ToDoApp.Modules.Tasks.API.Features.CreateTask;

public class CreateTaskCommand : IRequest
{
	public Guid Id { get; set; }

	public string Description { get; set; }

	public string Username { get; set; }
}
