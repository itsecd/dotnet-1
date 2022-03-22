using Lab1.Model;
using Lab1.Repository;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Commands
{
    public class CompareMatricesCommand : Command<CompareMatricesCommand.CompareMatricesSettings>
    {
        public class CompareMatricesSettings : CommandSettings
        {
        }

        private readonly IMatricesRepository _matricesRepository;

        public CompareMatricesCommand(IMatricesRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareMatricesSettings settings)
        {
            if (_matricesRepository.GetMatrices().Count() < 2)
            {
                AnsiConsole.MarkupLine($"[red]У вас меньше 2 матриц, чтобы их сравнить[/]");
                return 0;
            }

            _matricesRepository.PrintMatrices();

            var index1 = -1;
            var index2 = -1;
            do
            {
                index1 = AnsiConsole.Prompt(new TextPrompt<int>("Введите индекс 1 "));
            } while (index1 >= _matricesRepository.GetMatrices().Count());
            do
            {
                index2 = AnsiConsole.Prompt(new TextPrompt<int>("Введите индекс 2 "));
            } while (index2 >= _matricesRepository.GetMatrices().Count());

            if (_matricesRepository.CompareMatrices(index1, index2))
                AnsiConsole.MarkupLine($"[green]Матрицы равны[/]");
            else
                AnsiConsole.MarkupLine($"[red]Матрицы не равны[/]");

            return 0;
        }
    }
}
