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
    public class DeleteAllFigureCommand : Command<DeleteAllFigureCommand.DeleteAllFigureSettings>
    {
        private readonly IFiguresRepository _figuresRepository;
        public class DeleteAllFigureSettings : CommandSettings { }

        public DeleteAllFigureCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteAllFigureSettings settings)
        {
            _figuresRepository.DeleteAllFigure();
            AnsiConsole.Write("You have cleared the of all shape");
            return 0;
        }


    }
}
