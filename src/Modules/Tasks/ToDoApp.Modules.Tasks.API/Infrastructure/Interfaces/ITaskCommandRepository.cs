
using ToDoApp.Modules.Tasks.API.Models.Entities;

namespace ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;

public interface ITasksCommandRepository
{
	Task CreateToDo(ToDoItem toDo);

	Task UpdateToDo(ToDoItem toDo);
}
