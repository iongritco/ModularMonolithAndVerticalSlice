using System.Net.Http.Json;
using FluentAssertions;
using ToDoApp.Modules.Tasks.API.Features.CreateTask;
using ToDoApp.Modules.Tasks.API.Features.UpdateTask;
using ToDoApp.Modules.Tasks.API.Models.Entities;
using ToDoApp.Modules.Tasks.API.Models.Enums;
using Xunit;
using static ToDoApp.EndToEnd.Tests.BaseTestsClass;

namespace ToDoApp.EndToEnd.Tests.Tests;

[Collection("Tests collection")]
public class TasksApiShould
{
	[Fact]
	public async Task ReturnAddedTasks()
	{
		// Arrange
		var addedTaskGuid = Guid.NewGuid();

		// Act
		await CustomHttpClient.PostAsJsonAsync("api/tasks", new CreateTaskCommand { Description = "new task", Id = addedTaskGuid, Username = Username });
		var result = await CustomHttpClient.GetFromJsonAsync<List<ToDoItem>>("api/tasks");

		// Assert
		var newTask = result.SingleOrDefault(x => x.Id.Equals(addedTaskGuid));
		newTask.Should().NotBeNull();
	}

	[Fact]
	public async Task ReturnUpdatedTasks()
	{
		// Arrange
		var updatedTaskGuid = Guid.NewGuid();
		var updatedDescription = "updated task";
		var updatedStatus = Status.InProgress;

		// Act
		await CustomHttpClient.PostAsJsonAsync("api/tasks",
			new CreateTaskCommand { Description = "new task", Id = updatedTaskGuid, Username = Username });
		await CustomHttpClient.PutAsJsonAsync("api/tasks",
			new UpdateTaskCommand
			{
				Description = updatedDescription,
				Id = updatedTaskGuid,
				Username = Username,
				Status = updatedStatus
			});
		var result = await CustomHttpClient.GetFromJsonAsync<List<ToDoItem>>("api/tasks");

		// Assert
		var updatedTask = result.SingleOrDefault(x => x.Id.Equals(updatedTaskGuid));
		updatedTask.Should().NotBeNull();
		updatedTask.Description.Should().Be(updatedDescription);
		updatedTask.Id.Should().Be(updatedTaskGuid);

	}

	[Fact]
	public async Task ReturnNullWhenTaskIsDeleted()
	{
		// Arrange
		var deletedTaskGuid = Guid.NewGuid();

		// Act
		await CustomHttpClient.PostAsJsonAsync("api/tasks", new CreateTaskCommand { Description = "new task", Id = deletedTaskGuid, Username = Username });
		var result = await CustomHttpClient.GetFromJsonAsync<List<ToDoItem>>("api/tasks");

		// Assert
		var newTask = result.SingleOrDefault(x => x.Id.Equals(deletedTaskGuid));
		newTask.Should().NotBeNull();

		// Act 
		await CustomHttpClient.DeleteAsync($"api/tasks/{deletedTaskGuid}");
		var resultAfterDeletion = await CustomHttpClient.GetFromJsonAsync<List<ToDoItem>>("api/tasks");

		// Assert
		var deletedTask = resultAfterDeletion.SingleOrDefault(x => x.Id.Equals(deletedTaskGuid));
		deletedTask.Should().BeNull();

	}
}