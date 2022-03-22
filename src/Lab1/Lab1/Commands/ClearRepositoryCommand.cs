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
    public class ClearRepositoryCommand : Command<ClearRepositoryCommand.ClearRepositorySettings>
    {
        public class ClearRepositorySettings : CommandSettings
        {
        }

        private readonly IMatricesRepository _matricesRepository;

        public ClearRepositoryCommand(IMatricesRepository matricesRepository)
        {
            _matricesRepository = matricesRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ClearRepositorySettings settings)
        {
            _matricesRepository.ClearRepository();
            return 0;
        }
    }
}
