using Lab1.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1.Commands
{
    class MaxFunction : Command<MaxFunction.Settings>
    {
        public class Settings : CommandSettings
        {
        }
        private readonly IFunctionRepository _repository;

        public MaxFunction(IFunctionRepository repository)
        {
            _repository = repository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            var LinqWay = AnsiConsole.Prompt(
                new SelectionPrompt<bool>()
                    .Title("Use Linq way ?")
                    .AddChoices(new[] {
                        true, false
                    }));

            var functions = _repository.GetAll();

            if (functions.Count == 0)
            {
                AnsiConsole.Write("[red]Database is empty![/]");
                return 0;
            }

            var argument = AnsiConsole.Prompt(
               new TextPrompt<int>("Enter function argument")
                   .ValidationErrorMessage("[red]That's not a valid argument[/]")
                   );

            if (LinqWay)
            {
                var maxResult = functions.Max(v => v.Calculation(argument));
                var maxFunction = (from f in functions
                                   where f.Calculation(argument) == maxResult
                                   select f).FirstOrDefault();
                AnsiConsole.Write($"The maximum result of the function for the argument {argument} is given by the function {maxFunction}");
                return 0;
            }
            else
            {
                var maxFunction = functions[0];
                var maxResult = maxFunction.Calculation(argument);

                foreach (var f in functions)
                {
                    var curResult = f.Calculation(argument);
                    if (curResult > maxResult)
                    {
                        maxFunction = f;
                        maxResult = curResult;
                    }
                }
                AnsiConsole.Write($"The maximum result of the function for the argument {argument} is given by the function {maxFunction}");
                return 0;
            }

        }
    }
}
