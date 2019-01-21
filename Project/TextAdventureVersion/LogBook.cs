using BoardGraph;
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
            player.CalculateOptions(board);
            player.DescribeSituation(board);
            Console.WriteLine("game started");
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
                        int option = -1;
                        int.TryParse(input, out option);
                        option -= 1;
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
            player.DescribeSituation(board);
            AwaitUserInput();
        }
    }
}
