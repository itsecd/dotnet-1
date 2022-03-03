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
    public class CompareCommand : Command<CompareCommand.CompareSettings>
    {
        public class CompareSettings : CommandSettings { }

        private readonly IXmlFigureRepository _figuresRepository;

        public CompareCommand(IXmlFigureRepository fi)
        {
            _figuresRepository = fi;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareSettings settings)
        {
            int id1 = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Выбирайте индекс первого фигура :[/]"));
            int id2 = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Выбирайте индекс второго фигура (различен от {id1}):[/]"));
            AnsiConsole.WriteLine($"Результат сравнения: {_figuresRepository.CompareFigures(id1, id2)}");
            return 0;
        }
    }
}
