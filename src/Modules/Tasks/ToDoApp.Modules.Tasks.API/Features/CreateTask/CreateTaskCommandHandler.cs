using MediatR;
using ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Tasks.API.Models.Entities;
using ToDoApp.Modules.Tasks.API.Models.Exceptions;

namespace ToDoApp.Modules.Tasks.API.Features.CreateTask;

public class CreateToDoCommandHandler : IRequestHandler<CreateTaskCommand>
{
	private readonly ITasksCommandRepository _commandRepository;
	private readonly IUsersApiClient _usersApiClient;

	public CreateToDoCommandHandler(ITasksCommandRepository commandRepository, IUsersApiClient usersApiClient)
	{
		_commandRepository = commandRepository;
		_usersApiClient = usersApiClient;
	}

	public async Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
	{
		var user = await _usersApiClient.GetUser(request.Username);
		if (user is null)
		{
			throw new UserNotFoundException(request.Username);
		}

		var toDo = new ToDoItem(request.Id, request.Description, request.Username);
		await _commandRepository.CreateToDo(toDo);
	}
}
