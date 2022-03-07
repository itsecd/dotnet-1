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
    public class SumFigureCommand : Command<SumFigureCommand.SumFigureSettings>
    {
        private readonly IFiguresRepository _figuresRepository;
        public class SumFigureSettings : CommandSettings { }

        public SumFigureCommand(IFiguresRepository figuresRepository)
        {
            _figuresRepository = figuresRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] SumFigureSettings settings)
        {
            
            AnsiConsole.WriteLine("Sum created by me :");
            AnsiConsole.WriteLine(_figuresRepository.Sum());
            AnsiConsole.WriteLine("\nSum System.Linq :");
            AnsiConsole.WriteLine(_figuresRepository.SumSystemLinq());
            return 0;
        }
    }
}
