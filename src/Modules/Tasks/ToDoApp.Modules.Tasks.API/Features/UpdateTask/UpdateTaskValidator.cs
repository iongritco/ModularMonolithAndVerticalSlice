using FluentValidation;
using ToDoApp.Modules.Tasks.API.Models.Enums;

namespace ToDoApp.Modules.Tasks.API.Features.UpdateTask;

public class UpdateToDoValidator : AbstractValidator<UpdateTaskCommand>
{
	public UpdateToDoValidator()
	{
		RuleFor(x => x.Id).NotNull();
		RuleFor(x => x.Description).NotEmpty();
		RuleFor(x => x.Status).NotEqual(Status.None);
		RuleFor(x => x.Username).NotEmpty();
	}
}
