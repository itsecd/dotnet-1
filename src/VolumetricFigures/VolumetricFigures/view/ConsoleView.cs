using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using VolumetricFigures.Controller;
using VolumetricFigures.Infrastructure;
using VolumetricFigures.View.Commands;

namespace VolumetricFigures.view
{
    public class ConsoleView
    {
        private string[] _args;

        public ConsoleView(string[] args)
        {
            _args = args;
        }

        public void Start()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConsoleController, ConsoleController>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("Add");
                config.AddCommand<CompareCommand>("Compare");
                config.AddCommand<DeleteCommand>("Delete");
                config.AddCommand<FileCommand>("Save/Open");
                config.AddCommand<SortCommand>("Sort");
                config.AddCommand<SumSquareCommand>("SumSquare");
                config.AddCommand<ViewTableCommand>("ViewTable");
            });

            app.Run(_args);
        }

    }
}
