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
    public class RemoveFigureCommand : Command<RemoveFigureCommand.RemoveFigureSettings>
    {
        public class RemoveFigureSettings : CommandSettings
        {

        }

        private readonly IXmlFigureRepository _figureRepository;

        public RemoveFigureCommand(IXmlFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFigureSettings settings)
        {
            //var figures = _figureRepository.GetList();
            int index = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Вводите индекс фигура для удаления: [/]"));
            _figureRepository.RemoveFigure(index);
            return 0;
        }
    }
}
