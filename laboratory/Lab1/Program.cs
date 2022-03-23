using Lab1.Commands;
using Lab1.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IRepository, XmlFigureRepository>();

            var register = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(register);

            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("add");
                config.AddCommand<PrintFigureCommand>("print");
                config.AddCommand<RemoveFigureCommand>("remove");
                config.AddCommand<ComparisonFigureCommand>("compare");
                config.AddCommand<FramingRectangleFigureCommand>("frame");
                config.AddCommand<PerimeterFigureCommand>("perimeter");
                config.AddCommand<AreaFigureCommand>("area");
                config.AddCommand<TotalAreaFigureCommand>("combined");
            });
            app.Run(args);
        }
    }
}
