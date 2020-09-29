using BoardGraph;
using NemesisLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAdventureVersion
{
    class LogBook
    {
        private Board board;
        private List<String> Log { get; set; }
        private PlayerCharacter player;

        public LogBook()
        {
            var setup = new Setup();
            board = setup.board;
            setup.AddRoomEventTokens(board);
         //   setup.AddIntrudersTokens(board);
            player = new Captain();
            player.firstPlayer = true;
            player.FillHand();
            
            board.activePlayer = player;
            board.targets.Add(player);
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
            player.options[option].ChooseOption(board, player);
            player = board.activePlayer;
            player.CalculateOptions(board);
            Console.WriteLine( player.DescribeSituation(board));
            AwaitUserInput();
           
        }
    }
}
