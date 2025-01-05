using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Localization.Services;

public class EmailSender : IEmailSender
{
    private readonly AuthMessageSenderOptions _options;
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor, ILogger<EmailSender> logger)
    {
        _options = optionsAccessor.Value;
        _logger = logger;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress("Rest Password", _options.SmtpUser));
        mimeMessage.To.Add(MailboxAddress.Parse(email));
        mimeMessage.Subject = subject;

        mimeMessage.Body = new TextPart("html")
        {
            Text = htmlMessage
        };

        try
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(_options.SmtpServer, _options.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_options.SmtpUser, _options.SmtpPass);
            await client.SendAsync(mimeMessage);
            await client.DisconnectAsync(true);

            _logger.LogInformation($"Email to {email} sent successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error sending email to {email}: {ex.Message}");
            throw;
        }
    }
}