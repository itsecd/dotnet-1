using PPLab1.Model;
using PPLab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PPLab1.Commands
{
    public class MaxFunctionCommand : Command<MaxFunctionCommand.MaxFunctionSettings>
    {
        public class MaxFunctionSettings : CommandSettings
        {

        }

        private readonly IFunctionsRepository _functionsRepository;

        public MaxFunctionCommand(IFunctionsRepository functionsRepository)
        {
            _functionsRepository = functionsRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] MaxFunctionSettings settings)
        {
            int value = AnsiConsole.Prompt(new TextPrompt<int>(
                "[green]Input the value for which you want to find the maximum function: [/]"));
            
            var functions = _functionsRepository.GetFunctions();

            if(functions == null) 
                return 0;

            var max_result = functions.Max(f => (double)f.calc_funct(value));
            var res = (from func in functions
                       where func.calc_funct(value) == max_result
                       select func).FirstOrDefault();

            AnsiConsole.WriteLine(res.ToString()); ;

            return 0;
        }

        
    }
}
