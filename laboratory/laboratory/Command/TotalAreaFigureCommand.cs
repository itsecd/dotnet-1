using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{

    public class TotalAreaFigureCommand : Command<TotalAreaFigureCommand.TotalAreaFigureSettings>
    {
        private readonly IRepository FigureRepository;

        public TotalAreaFigureCommand(IRepository figure)
        {
            FigureRepository = figure;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] TotalAreaFigureSettings settings)
        {
            if (FigureRepository.GetAll() == null)
            {
                AnsiConsole.WriteLine("The collection is empty");
                return 1;
            }
            double totalArea = 0;
            foreach (var obj in FigureRepository.GetAll())
            {
                totalArea += obj.Area();
            }
            AnsiConsole.WriteLine($"Square = {totalArea}");
            AnsiConsole.WriteLine($"Square(Linq) = {FigureRepository.GetAll().Sum(x => x.Area())}");
            return 0;
        }

        public class TotalAreaFigureSettings : CommandSettings
        {

        }
    }
}
