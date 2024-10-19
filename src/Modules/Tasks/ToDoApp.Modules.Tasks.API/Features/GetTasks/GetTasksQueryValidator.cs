using FluentValidation;

namespace ToDoApp.Modules.Tasks.API.Features.GetTasks;

public class GetToDoListQueryValidator : AbstractValidator<GetTasksQuery>
{
	public GetToDoListQueryValidator()
	{
		RuleFor(x => x.Username).NotEmpty();
	}
}

