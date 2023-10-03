using System.Net.Mail;

namespace SampleProject.Interfaces;

public interface ISmtpClientService
{
    Task SendAsync(MailMessage message , CancellationToken calnceleationToke = new ());
}