using AutoFixture.Xunit2;
using Moq;
using ToDoApp.Common.Tests;
using ToDoApp.Modules.Emails.API.Features.SendEmail;
using ToDoApp.Modules.Emails.API.Infrastructure.Interfaces;
using ToDoApp.Modules.Emails.API.Models;
using Xunit;

namespace ToDoApp.Modules.Emails.Tests.SendEmail;

public class SendEmailCommandHandlerShould
{
	[Theory]
	[AutoMoqData]
	public async Task ReturnUnitValueWhenSuccessful(
		SendEmailCommand command,
		[Frozen] Mock<IEmailService> todoCommandRepositoryMock,
		SendEmailCommandHandler sut)
	{
		await sut.Handle(command, CancellationToken.None);

		todoCommandRepositoryMock.Verify(call => call.SendEmail(
			It.Is<Email>(x => x.To.Equals(command.Email) && x.Body.Equals(command.Description))),
			Times.Once);
	}
}
