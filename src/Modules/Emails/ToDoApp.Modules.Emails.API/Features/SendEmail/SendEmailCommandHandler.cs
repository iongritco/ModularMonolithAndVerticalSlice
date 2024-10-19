using MediatR;
using ToDoApp.Modules.Emails.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Emails.API.Models;

namespace ToDoApp.Modules.Emails.API.Features.SendEmail;

public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand>
{
	private readonly IEmailService _emailService;

	public SendEmailCommandHandler(IEmailService emailService)
	{
		_emailService = emailService;
	}

	public async Task Handle(SendEmailCommand request, CancellationToken cancellationToken)
	{
		await _emailService.SendEmail(new Email(request.Email, request.Description));
	}
}
