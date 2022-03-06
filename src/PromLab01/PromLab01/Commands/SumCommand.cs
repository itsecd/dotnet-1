using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PromLab01
{
    public class SumCommands : Command<SumCommands.SumSquareCommandSettings>
    {
        public class SumSquareCommandSettings : CommandSettings
        {
        }

        private readonly IXmlFigureRepository _figureRepository;

        public SumCommands(IXmlFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] SumSquareCommandSettings settings)
        {
            _figureRepository.OpenFile(_figureRepository.StorageFileName);
            AnsiConsole.Write("Total area:\n" + _figureRepository.TotalSum());
            AnsiConsole.Write("\nTotal area using System.Linq:\n" + _figureRepository.SumSystemLinq());
            Console.ReadLine();
            return 0;
        }
    }
}