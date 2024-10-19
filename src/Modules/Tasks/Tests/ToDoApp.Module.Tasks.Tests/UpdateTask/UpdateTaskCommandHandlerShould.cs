using AutoFixture.Xunit2;

using Moq;
using ToDoApp.Common.Tests;
using ToDoApp.EventBus.Events;
using ToDoApp.EventBus.Interfaces;
using ToDoApp.Modules.Tasks.API.Features.UpdateTask;
using ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Tasks.API.Models.Entities;
using ToDoApp.Modules.Tasks.API.Models.Enums;
using Xunit;

namespace ToDoApp.Module.Tasks.Tests.UpdateTask;

public class UpdateTaskCommandHandlerShould
{
	[Theory]
	[AutoMoqData]
	public async Task UpdateStatusToCompletedAndPublishUpdateEvent(
		ToDoItem toDoItem,
		UpdateTaskCommand command,
		[Frozen] Mock<ITasksQueryRepository> queryRepositoryMock,
		[Frozen] Mock<ITasksCommandRepository> commandRepositoryMock,
		[Frozen] Mock<IEventBus> eventBus,
		UpdateToDoCommandHandler sut)
	{
		command.Status = Status.Completed;
		queryRepositoryMock.Setup(call => call.GetToDo(It.IsAny<Guid>(), It.IsAny<string>()))
			.ReturnsAsync(toDoItem);

		await sut.Handle(command, CancellationToken.None);

		commandRepositoryMock.Verify(
			call => call.UpdateToDo(It.Is<ToDoItem>(x =>
				x.Status == command.Status && x.Description == command.Description)),
			Times.Once);
		eventBus.Verify(call => call.Publish(It.IsAny<TaskCompletedEvent>()), Times.Once);
	}
}
