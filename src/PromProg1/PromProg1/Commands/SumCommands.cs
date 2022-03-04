using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;
namespace PromProg1
{
    public class SumCommands : Command<SumCommands.SumSquareCommandSettings>
    {
        public class SumSquareCommandSettings : CommandSettings
        {
        }

        private readonly IFigureRepository figureRepository;

        public SumCommands(IFigureRepository _figureRepository)
        {
            figureRepository = _figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] SumSquareCommandSettings settings)
        {
            figureRepository.OpenFile(figureRepository.StorageFileName);
            AnsiConsole.Write("Total area of all shapes:\n" + figureRepository.Summa());
            AnsiConsole.Write("\nTotal area of all shapes with System.Linq:\n" + figureRepository.SumSystemLinq());
            Console.ReadLine();
            return 0;
        }
    }
}