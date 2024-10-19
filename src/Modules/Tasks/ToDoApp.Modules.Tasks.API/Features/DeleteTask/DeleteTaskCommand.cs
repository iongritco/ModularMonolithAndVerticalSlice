using MediatR;

namespace ToDoApp.Modules.Tasks.API.Features.DeleteTask;

public class DeleteToDoCommand : IRequest
{
	public DeleteToDoCommand(Guid id, string username)
	{
		Id = id;
		Username = username;
	}

	public Guid Id { get; }

	public string Username { get; }
}
