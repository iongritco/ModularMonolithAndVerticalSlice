using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using ToDoApp.Modules.Tasks.API.Infrastructure;
using ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Tasks.API.Infrastructure.Persistence;

namespace ToDoApp.Modules.Tasks.API;

public static class TasksModule
{
	public static IServiceCollection AddTasksModule(this IServiceCollection services, ConfigurationManager configuration)
	{
		services.AddScoped<ITasksQueryRepository, TasksQueryRepository>();
		services.AddScoped<ITasksCommandRepository, TasksCommandRepository>();
		services.AddScoped<IUsersApiClient, UsersApiClient>();
		services.AddDbContext<TasksContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("ToDoConnection")));

		return services;
	}

	public static IApplicationBuilder UseTasksModule(this IApplicationBuilder app)
	{
		InitializeDatabase(app);
		return app;
	}

	private static void InitializeDatabase(IApplicationBuilder app)
	{
		using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
		scope.ServiceProvider.GetRequiredService<TasksContext>().Database.Migrate();
	}
}