using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    internal class GetDerivativeCommand : Command<GetDerivativeCommand.GetDerivativeSettings>
    {
        public class GetDerivativeSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public GetDerivativeCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }


        public override int Execute([NotNull] CommandContext context, [NotNull] GetDerivativeSettings settings)
        {
            var index = AnsiConsole.Prompt(
                new TextPrompt<int>("[blue]Enter the index of the function to calculate the derivative(antiderivative): [/]"));

            var functions = _functionsRepository.GetFunctions();
            var f = functions[index];

            var table = new Table();
            table.AddColumn(new TableColumn(new Markup("[white]Name of function[/]")));
            table.AddColumn(new TableColumn("[white]Function[/]"));
            table.AddColumn(new TableColumn("[white]Derivative[/]"));
            table.AddColumn(new TableColumn("[white]Antiderivative[/]"));
            table.AddRow($"[yellow]{f.GetType().Name}[/]", $"[yellow]{f.ToString()}[/]", $"[yellow]{f.GetDerivative()}[/]", $"[yellow]{f.GetAntiderivative()} + C[/]");
            
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
