using System;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;
using Spectre.Console;
using Lab1.Repository;

namespace Lab1.Commands
{
    public class DeleteMatrixCommand : Command<DeleteMatrixCommand.DeleteMatrixSettings>
    {
        public class DeleteMatrixSettings : CommandSettings
        {

        }

        private IMatrixRepository _data;

        public DeleteMatrixCommand(IMatrixRepository data)
        {
            _data = data;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteMatrixSettings settings)
        {
            _data.Load();
            AnsiConsole.Clear();
            AnsiConsole.Write(_data.ToTable());
            int indDel = AnsiConsole.Prompt(new TextPrompt<int>("Индекс: "));
            if (indDel < 0 || indDel > _data.Count - 1)
            {
                AnsiConsole.WriteException(new ArgumentOutOfRangeException("Индекс вышел за границы списка!"));
                return -1;
            }
            _data.Delete(indDel);
            _data.Dump();
            return 0;
        }
    }
}