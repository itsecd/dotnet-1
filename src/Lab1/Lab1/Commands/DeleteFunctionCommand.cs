using Lab1.FunctionsRepository;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System;
using Lab1.Model;

namespace Lab1.Commands
{
    class DeleteFunctionCommand : Command<DeleteFunctionCommand.DeleteFunctionSettings>
    {
        public class DeleteFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository _functionRepository;

        public DeleteFunctionCommand(IFunctionsRepository repository)
        {
            _functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteFunctionSettings settings)
        {
            Console.Clear();

            Console.WriteLine("Удалить элемент из контейнера по индексу");
            Console.WriteLine("Введите индекс удаляемого элемента (или не число, чтобы вернуться назад): ");

            Function tmp;
            string input = Console.ReadLine();
            try
            {
                int result = Convert.ToInt32(input);
                tmp = _functionRepository[result];
                _functionRepository.Delete(result);

                Console.WriteLine($"Удалён элемент {tmp}");
            }
            catch
            {
                Console.WriteLine("Ошибка!");
                return 0;
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
            Console.ReadKey(true);

            return 0;
        }

    }
}
