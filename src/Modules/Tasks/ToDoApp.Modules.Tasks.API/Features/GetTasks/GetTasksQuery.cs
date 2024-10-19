using MediatR;
using ToDoApp.Modules.Tasks.API.Models.Entities;

namespace ToDoApp.Modules.Tasks.API.Features.GetTasks;

public class GetTasksQuery : IRequest<List<ToDoItem>>
{
	public GetTasksQuery(string username)
	{
		Username = username;
	}

	public string Username { get; }
}
