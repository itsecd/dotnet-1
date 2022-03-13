using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using Lab1.FunctionsRepository;
using Functions;

namespace Lab1.Commands
{
    class ClearFunctionCommand: Command<ClearFunctionCommand.ClearFunctionSettings>
    {
        public class ClearFunctionSettings : CommandSettings
        {
        }

        private readonly IFunctionsRepository functionRepository;

        public ClearFunctionCommand(IFunctionsRepository repository)
        {
            functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ClearFunctionSettings settings)
        {
            Console.Clear();

            Console.WriteLine("Вы уверены, что хотите полностью очистить контейнер?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("2 - Нет");

            ConsoleKeyInfo k = Console.ReadKey(true);

            switch (k.Key)
            {
                case ConsoleKey.D1:
                    functionRepository.Clear();
                    break;
                default:
                    Console.WriteLine("Список не был очищен");
                    return 1;
            }

            Console.WriteLine("Список полностью очищен");
            Console.WriteLine("\nНажмите любую клавишу, чтобы закончить..");
            Console.ReadKey(true);

            return 0;
        }
    }
}
