using lab1.services.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Lab1.Commands
{
    public class DeleteFunctionCommand : Command<DeleteFunctionCommand.DeleteFunctionSettings>
    {
        public class DeleteFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionRepo _functionsRepository;

        public DeleteFunctionCommand(IFunctionRepo functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteFunctionSettings settings)
        {
            int inputIndex = AnsiConsole.Prompt(new TextPrompt<int>("[aqua]Input the remove index: "));

            _functionsRepository.Delete(inputIndex);
            AnsiConsole.MarkupLine("[green1]Done!");

            return 0;
        }
    }
}
