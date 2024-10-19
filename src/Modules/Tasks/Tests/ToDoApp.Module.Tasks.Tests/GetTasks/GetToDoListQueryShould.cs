using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using ToDoApp.Common.Tests;
using ToDoApp.Modules.Tasks.API.Features.GetTasks;
using ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Tasks.API.Models.Entities;
using ToDoApp.Modules.Tasks.API.Models.Enums;
using Xunit;

namespace ToDoApp.Module.Tasks.Tests.GetTasks;

public class GetToDoListQueryShould
{
	[Theory]
	[AutoMoqData]
	public async Task ReturnUnitValueWhenSuccessful(
		GetTasksQuery query,
		List<ToDoItem> toDoItems,
		[Frozen] Mock<ITasksQueryRepository> todoQueryRepositoryMock,
		GetTaskListQueryHandler sut)
	{
		var expectedItems = toDoItems.Where(x => x.Status != Status.Deleted).ToList();
		todoQueryRepositoryMock.Setup(call => call.GetToDoList(It.IsAny<string>())).ReturnsAsync(toDoItems);

		var result = await sut.Handle(query, CancellationToken.None);

		result.Should().BeEquivalentTo(expectedItems);
		todoQueryRepositoryMock.Verify(call => call.GetToDoList(It.IsAny<string>()), Times.Once);
	}
}
