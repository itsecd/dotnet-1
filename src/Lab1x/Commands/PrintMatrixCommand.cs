using Lab1.Model;
using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab1.Commands
{
    public class PrintMatrixCommand : Command<PrintMatrixCommand.PrintMatrixSettings>
    {

        public class PrintMatrixSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matricesRepository;

        public PrintMatrixCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PrintMatrixSettings settings)
        {
            AnsiConsole.MarkupLine($"[blue]Count matrix in collection: {_matricesRepository.GetAll().Count} [/]");
            var index = AnsiConsole.Prompt(new TextPrompt<int>("[blue]Enter index to print matrix: [/]"));
            var matrix = _matricesRepository.GetMatrix(index);

            Print(matrix);
            return 0;
        }

        static public void Print(IMatrix matrix)
        {
            for (var i = 0; i < matrix.Height; ++i)
            {
                for (var j = 0; j < matrix.Width; ++j)
                {
                    var val = matrix[i, j];
                    var sb = new StringBuilder();
                    if (val < 0)
                        sb.Append($"[red]");
                    if (val == 0)
                        sb.Append($"[white]");
                    if (val > 0)
                        sb.Append($"[green]");

                    sb.Append($"{val:f1}[/]  ");
                    AnsiConsole.Write(new Markup(sb.ToString()));
                }
                AnsiConsole.WriteLine();
            }
        }
    }
}