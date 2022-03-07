using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace laboratory.Command
{
    public class SquareFigureCommand : Command<SquareFigureCommand.SquareFigureSettings>
    {
        private readonly IRepository FigureRepository;

        public SquareFigureCommand(IRepository figure)
        {
            FigureRepository = figure;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] SquareFigureSettings settings)
        {
            if (FigureRepository.Count() == 0)
            {
                AnsiConsole.WriteLine("The collection is empty");
                return 1;
            }
            int index;
            do
                index = AnsiConsole.Prompt(new TextPrompt<int>($"[Green]Enter index element [{1}, {FigureRepository.Count()}]: [/]"));
            while (index < 1 && index >= FigureRepository.Count());
            index--;
            AnsiConsole.WriteLine($"{FigureRepository.GetAll()[index]} squeare = {FigureRepository.GetAll()[index].Square()}");
            return 0;

        }

        public class SquareFigureSettings : CommandSettings
        {

        }
    }
}
