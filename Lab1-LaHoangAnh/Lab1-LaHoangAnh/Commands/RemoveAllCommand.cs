using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Commands
{
    public class RemoveAllCommand : Command<RemoveAllCommand.RemoveAllSettings>
    {
        public class RemoveAllSettings : CommandSettings { }

        private readonly IXmlFigureRepository _figuresRepository;

        public RemoveAllCommand(IXmlFigureRepository figureRepository)
        {
            _figuresRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveAllSettings settings)
        {
            AnsiConsole.Write("[orange]Контейнер удален.");
            _figuresRepository.RemoveAllFigure();
            return 0;
        }
    }
}
