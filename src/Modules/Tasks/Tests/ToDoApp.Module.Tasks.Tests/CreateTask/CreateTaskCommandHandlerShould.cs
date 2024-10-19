using AutoFixture.Xunit2;

using Moq;
using ToDoApp.Common.Tests;
using ToDoApp.Modules.Tasks.API.Features.CreateTask;
using ToDoApp.Modules.Tasks.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Tasks.API.Models.DTOs;
using ToDoApp.Modules.Tasks.API.Models.Entities;
using Xunit;

namespace ToDoApp.Module.Tasks.Tests.CreateTask;

public class CreateTaskCommandHandlerShould
{
    [Theory]
    [AutoMoqData]
    public async Task ReturnUnitValueWhenSuccessful(
        CreateTaskCommand command,
        [Frozen] Mock<ITasksCommandRepository> todoCommandRepositoryMock,
        [Frozen] Mock<IUsersApiClient> userApiClientMock,
        CreateToDoCommandHandler sut)
    {
        userApiClientMock.Setup(call => call.GetUser(It.IsAny<string>())).ReturnsAsync(new UserDto("email", "name"));

        await sut.Handle(command, CancellationToken.None);

        todoCommandRepositoryMock.Verify(call => call.CreateToDo(
            It.Is<ToDoItem>(x => x.Id.Equals(command.Id) && x.Description.Equals(command.Description) && x.Username.Equals(command.Username))),
            Times.Once);
    }
}
