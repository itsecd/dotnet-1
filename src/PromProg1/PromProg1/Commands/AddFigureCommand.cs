using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1
{
    public class AddFigureCommand :  Command<AddFigureCommand.AddFigureSettings>
    {
        
        public class AddFigureSettings : CommandSettings { }
        

        private readonly IFigureRepository figureRepository;

        public AddFigureCommand(IFigureRepository _figureRepository)
        {
            figureRepository = _figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureSettings settings)
        {
            var a = 0;
            while (a != -1)
            {
                figureRepository.OpenFile(figureRepository.StorageFileName);
                var add = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                .Title("What do you want to add?")
                                .AddChoices("Rectangle", "Circle", "Triangle", "Exit"));
                if (add != "Exit")
                {
                    if (figureRepository._figures.Count == 0)
                    {
                        AnsiConsole.Write("For the program to work, enter index 0\n");
                    }
                    else
                    {
                        AnsiConsole.Write("Past used index:{0}\n", figureRepository._figures.Count - 1);
                    }
                    
                    
                }
                int indexAdd = AnsiConsole.Prompt(new TextPrompt<int>(" Index :"));


                if (figureRepository.CheckIndex(indexAdd) || indexAdd == figureRepository._figures.Count)
                {
                    switch (add)
                    {
                        case "Rectangle":
                            figureRepository.AddRectangle(
                                indexAdd,
                                FirstPointCoordinate(),
                                SecondPointCoordinate());
                            Console.Clear();
                            break;
                        case "Circle":
                            figureRepository.AddCircle(
                                indexAdd,
                                FirstPointCoordinate(),
                                AnsiConsole.Prompt(new TextPrompt<double>("Radius :")));
                            Console.Clear();
                            break;
                        case "Triangle":
                            figureRepository.AddTriangle(
                                indexAdd,
                                FirstPointCoordinate(),
                                SecondPointCoordinate(),
                                ThirdPointCoordinate());
                            Console.Clear();
                            break;


                        case "Exit":
                            a = -1;
                            break;

                        default:
                            break;
                    };
                }
                else
                {
                    AnsiConsole.Write("Incorrect index");
                    Console.ReadLine();
                }
                figureRepository.SaveFile(figureRepository.StorageFileName);
            }
           
            return 0;
        }

        
        private Point FirstPointCoordinate()
        {
            return new Point(
                AnsiConsole.Prompt(new TextPrompt<double>("First Point X Coordinate:")),
                AnsiConsole.Prompt(new TextPrompt<double>("First Point Y Coordinate:")));
        }
        private Point SecondPointCoordinate()
        {
            return new Point(
                AnsiConsole.Prompt(new TextPrompt<double>("Second Point X Coordinate:")),
                AnsiConsole.Prompt(new TextPrompt<double>("Second Point Y Coordinate:")));
        }
        private Point ThirdPointCoordinate()
        {
            return new Point(
                AnsiConsole.Prompt(new TextPrompt<double>("Third Point X Coordinate:")),
                AnsiConsole.Prompt(new TextPrompt<double>("Third Point Y Coordinate:")));
        }
    }
 }
