using System;
using Spectre.Console;
using Spectre.Console.Cli;
using PromProg1.Repository;
using PromProg1.Models;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1.Commands
{
    class ClearRepositoryCommand : Command<ClearRepositoryCommand.ClearRepositorySettings>
    {
        public class ClearRepositorySettings : CommandSettings
        {
        }

        private readonly IOperationRepository _operationsRepository;

        public ClearRepositoryCommand(IOperationRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ClearRepositorySettings settings)
        {
            _operationsRepository.ClearCollection();

            return 0;
        }
    }
}