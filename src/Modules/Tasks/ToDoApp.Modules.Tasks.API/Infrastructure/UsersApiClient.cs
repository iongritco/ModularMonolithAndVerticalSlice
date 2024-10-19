using Mapster;
using ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Tasks.API.Models.DTOs;
using ToDoApp.Modules.Users.Contracts;

namespace ToDoApp.Modules.Tasks.API.Infrastructure;

public class UsersApiClient : IUsersApiClient
{
	private readonly IUsersModuleService _usersModuleService;

	public UsersApiClient(IUsersModuleService usersModuleService)
	{
		_usersModuleService = usersModuleService;
	}

	public async Task<UserDto> GetUser(string email)
	{
		var user = await _usersModuleService.GetUser(email);
		return user.Adapt<UserDto>();
	}
}
