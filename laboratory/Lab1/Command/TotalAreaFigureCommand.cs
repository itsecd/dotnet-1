using Spectre.Console;
using Spectre.Console.Cli;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{

    public class TotalAreaFigureCommand : Command<TotalAreaFigureCommand.TotalAreaFigureSettings>
    {
        private readonly IRepository _figureRepository;

        public TotalAreaFigureCommand(IRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] TotalAreaFigureSettings settings)
        {
            List<Figure>? listElements = _figureRepository.GetAll();
            if (listElements!.Count == 0)
            {
                AnsiConsole.WriteLine("The collection is empty");
                return 1;
            }
            double totalArea = 0;
            foreach (Figure? obj in listElements!)
            {
                totalArea += obj!.Area();
            }
            AnsiConsole.WriteLine($"Square = {totalArea}");
            AnsiConsole.WriteLine($"Square(Linq) = {listElements!.Sum(x => x.Area())}");
            return 0;
        }

        public class TotalAreaFigureSettings : CommandSettings
        {

        }
    }
}
