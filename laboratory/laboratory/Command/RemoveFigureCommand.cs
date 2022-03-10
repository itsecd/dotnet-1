using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace laboratory.Command
{
    public class RemoveFigureCommand : Command<RemoveFigureCommand.RemoveFigureSettings>
    {
        private readonly IRepository FigureRepository;

        public RemoveFigureCommand(IRepository figure)
        {
            FigureRepository = figure;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] RemoveFigureSettings settings)
        {
            if (FigureRepository.Count() == 0)
            {
                AnsiConsole.WriteLine("The collection is empty");
                return 1;
            }
            var сhoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[green]Remove: [/]")
                .AddChoices("One element", "All elements"));
            switch (сhoice)
            {
                case "One element":
                    int index;
                    do
                        index = AnsiConsole.Prompt(new TextPrompt<int>($"[Green]Enter index element [{1}, {FigureRepository.Count()}]: [/]"));
                    while (index < 1 && index > FigureRepository.Count());
                    FigureRepository.RemoveAt(index - 1);
                    break;
                case "All elements":
                    FigureRepository.Clear();
                    break;
            }
            return 0;
        }

        public class RemoveFigureSettings : CommandSettings
        {

        }
    }
}
