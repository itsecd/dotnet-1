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

        private readonly IMatrixRepository _data;

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
                AnsiConsole.WriteException(new IndexOutOfRangeException($"Индекс вышел за границы [0 : {_data.Count - 1}]!"));
                return -1;
            }
            try
            {
                _data.Delete(indDel);
            }
            catch (ArgumentOutOfRangeException e)
            {
                AnsiConsole.WriteException(e);
                return -1;
            }
            _data.Dump();
            return 0;
        }
    }
}