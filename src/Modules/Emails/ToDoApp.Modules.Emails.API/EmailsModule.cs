using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Modules.Emails.API.Infrastructure;
using ToDoApp.Modules.Emails.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Emails.API.Models;

namespace ToDoApp.Modules.Emails.API;

public static class EmailsModule
{
	public static IServiceCollection AddEmailsModule(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<IEmailService, EmailService>();

		services.AddSingleton<EmailConfigurations>(
			_ =>
			{
				var configurations = new EmailConfigurations();
				configuration.GetSection("EmailConfigurations").Bind(configurations);
				return configurations;
			});
		return services;
	}

	public static IApplicationBuilder UseEmailsModule(this IApplicationBuilder app)
	{
		return app;
	}
}
