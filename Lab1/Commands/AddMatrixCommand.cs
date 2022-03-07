using System;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;
using Spectre.Console;
using Lab1.Matrix;
using Lab1.Repository;

namespace Lab1.Commands
{
    public class AddMatrixCommand : Command<AddMatrixCommand.AddMatrixSettings>
    {
        public class AddMatrixSettings : CommandSettings
        {

        }

        private readonly IMatrixRepository _data;

        public AddMatrixCommand(IMatrixRepository data)
        {
            _data = data;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddMatrixSettings settings)
        {
            _data.Load();
            AnsiConsole.Clear();
            AnsiConsole.Write(_data.ToTable());
            string matType = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Выберите тип матрицы:")
                .AddChoices(new[] {
                    "BufferedMatrix",
                    "SparseMatrix"
            }));
            int tw = AnsiConsole.Prompt(new TextPrompt<int>("Ширина: "));
            int th = AnsiConsole.Prompt(new TextPrompt<int>("Высота: "));
            if (tw < 1)
            {
                AnsiConsole.WriteException(new ArgumentOutOfRangeException(nameof(tw), tw, "Ширина матрицы должна быть не меньше единицы!"));
                return -1;
            }
            if (th < 1)
            {
                AnsiConsole.WriteException(new ArgumentOutOfRangeException(nameof(th), th, "Высота матрицы должна быть не меньше единицы!"));
                return -1;
            }
            AbstractMatrix tmpMat = matType switch
            {
                "BufferedMatrix" => new BufferedMatrix(th, tw),
                "SparseMatrix" => new SparseMatrix(th, tw),
                _ => null
            };
            int indIns = 0;
            if (_data.Count > 1)
                indIns = AnsiConsole.Prompt(new TextPrompt<int>("Индекс: "));
            if (indIns < 0 || indIns > _data.Count - 1 && _data.Count > 1)
            {
                AnsiConsole.WriteException(new IndexOutOfRangeException($"Индекс вышел за границы [0 : {_data.Count - 1}]"));
                return -1;
            }
            try
            {
                _data.Insert(tmpMat, indIns);
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