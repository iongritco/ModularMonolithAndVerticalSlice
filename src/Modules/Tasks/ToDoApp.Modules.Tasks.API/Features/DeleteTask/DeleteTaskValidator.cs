using FluentValidation;

namespace ToDoApp.Modules.Tasks.API.Features.DeleteTask;

public class DeleteToDoValidator : AbstractValidator<DeleteToDoCommand>
{
	public DeleteToDoValidator()
	{
		RuleFor(x => x.Id).NotNull();
		RuleFor(x => x.Username).NotEmpty();
	}
}
