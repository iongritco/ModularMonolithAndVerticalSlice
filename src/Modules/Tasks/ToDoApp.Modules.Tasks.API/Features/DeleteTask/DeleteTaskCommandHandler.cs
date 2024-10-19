﻿using MediatR;
using ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Tasks.API.Models.Enums;

namespace ToDoApp.Modules.Tasks.API.Features.DeleteTask;

public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand>
{
	private readonly ITasksCommandRepository _commandRepository;
	private readonly ITasksQueryRepository _queryRepository;

	public DeleteToDoCommandHandler(ITasksCommandRepository commandRepository, ITasksQueryRepository queryRepository)
	{
		_commandRepository = commandRepository;
		_queryRepository = queryRepository;
	}

	public async Task Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
	{
		var toDo = await _queryRepository.GetToDo(request.Id, request.Username);
		toDo.SetStatus(Status.Deleted);

		await _commandRepository.UpdateToDo(toDo);
	}
}
