using Lab1.Services.Interfaces;
using Model;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Сommands
{
    public class ShowAllFunctionsCommand : Command<ShowAllFunctionsCommand.ShowAllFunctionsSettings>
    {
        public class ShowAllFunctionsSettings : CommandSettings
        {

        }

        private readonly IFunctionRepo _functionsRepository;

        public ShowAllFunctionsCommand(IFunctionRepo functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ShowAllFunctionsSettings settings)
        {
            AnsiConsole.MarkupLine("Functions:");
            List<Function> list = _functionsRepository.GetAll();
            foreach (Function function in list)
            {
                AnsiConsole.WriteLine(function.ToString());
            }
            return 0;
        }
    }
}
