
using ToDoApp.Modules.Tasks.API.Models.Entities;

namespace ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;

public interface ITasksQueryRepository
{
	Task<IEnumerable<ToDoItem>> GetToDoList(string username);

	Task<ToDoItem> GetToDo(Guid id, string username);
}
