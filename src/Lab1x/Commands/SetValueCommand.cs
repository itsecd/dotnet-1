using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class SetValueCommand : Command<SetValueCommand.SetValueSettings>
    {

        public class SetValueSettings : CommandSettings
        {
        }

        private readonly IMatrixRepository _matricesRepository;

        public SetValueCommand(IMatrixRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] SetValueSettings settings)
        {
            AnsiConsole.MarkupLine($"[blue]Count matrix in collection: {_matricesRepository.GetAll().Count} [/]");
            int index = (int)AnsiConsole.Prompt(new TextPrompt<uint>("[blue]Enter index to set new value in the matrix: [/]"));

            AnsiConsole.MarkupLine("[blue]Matrix: [/]");
            PrintMatrixCommand.Print(_matricesRepository.GetMatrix(index));

            int i = (int)AnsiConsole.Prompt(new TextPrompt<uint>("[blue]i: [/]"));
            int j = (int)AnsiConsole.Prompt(new TextPrompt<uint>("[blue]j: [/]"));
            var value = AnsiConsole.Prompt(new TextPrompt<double>($"[blue]value: [/]"));

            _matricesRepository.GetMatrix(index)[i, j] =  value;
            _matricesRepository.Update();

            return 0;
        }

    }
}