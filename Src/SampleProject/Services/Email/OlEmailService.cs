using System.Net.Mail;

namespace SampleProject;

public class OldEmailService
{
    public async Task SendAsync(string from, string to, string subject, string body,
        CancellationToken calnceleationToke = new ())
    {

        if (string.IsNullOrWhiteSpace(from))
            throw new ArgumentNullException(nameof(body));
        
        if (string.IsNullOrWhiteSpace(to))
            throw new ArgumentNullException(nameof(to));

        if (string.IsNullOrWhiteSpace(body))
            throw new ArgumentNullException(nameof(from));
        
        SmtpClient smtpClient = new SmtpClient();
        using (smtpClient) ;

        var mail = new MailMessage(from, to, subject, body);
        smtpClient.SendAsync(mail, calnceleationToke);
    }
}