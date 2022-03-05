using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;
using Spectre.Console;
using Lab1.Repository;

namespace Lab1.Commands
{
    public class PrintRepositoryCommand : Command<PrintRepositoryCommand.PrintRepositorySettings>
    {
        public class PrintRepositorySettings : CommandSettings
        {

        }

        private IMatrixRepository _data;

        public PrintRepositoryCommand(IMatrixRepository data)
        {
            _data = data;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] PrintRepositorySettings settings)
        {
            _data.Load();
            AnsiConsole.Clear();
            AnsiConsole.Write(_data.ToTable());
            return 0;
        }
    }
}