using System;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;
using Spectre.Console;
using Lab1.Repository;

namespace Lab1.Commands
{
    public class CompareMatrixCommand : Command<CompareMatrixCommand.CompareMatrixSettings>
    {
        public class CompareMatrixSettings : CommandSettings
        {

        }

        private readonly IMatrixRepository _data;

        public CompareMatrixCommand(IMatrixRepository data)
        {
            _data = data;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareMatrixSettings settings)
        {
            _data.Load();
            AnsiConsole.Clear();
            AnsiConsole.Write(_data.ToTable());
            int indL = AnsiConsole.Prompt(new TextPrompt<int>("Индекс 1: "));
            int indR = AnsiConsole.Prompt(new TextPrompt<int>("Индекс 2: "));
            if (indL < 0 || indL > _data.Count - 1)
            {
                AnsiConsole.WriteException(new IndexOutOfRangeException($"Индекс 1 вышел за границы [0 : {_data.Count - 1}]!"));
                return -1;
            }
            if (indR < 0 || indR > _data.Count - 1)
            {
                AnsiConsole.WriteException(new IndexOutOfRangeException($"Индекс 2 вышел за границы [0 : {_data.Count - 1}]!"));
                return -1;
            }
            try
            {
                if (_data.Compare(indL, indR) == 1)
                    AnsiConsole.Write(new Panel("[yellow]Матрицы равны[/]"));
                if (_data.Compare(indL, indR) == 0)
                    AnsiConsole.Write(new Panel("[yellow]Матрицы НЕ равны[/]"));
            }
            catch (ArgumentOutOfRangeException e)
            {
                AnsiConsole.WriteException(e);
                return -1;
            }
            return 0;
        }
    }
}