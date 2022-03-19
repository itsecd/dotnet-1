using Lab1.FunctionsRepository;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System;

namespace Lab1.Commands
{
    class WriteFunctionCommand : Command<WriteFunctionCommand.WriteFunctionSettings>
    {
        public class WriteFunctionSettings : CommandSettings
        {
        }

        private IFunctionsRepository _functionRepository;

        public WriteFunctionCommand(IFunctionsRepository repository)
        {
            _functionRepository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] WriteFunctionSettings settings)
        {
            Console.Clear();
            Console.WriteLine("Список функций: \n");
            Console.WriteLine(_functionRepository);
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню..");
            Console.ReadKey(true);

            return 0;
        }

    }
}
