using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using Lab1.Infrastructure;

namespace PromProg1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FigureRepository figureRepository= new FigureRepository();
            // figureRepository.AddFigure();
            // var figureType = AnsiConsole.Prompt(new SelectionPrompt<string>().Title)
            //var figureType = AnsiConsole.Prompt(new SelectionPrompt<string>()
            //                   .Title("What to add?")
            //                   .AddChoices("Rectangle", "Circle", "Triangle"));
            //Figure figure = figureType switch
            //{
            //    "Rectangle" => new Rectangle(
            //        new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X1 :")),
            //        AnsiConsole.Prompt(new TextPrompt<double>("Точка Y1 :"))),
            //        new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X2 :")),
            //        AnsiConsole.Prompt(new TextPrompt<double>("Точка Y2 :")))
            //        ),
            //     "Circle" => new Circle(
            //        new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X1 :")),
            //        AnsiConsole.Prompt(new TextPrompt<double>("Точка Y1 :"))),
            //        AnsiConsole.Prompt(new TextPrompt<double>("Radius :"))),

            //      "Triangle" => new Triangle(
            //        new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X1 :")),
            //        AnsiConsole.Prompt(new TextPrompt<double>("Точка Y1 :"))),
            //        new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X2 :")),
            //        AnsiConsole.Prompt(new TextPrompt<double>("Точка Y2 :"))),
            //         new Point(AnsiConsole.Prompt(new TextPrompt<double>("Точка X3 :")),
            //        AnsiConsole.Prompt(new TextPrompt<double>("Точка Y3 :")))),
            //        _ => null
            //};
            //if(figure == null)
            //{
            //    AnsiConsole.MarkupLine("Неизвестный тип фигуры: {figureType}[/]");
            //}
            //figureRepository.AddFigure(figure);
            //var table = new Table();
            //table.AddColumn("Type");
            //table.AddColumn("Coordinate");
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFigureRepository, FigureRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("add");
                config.AddCommand<DeleteCommand>("delete");
                config.AddCommand<DeleteAllCommand>("deleteall");
                config.AddCommand<FileCommands>("file");
                config.AddCommand<TableCommand>("table");
                config.AddCommand<SumCommands>("sum");
                config.AddCommand<CompareCommand>("compare");
            });

            app.Run(args);
        }
    }
}
