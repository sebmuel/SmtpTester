using Spectre.Console.Cli;
using SmtpTester;

var app = new CommandApp<SmtpCommand>();
return app.Run(args);
