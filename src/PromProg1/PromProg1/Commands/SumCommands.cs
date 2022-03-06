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

        private readonly IFigureRepository _figureRepository;

        public SumCommands(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] SumSquareCommandSettings settings)
        {
            _figureRepository.OpenFile(_figureRepository.StorageFileName);
            AnsiConsole.Write("Total area of all shapes:\n" + _figureRepository.Summa());
            AnsiConsole.Write("\nTotal area of all shapes with System.Linq:\n" + _figureRepository.SumSystemLinq());
            Console.ReadLine();
            return 0;
        }
    }
}