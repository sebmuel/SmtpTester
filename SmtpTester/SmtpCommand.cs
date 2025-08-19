using System.Net;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
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
            using var logStream = Console.OpenStandardError();
            using var client = new SmtpClient(new ProtocolLogger(logStream));

            var socketOptions =
                settings.SecureSocketOptions == SecureSocketOptions.Auto
                    ? SecureSocketOptions.StartTls
                    : settings.SecureSocketOptions;

            if (settings.AllowInsecure)
                client.ServerCertificateValidationCallback = (_, _, _, _) => true;

            client.Connect(settings.Host, settings.Port, socketOptions);
            AnsiConsole.MarkupLine("[green]Connection successful.[/]");

            client.AuthenticationMechanisms.Clear();
            client.AuthenticationMechanisms.Add("LOGIN");
            client.AuthenticationMechanisms.Add("PLAIN");

            AnsiConsole.MarkupLine($"[yellow]Authenticating with username {settings.Username}...[/]");
            client.Authenticate(new NetworkCredential(settings.Username, settings.Password));
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