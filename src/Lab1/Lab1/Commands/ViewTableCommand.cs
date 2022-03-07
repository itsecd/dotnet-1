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
