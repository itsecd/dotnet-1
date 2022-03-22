using Lab1.Repository;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

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
