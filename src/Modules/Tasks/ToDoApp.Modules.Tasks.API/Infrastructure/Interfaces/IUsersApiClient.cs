using ToDoApp.Modules.Tasks.API.Models.DTOs;

namespace ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;

public interface IUsersApiClient
{
	Task<UserDto> GetUser(string email);
}
