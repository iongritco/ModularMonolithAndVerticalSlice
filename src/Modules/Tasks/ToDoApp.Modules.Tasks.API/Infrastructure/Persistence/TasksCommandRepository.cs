using ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Tasks.API.Models.Entities;

namespace ToDoApp.Modules.Tasks.API.Infrastructure.Persistence;

public class TasksCommandRepository : ITasksCommandRepository
{
    private readonly TasksContext _tasksContext;

    public TasksCommandRepository(TasksContext tasksContext)
    {
        _tasksContext = tasksContext;
    }

    public async Task CreateToDo(ToDoItem toDo)
    {
        _tasksContext.Add(toDo);
        await _tasksContext.SaveChangesAsync();
    }

    public async Task UpdateToDo(ToDoItem toDo)
    {
        _tasksContext.Update(toDo);
        await _tasksContext.SaveChangesAsync();
    }
}
