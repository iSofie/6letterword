// See https://aka.ms/new-console-template for more information
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SDEV.Peripass.Services;
using SDEV.Peripass.Services.Contracts;
using SDEV.Peripass.WordExcercise;
using SDEV.Peripass.WordExcercise.Models;



var scriptOptions = Parser.Default.ParseArguments<ScriptOptions>(args).MapResult(
    (opts) => ScriptOptions.RunOptionsAndReturnExitCode(opts),
    (errs) => ScriptOptions.HandleParseError(errs)
);
if (scriptOptions == null) { return; };

var serviceCollection = ConfigureServices(scriptOptions);

using (var serviceProvider = serviceCollection.BuildServiceProvider())
{
    var logger = serviceProvider.GetService<ILogger<Program>>();
    if (logger is not null && serviceCollection is not null)
    {
        try
        {
            InputAnalysis inputAnalyser = serviceProvider.GetService<InputAnalysis>();
            inputAnalyser.Start(scriptOptions);
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            logger.LogError(e.StackTrace);
        }
        logger.LogInformation("Operation completed - {0}", DateTime.Now);
    }
    else
    {
        Console.WriteLine("Empty logger, could not start program");
    }
}

static ServiceCollection ConfigureServices(ScriptOptions options)
{
    var serviceCollection = new ServiceCollection();

    serviceCollection.AddTransient<InputAnalysis>();
    serviceCollection.AddScoped<IFileService, FileService>();

    serviceCollection.AddLogging((builder) =>
    {
        builder.AddConsole();
    });

    return serviceCollection;
}
