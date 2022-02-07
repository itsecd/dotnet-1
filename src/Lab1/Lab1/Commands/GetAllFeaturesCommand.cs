using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{
    public class GetAllFeaturesCommand : Command<GetAllFeaturesCommand.GetAllFeaturesSettings>
    {
        public class GetAllFeaturesSettings : CommandSettings
        {
        }

        private readonly IFiguresRepository _figuresRepository;

        public GetAllFeaturesCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] GetAllFeaturesSettings settings)
        {
            var figures = _figuresRepository.GetFigures();

            var table = new Table();
            table.AddColumn("Type");
            table.AddColumn("Coords");
            table.AddColumn("Length");

            foreach (Figure f in figures)
            {
                table.AddRow(f.GetType().Name, f.ToString(), f.GetLength().ToString());
            }
            AnsiConsole.Write(table);

            AnsiConsole.WriteLine(figures.Sum(figure => figure.GetLength()));
            return 0;
        }
    }
}
