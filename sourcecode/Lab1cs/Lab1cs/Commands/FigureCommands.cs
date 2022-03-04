using Lab1cs.Model;
using Lab1cs.Reposity;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1cs.Commands
{
    public class FigureCommands : Command<FigureCommands.AddFigureCommand>
    {
        public class AddFigureCommand : CommandSettings
        {

        }
        private readonly IFigureRepository _figureRepository;
        public FigureCommands (IFigureRepository figureRepo)
        {
            _figureRepository = figureRepo;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureCommand settings)
        {
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("choice")
                     .AddChoices("Rectangular", "Globular", "Cylinder"));
            Figure f = choice switch
            {
                "Rectangular" => new Rectangular(1, 1, 1, 2, 2, 2),
                "Globular" => new Globular(1, 3, 5, 4),
                "Cylinder" => new Cylinder(1, 2, 3, 5, 10),
                _ => null
            };
            if (f == null)
            {
                AnsiConsole.Markup("[red]Invalid type[/]");
            }
            _figureRepository.AddFigure(f);
            return 0;
        }
    }
}
