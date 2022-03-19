using System;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using Lab1.FunctionsRepository;

namespace Lab1.Commands
{
    class ClearFunctionCommand: Command<ClearFunctionCommand.ClearFunctionSettings>
    {
        public class ClearFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository _functionRepository;

        public ClearFunctionCommand(IFunctionsRepository repository)
        {
            _functionRepository = repository;
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
                    _functionRepository.Clear();
                    break;
                default:
                    return 0;
            }

            Console.WriteLine("Список полностью очищен");
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
            Console.ReadKey(true);

            return 0;
        }
    }
}
