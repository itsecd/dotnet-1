using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace laboratory.Command
{
    // A class that implements getting a minimal framing rectangle
    public class FramingRectangleFigureCommand : Command<FramingRectangleFigureCommand.FramingRectangleFigureSettings>
    {
        private readonly IRepository FigureRepository;

        public FramingRectangleFigureCommand(IRepository figure)
        {
            FigureRepository = figure;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] FramingRectangleFigureSettings settings)
        {

            if (FigureRepository.Count() == 0)
            {
                AnsiConsole.WriteLine("The collection is empty");
                return 1;
            }
            int index_selection_figure;
            do
                index_selection_figure = AnsiConsole.Prompt(new TextPrompt<int>($"[Green]Enter index element [{1}, {FigureRepository.Count()}]: [/]"));
            while (index_selection_figure < 1 && index_selection_figure >= FigureRepository.Count());
            index_selection_figure--;

            var framing_rectangle = FigureRepository.GetAll()[index_selection_figure].FramingRectangle();
            AnsiConsole.WriteLine(framing_rectangle.ToString());
            var str = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[green]Add a framing rectangle to the collection: [/]")
                .AddChoices("yes", "no"));
            switch (str)
            {
                case "yes":
                    FigureRepository.Insert(index_selection_figure, framing_rectangle);
                    break;
                case "no":
                    break;
            }
            FigureRepository.Serialize("figure.xml");
            return 0;

        }

        public class FramingRectangleFigureSettings : CommandSettings
        {

        }
    }
}
