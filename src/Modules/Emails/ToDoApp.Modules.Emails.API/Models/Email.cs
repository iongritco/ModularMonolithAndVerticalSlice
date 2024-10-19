namespace ToDoApp.Modules.Emails.API.Models;

public class Email
{
	public Email(string to, string body)
	{
		To = to;
		Body = body;
	}

	public string To { get; }

	public string Body { get; }
}
