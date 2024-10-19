using MediatR;
using ToDoApp.Modules.Tasks.API.Models.Enums;

namespace ToDoApp.Modules.Tasks.API.Features.UpdateTask;

public class UpdateTaskCommand : IRequest
{
	public Guid Id { get; set; }

	public string Description { get; set; }

	public Status Status { get; set; }

	public string Username { get; set; }
}
