using System.Net.Mail;

namespace Fundamental.Interfaces;

public interface ISmtpClientService
{
    Task SendAsync(MailMessage message , CancellationToken calnceleationToke = new ());
}