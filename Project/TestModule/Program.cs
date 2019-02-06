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
            TestBoard.ConnectRooms();
            // var test = new PlayerTest();
            //test.TestTwo();


            //Console.WriteLine("done");
            Console.Read();
        }

        
    }

    public class PlayerTest
    {
        public PlayerCharacter player;
        public Board board;

        public PlayerTest()
        {
            player = new PlayerCharacter();
        }

        public Board TestTwo()
        {
            var board = SetupTwo();
            var hibernatorium = board.Rooms().Where(r => r.name == "Hibernatorium").Single();
        //    var adjoined = hibernatorium.GetAdjoiningRooms(board);
        //    foreach (var adj in adjoined)
        //    {
        //        Console.WriteLine(adj.name + ", " + adj.isDiscovered);
        //    }
            return board;
        }

        public Board SetupTwo()
        {
            Random random = new Random();
            board = new Board();
            var bs = TestBoard.Load<BoardSetup>(TestBoard.setupFileName);
            board.rooms = bs.boardLayout.ToDictionary(r=>r.id,r=>r);
            board.corridors = bs.corridors;
            foreach (var room in board.Rooms().Where(r => r.name == "basic room"))
            {
                var replacement = bs.basicRooms[random.Next(bs.basicRooms.Count())];
                bs.basicRooms.Remove(replacement);
                room.name = replacement.name;
                
                room.description = replacement.description;
                
            }
            foreach(var room in board.Rooms().Where(r=>r.name== "additional room"))
            {
                var replacement = bs.additionalRooms[random.Next(bs.additionalRooms.Count())];
                bs.additionalRooms.Remove(replacement);
                room.name = replacement.name;
                 
                room.description = replacement.description;
                
            }
            foreach (var room in board.rooms.Values)
            {
                var corridors = board.corridors
                    .Where(c => c.roomIDs.Any(i => i == room.id));
                room.corridors.AddRange(corridors);
            }

            return board;
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
            
            
            player.roomId = 2;

            Room roomA = new Room { id = 1, name = "Generator Room" };
            Room roomB = new Room { id = 2, name = "Hibernatorium", isDiscovered = true };
            Corridor corridor = new Corridor(roomA, roomB);

            board = new Board();
            board.rooms.Add(roomA.id, roomA);
            board.rooms.Add(roomB.id, roomB);
        }

        public void PerformTestAction()
        {
            player.options.Single(o => o.name == "TEST ACTION").ChooseOption();
            
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
