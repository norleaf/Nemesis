using BoardGraph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModule
{
    class Program
    {
        static void Main(string[] args)
        {
            TestBoard.CreateRoomLayoutNumbersAndPosition();


            Console.WriteLine("done");
            Console.Read();
        }

        
    }

    public class PlayerTest
    {
        PlayerCharacter player;
        Board board;

        public PlayerTest()
        {
            player = new PlayerCharacter();
        }

        public void SetupTwo()
        {

        }

        public void SetupOne()
        {
            player.options.Add(new Option
            {
                actionCost = 2,
                name = "TEST ACTION",
                action = BasicActions.Move,
                player = player,

            });
            player.handCards.Add(new Card { contamination = true, name = "Slimed" });
            player.handCards.Add(new Card { contamination = true, name = "Scratched" });
            player.handCards.Add(new Card { contamination = false, name = "Search" });
            player.handCards.Add(new Card { contamination = false, name = "Search" });
            player.handCards.Add(new Card { contamination = false, name = "Cover Fire", actionCost = 1 });
            player.handCards.Shuffle();
            player.roomId = 2;

            Room roomA = new Room { id = 1, name = "Generator Room" };
            Room roomB = new Room { id = 2, name = "Hibernatorium", isDiscovered = true };
            Corridor corridor = new Corridor(roomA, roomB);

            board = new Board();
            board.rooms.Add(roomA, roomB);
        }

        public void PerformTestAction()
        {
            player.options.Single(o => o.name == "TEST ACTION").ChooseOption();
            player.handCards.Log();
        }

        public void PerformOptionsInspection()
        {
            player.CalculateOptions(board);
            player.options.Select(o => o.description).Log();
        }

        public void PerformTestMove()
        {
            player.CalculateOptions(board);
            player.options.Select(o => o.description).Log();
            player.options[0].ChooseOption();
            player.CalculateOptions(board);
            player.options.Select(o => o.description).Log();
        }
    }

    public static class Extensions
    {
        public static void Log<T>(this T output)
        {
            string json = JsonConvert.SerializeObject(output, Formatting.Indented);
            Debug.WriteLine(json);
        }
    }
}
