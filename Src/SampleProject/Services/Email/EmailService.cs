using System.Net.Mail;
using SampleProject.Interfaces;

namespace SampleProject;

public class EmailService : IEmailService
{
    private readonly ISmtpClientService _smtpClient;
    public EmailService(ISmtpClientService smtpClient)
    {
        _smtpClient = smtpClient;
    }
    public async Task SendAsync(string from, string to, string subject, string body,
        CancellationToken calnceleationToke = new CancellationToken())
    {

        if (string.IsNullOrWhiteSpace(from))
            throw new ArgumentNullException(nameof(body));
        
        if (string.IsNullOrWhiteSpace(to))
            throw new ArgumentNullException(nameof(to));

        if (string.IsNullOrWhiteSpace(body))
            throw new ArgumentNullException(nameof(from));
        
        var mail = new MailMessage(from, to, subject, body);
        await _smtpClient.SendAsync(mail);
    }
}