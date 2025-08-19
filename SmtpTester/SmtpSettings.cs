using System.ComponentModel;
using Spectre.Console.Cli;

namespace SmtpTester;

public class SmtpSettings : CommandSettings
{
    [CommandOption("-h|--host")]
    [Description("The SMTP host.")]
    public string? Host { get; set; }

    [CommandOption("-p|--port")]
    [Description("The SMTP port.")]
    [DefaultValue(587)]
    public int Port { get; set; }

    [CommandOption("-u|--username")]
    [Description("The SMTP username.")]
    public string? Username { get; set; }

    [CommandOption("-w|--password")]
    [Description("The SMTP password.")]
    public string? Password { get; set; }

    [CommandOption("--allow-insecure")]
    [Description("Allow insecure SSL/TLS connection.")]
    [DefaultValue(false)]
    public bool AllowInsecure { get; set; }

    [CommandOption("--secure-socket-options")]
    [Description("The secure socket options to use.")]
    [DefaultValue(MailKit.Security.SecureSocketOptions.Auto)]
    public MailKit.Security.SecureSocketOptions SecureSocketOptions { get; set; }
}
