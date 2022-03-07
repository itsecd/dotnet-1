using Lab1.Repositories;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class ViewTableCommand : Command<ViewTableCommand.ViewTableSettings>
    {
        private readonly IFiguresRepository _figuresRepository;
        public class ViewTableSettings : CommandSettings { }

        public ViewTableCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ViewTableSettings settings)
        {
            _figuresRepository.PrintScreen();
            return 0;
        }


    }
}
