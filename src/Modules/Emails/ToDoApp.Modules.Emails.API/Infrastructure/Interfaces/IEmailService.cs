using ToDoApp.Modules.Emails.API.Models;

namespace ToDoApp.Modules.Emails.API.Infrastructure.Interfaces;

public interface IEmailService
{
    Task SendEmail(Email email);
}
