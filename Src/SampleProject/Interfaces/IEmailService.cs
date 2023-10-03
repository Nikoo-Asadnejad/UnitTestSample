namespace SampleProject.Interfaces;

public interface IEmailService
{
    Task SendAsync(string from, string to, string subject, string body, CancellationToken calnceleationToke = new CancellationToken());
}