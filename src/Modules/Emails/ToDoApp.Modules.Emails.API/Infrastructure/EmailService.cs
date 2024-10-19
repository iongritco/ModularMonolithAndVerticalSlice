using Microsoft.Extensions.Logging;
using ToDoApp.Modules.Emails.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Emails.API.Models;

namespace ToDoApp.Modules.Emails.API.Infrastructure;

public class EmailService : IEmailService
{
	private readonly ILogger<EmailService> _logger;
	private readonly EmailConfigurations _configurations;

	public EmailService(ILogger<EmailService> logger, EmailConfigurations configurations)
	{
		_logger = logger;
		_configurations = configurations;
	}

	public Task SendEmail(Email email)
	{
		_logger.LogInformation("Sending email to {to} with body {body} using smtp {smtp} and port {port}", email.To,
			email.Body, _configurations.SmtpServer, _configurations.Port);

		return Task.CompletedTask;
	}
}
