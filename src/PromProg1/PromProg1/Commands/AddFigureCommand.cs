using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1
{
    public class AddFigureCommand :  Command<AddFigureCommand.AddFigureSettings>
    {
        
        public class AddFigureSettings : CommandSettings { }
        

        private readonly IFigureRepository _figureRepository;

        public AddFigureCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureSettings settings)
        {
            bool exit = false;
            while (!exit)
            {
                _figureRepository.OpenFile(_figureRepository.StorageFileName);
                var add = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                .Title("What do you want to add?")
                                .AddChoices("Rectangle", "Circle", "Triangle", "Exit"));
                if (add != "Exit")
                {
                    if (_figureRepository.Figures.Count == 0)
                    {
                        AnsiConsole.Write("For the program to work, enter index 0\n");
                    }
                    else
                    {
                        AnsiConsole.Write("Past used index:{0}\n", _figureRepository.Figures.Count - 1);
                    }
                    
                    
                }
                int indexAdd = AnsiConsole.Prompt(new TextPrompt<int>(" Index :"));


                if (_figureRepository.CheckIndex(indexAdd) || indexAdd == _figureRepository.Figures.Count)
                {
                    switch (add)
                    {
                        case "Rectangle":
                            _figureRepository.AddRectangle(
                                indexAdd,
                                FirstPointCoordinate(),
                                SecondPointCoordinate());
                            Console.Clear();
                            break;
                        case "Circle":
                            _figureRepository.AddCircle(
                                indexAdd,
                                FirstPointCoordinate(),
                                AnsiConsole.Prompt(new TextPrompt<double>("Radius :")));
                            Console.Clear();
                            break;
                        case "Triangle":
                            _figureRepository.AddTriangle(
                                indexAdd,
                                FirstPointCoordinate(),
                                SecondPointCoordinate(),
                                ThirdPointCoordinate());
                            Console.Clear();
                            break;


                        case "Exit":
                            exit = true;
                            break;

                     
                    };
                }
                else
                {
                    AnsiConsole.Write("Incorrect index");
                    Console.ReadLine();
                }
                _figureRepository.SaveFile(_figureRepository.StorageFileName);
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
