using MailKit.Net.Smtp;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SmtpTester;

public class SmtpCommand : Command<SmtpSettings>
{
    public override int Execute(CommandContext context, SmtpSettings settings)
    {
        AnsiConsole.MarkupLine($"[yellow]Connecting to {settings.Host}:{settings.Port}...[/]");

        try
        {
            using var client = new SmtpClient();

            if (settings.AllowInsecure)
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            }

            client.Connect(settings.Host, settings.Port, settings.SecureSocketOptions);
            AnsiConsole.MarkupLine("[green]Connection successful.[/]");

            AnsiConsole.MarkupLine($"[yellow]Authenticating with username {settings.Username}...[/]");
            client.Authenticate(settings.Username, settings.Password);
            AnsiConsole.MarkupLine("[green]Authentication successful.[/]");

            client.Disconnect(true);
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine("[red]An error occurred:[/]");
            AnsiConsole.WriteException(ex);
            return -1;
        }

        return 0;
    }
}
