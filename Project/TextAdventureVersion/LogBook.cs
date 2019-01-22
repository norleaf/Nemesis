using BoardGraph;
using NemesisLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModule;

namespace TextAdventureVersion
{
    class LogBook
    {
        private Board board;
        private List<String> Log { get; set; }
        private PlayerCharacter player;

        public LogBook()
        {
            var test = new PlayerTest();
            board = test.TestTwo();
            player = new PlayerCharacter();
            player.deck.DrawPile = new Captain().CaptainCards();
            player.Pass();
            player.roomId = 11;
            Console.WriteLine("game started");
            player.CalculateOptions(board);
            Console.WriteLine( player.DescribeSituation(board));
            AwaitUserInput();
        }

        public void AwaitUserInput()
        {
            string input = Console.ReadLine();
            AnalyseUserInput(input);
        }

        private void AnalyseUserInput(string input)
        {
            switch (input)
            {
                case "quit":
                case "q":
                    Console.WriteLine("quitting...");
                    break;
                default:
                    {
                        int option = -1; // start at an invalid value
                        int.TryParse(input, out option);
                        option -= 1; //reduce parsed integer to get it to zero based index
                        if(option >= 0 && option < player.options.Count())
                            PerformUserCommand(option);
                        else
                        {
                            Console.WriteLine("Invalid Input...");
                            AwaitUserInput();
                        }
                        break;
                    }
            }
            
        }

        private void PerformUserCommand(int option)
        {
            player.options[option].ChooseOption();
            player.CalculateOptions(board);
            Console.WriteLine( player.DescribeSituation(board));
            AwaitUserInput();
        }
    }
}
