using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;
using Spectre.Console;
using Lab1.Repository;

namespace Lab1.Commands
{
    public class ClearRepositoryCommand : Command<ClearRepositoryCommand.ClearRepositorySettings>
    {
        public class ClearRepositorySettings : CommandSettings
        {

        }

        private readonly IMatrixRepository _data;

        public ClearRepositoryCommand(IMatrixRepository data)
        {
            _data = data;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ClearRepositorySettings settings)
        {
            _data.Load();
            AnsiConsole.Clear();
            AnsiConsole.Write(new Panel("[yellow]Список очищен[/]"));
            _data.Dump();
            return 0;
        }
    }
}