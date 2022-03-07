using Spectre.Console.Cli;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace laboratory.Command
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
            if (FigureRepository.Count() == 0)
            {
                AnsiConsole.WriteLine("The collection is empty");
                return 1;
            }
            double rez = 0;
            foreach (var obj in FigureRepository.GetAll())
            {
                rez += obj.Square();
            }
            AnsiConsole.WriteLine($"Square = {rez}");
            AnsiConsole.WriteLine($"Square(Linq) = {FigureRepository.GetAll().Sum(x=>x.Square())}");
            return 0;
        }

        public class TotalAreaFigureSettings : CommandSettings
        {

        }
    }
}
