using MediatR;
using ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Tasks.API.Models.Entities;
using ToDoApp.Modules.Tasks.API.Models.Enums;

namespace ToDoApp.Modules.Tasks.API.Features.GetTasks;

public class GetTaskListQueryHandler : IRequestHandler<GetTasksQuery, List<ToDoItem>>
{
	private readonly ITasksQueryRepository _queryRepository;

	public GetTaskListQueryHandler(ITasksQueryRepository queryRepository)
	{
		_queryRepository = queryRepository;
	}

	public async Task<List<ToDoItem>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
	{
		var toDoList = await _queryRepository.GetToDoList(request.Username);
		return toDoList.Where(x => x.Status != Status.Deleted).ToList();
	}
}
