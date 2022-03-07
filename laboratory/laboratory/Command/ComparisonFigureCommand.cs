using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace laboratory.Command
{
    public class ComparisonFigureCommand : Command<ComparisonFigureCommand.ComparisonFigureSettings>
    {
        private readonly IRepository FigureRepository;

        public ComparisonFigureCommand(IRepository figure)
        {
            FigureRepository = figure;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ComparisonFigureSettings settings)
        {
            if (FigureRepository.Count() < 2)
            {
                AnsiConsole.Clear();
                AnsiConsole.WriteLine("Comparison is not possible!");
                return 1;
            }
            var elements = FigureRepository.GetAll();
            int index_first, index_second;
            do
                index_first = AnsiConsole.Prompt(new TextPrompt<int>($"[Green]Enter the first comparison element [{1}, {FigureRepository.Count()}]: [/]"));
            while (index_first < 1 && index_first >= FigureRepository.Count());
            do
                index_second = AnsiConsole.Prompt(new TextPrompt<int>($"[Green]Enter the second comparison element [{1}, {FigureRepository.Count()}]: [/]"));
            while (index_second < 1 && index_second >= FigureRepository.Count());
            index_first--;
            index_second--;
            AnsiConsole.WriteLine($"{elements[index_first]} == {elements[index_second]}? {elements[index_first].Equals(elements[index_second])}");
            return 0;
        }

        public class ComparisonFigureSettings : CommandSettings
        {

        }
    }
}
