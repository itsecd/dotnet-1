using System;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;
using Spectre.Console;
using Lab1.Repository;

namespace Lab1.Commands
{
    public class ModifyMatrixCommand : Command<ModifyMatrixCommand.ModifyMatrixSettings>
    {
        public class ModifyMatrixSettings : CommandSettings
        {
            [CommandArgument(0,"<matrix index>")]
            public int MatIndex {get; set;}

            [CommandArgument(1, "<i>")]
            public int I {get; set;}

            [CommandArgument(2, "<j>")]
            public int J {get; set;}

            [CommandArgument(3, "<value>")]
            public double NewValue {get; set;}

            public override ValidationResult Validate()
            {
                if (MatIndex < 0 || I < 0 || J < 0)
                    return ValidationResult.Error("Значение индекса не может быть меньше нуля!");
                return ValidationResult.Success();
            }
        }

        private readonly IMatrixRepository _data;

        public ModifyMatrixCommand(IMatrixRepository data)
        {
            _data = data;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ModifyMatrixSettings settings)
        {
            _data.Load();
            if (_data.Count == 0)
            {
                AnsiConsole.Write(new Panel("[yellow]Список пуст, попробуйте сначала добавить матрицу с помощью команды [bold green]add[/][/]"));
                return -1;
            }
            _data[settings.MatIndex][settings.I, settings.J] = settings.NewValue;
            AnsiConsole.Clear();
            AnsiConsole.Write(_data[settings.MatIndex].ToTable());
            _data.Dump();
            return 0;
        }
    }
}