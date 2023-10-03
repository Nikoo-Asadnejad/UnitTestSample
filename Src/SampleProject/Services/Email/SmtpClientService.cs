using System.Net.Mail;
using SampleProject.Interfaces;

namespace SampleProject;

public sealed class SmtpClientService : ISmtpClientService
{
    public async Task SendAsync(MailMessage message ,CancellationToken calnceleationToke = new ())
    {
        SmtpClient smtpClient = new SmtpClient();
        using (smtpClient);
        
        smtpClient.SendAsync(message, calnceleationToke);
    }
}