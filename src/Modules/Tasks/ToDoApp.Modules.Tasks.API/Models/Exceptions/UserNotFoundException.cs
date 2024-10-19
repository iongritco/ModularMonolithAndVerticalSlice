namespace ToDoApp.Modules.Tasks.API.Models.Exceptions;

public class UserNotFoundException : Exception
{
	public UserNotFoundException(string username)
		: base($"User with username {username} was not found.")
	{
	}
}