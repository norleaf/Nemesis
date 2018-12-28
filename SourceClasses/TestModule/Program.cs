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
           //var dump = RoomActions.GetAllRoomActions().Where(r=>r.Method.Name=="Armory");
            var test = new PlayerTest();
            test.SetupTwo();


            //Console.WriteLine("done");
            //Console.Read();
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
            Random random = new Random();
            board = new Board();
            var bs = TestBoard.Load<BoardSetup>(TestBoard.setupFileName);
            board.rooms = bs.boardLayout;
            board.corridors = bs.corridors;
            foreach (var room in board.rooms.Where(r => r.name == "basic room"))
            {
                var replacement = bs.basicRooms[random.Next(bs.basicRooms.Count())];
                bs.basicRooms.Remove(replacement);
                room.name = replacement.name;
                room.actionName = replacement.actionName;
                room.description = replacement.description;
                room.action = RoomActions.GetAllRoomActions().SingleOrDefault(r => r.Method.Name == room.actionName);
            }
            foreach(var room in board.rooms.Where(r=>r.name== "additional room"))
            {
                var replacement = bs.additionalRooms[random.Next(bs.additionalRooms.Count())];
                bs.additionalRooms.Remove(replacement);
                room.name = replacement.name;
                room.actionName = replacement.actionName;
                room.description = replacement.description;
                room.action = RoomActions.GetAllRoomActions().SingleOrDefault(r => r.GetType().Name == room.actionName);
            }
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
