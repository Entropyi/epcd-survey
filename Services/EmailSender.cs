using MailKit.Net.Smtp;
using MimeKit;

public class EmailService
{
    private readonly string _smtpServer = "smtp.gmail.com"; // Replace with your SMTP server
    private readonly int _smtpPort = 587; // Port for TLS
    private readonly string _senderEmail = "your_email@gmail.com";
    private readonly string _senderPassword = "your_password"; // Use App Password if using Gmail

    public async Task SendEmailAsync(string recipientEmail, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Your App Name", _senderEmail));
        message.To.Add(new MailboxAddress("", recipientEmail));
        message.Subject = subject;

        // Add body (plain text or HTML)
        var bodyBuilder = new BodyBuilder
        {
            TextBody = body // Use HtmlBody for HTML content
        };
        message.Body = bodyBuilder.ToMessageBody();

        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_senderEmail, _senderPassword);
            await client.SendAsync(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true);
        }
    }
}