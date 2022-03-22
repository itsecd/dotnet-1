using lab1.Model;
using lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using lab1.PrintMatrix;

namespace Lab1.Commands
{
    public class PrintAllCommand : Command<PrintAllCommand.PrintAllSettings>
    {

        public class PrintAllSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matricesRepository;

        public PrintAllCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PrintAllSettings settings)
        {
            var matrices = _matricesRepository.GetAll();

            for(var i = 0; i < matrices.Count; ++i)
            {
                if(i==10)
                {
                    AnsiConsole.MarkupLine("[blue]...[/]");
                    break;
                }
                AnsiConsole.MarkupLine($"[blue]Matrix {i}[/]");
                PrintMatrix.Print(matrices[i]);
                AnsiConsole.WriteLine();
            }
            return 0;
        }

    }
}