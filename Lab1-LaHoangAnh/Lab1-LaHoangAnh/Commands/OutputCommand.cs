using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class OutputCommand : Command<OutputCommand.OutputSettings>
    {
        public class OutputSettings : CommandSettings
        { }

        private readonly IFigureRepository _figuresRepository;

        public OutputCommand(IFigureRepository figureRepository)
        {
            _figuresRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] OutputSettings settings)
        {
            var figures = _figuresRepository.GetList();
            foreach (var figure in figures)
            {
                AnsiConsole.WriteLine($"{ figure.ToString()}");
            }
            return 0;
        }
    }
}
