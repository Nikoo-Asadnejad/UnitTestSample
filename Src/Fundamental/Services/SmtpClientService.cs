using System.Net.Mail;
using Fundamental.Interfaces;

namespace Fundamental;

public sealed class SmtpClientService : ISmtpClientService
{
    public async Task SendAsync(MailMessage message ,CancellationToken calnceleationToke = new ())
    {
        SmtpClient smtpClient = new SmtpClient();
        using (smtpClient);
        
        smtpClient.SendAsync(message, calnceleationToke);
    }
}