using BoardGraph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModule
{
    public class TestBoard
    {
        public static void StartUp()
        {
            var boardSetup = new BoardSetup();
            boardSetup.fixedRooms.Add(new Room { x = 0, y = 0, name = "Cockpit", id=1,action=RoomActions.SetDestination });
            boardSetup.fixedRooms.Add(new Room { x = 5, y = 0, name = "Hibernatorium",id=11 });
            boardSetup.fixedRooms.Add(new Room { x = 9, y = 3, name = "Engine Three",id=19 });
            boardSetup.fixedRooms.Add(new Room { x = 9, y = 0, name = "Engine Two",id=20 });
            boardSetup.fixedRooms.Add(new Room { x = 9, y = -3, name = "Engine One",id=21 });
            int[] basicNumbers = new int[] {2,3,4,5,9,10,12,13,16,17,18 };
            int[] additionalNumbers = new int[] { 6, 7, 8, 14, 15 };
            for (int i = 0; i < 11; i++)
            {
                boardSetup.basicRooms.Add(new Room {name="basic room", id = basicNumbers[i] });
            }
            for (int i = 0; i < 5; i++)
            {
                boardSetup.additionalRooms.Add(new Room { name = "additional room", id = additionalNumbers[i] });
            }
            boardSetup.boardLayout.AddRange(boardSetup.fixedRooms);
            boardSetup.boardLayout.AddRange(boardSetup.basicRooms);
            boardSetup.boardLayout.AddRange(boardSetup.additionalRooms);

            //boardSetup

            Save(boardSetup,"board setup.json");

            var board = new Board();

            Save(board,"board.json");
        }

        public static void CreateRoomLayoutNumbersAndPosition()
        {
            var bs = Load<BoardSetup>("board setup.json");
            bs.boardLayout = bs.boardLayout.OrderBy(o => o.id).ToList();
            var positions = new int[,]{{2,22},{16,9},{13,25},{16,38},{30,4},{31,12},{26,25},{31,34},{30,45},{43,6},{40,22},{44,36},{57,7},{51,17},{51,29},{57,37},{63,16},{63,28},{71,7},{71,25},{71,37}};
            for (int i = 0; i < bs.boardLayout.Count();i++)
            {
                var room = bs.boardLayout[i];
                room.x = positions[i,0];
                room.y = positions[i,1];
                Console.WriteLine(room.id +", "+  room.name);
            }
        }

        public static void ConnectRooms()
        {
            var bs = Load<BoardSetup>("board setup.json");
            var techCorridors = new Room { x = 0, y = 3, isDiscovered = true, name = "TechnicalCorridors", id=999 };
            bs.fixedRooms.Add(techCorridors);
            bs.boardLayout.Add(techCorridors);
           
            bs.corridors.Add(
            new Corridor(bs.GetLayout(2), bs.GetLayout(6)),
            new Corridor(bs.GetLayout(2), bs.GetLayout(999),2,true),
            new Corridor(bs.GetLayout(3), bs.GetLayout(7),2),
            new Corridor(bs.GetLayout(4), bs.GetLayout(8)),
            new Corridor(bs.GetLayout(4), bs.GetLayout(999),2, true),
            new Corridor(bs.GetLayout(5), bs.GetLayout(999), 2, true),
            new Corridor(bs.GetLayout(5), bs.GetLayout(6)),
            new Corridor(bs.GetLayout(5), bs.GetLayout(10),2),
            new Corridor(bs.GetLayout(6), bs.GetLayout(7)),
            new Corridor(bs.GetLayout(6), bs.GetLayout(11)),
            new Corridor(bs.GetLayout(7), bs.GetLayout(8)),
            new Corridor(bs.GetLayout(8), bs.GetLayout(9)),
            new Corridor(bs.GetLayout(8), bs.GetLayout(11)),
            new Corridor(bs.GetLayout(9), bs.GetLayout(12),2),
            new Corridor(bs.GetLayout(9), bs.GetLayout(999),1, true),
            new Corridor(bs.GetLayout(10), bs.GetLayout(13), 2),
            new Corridor(bs.GetLayout(11), bs.GetLayout(14)),
            new Corridor(bs.GetLayout(11), bs.GetLayout(15)),
            new Corridor(bs.GetLayout(12), bs.GetLayout(16), 2),

            new Corridor(bs.GetLayout(13), bs.GetLayout(14)),
            new Corridor(bs.GetLayout(13), bs.GetLayout(19)),

            new Corridor(bs.GetLayout(14), bs.GetLayout(17)),
            new Corridor(bs.GetLayout(14), bs.GetLayout(999),1,true),
            new Corridor(bs.GetLayout(15), bs.GetLayout(18)),
            new Corridor(bs.GetLayout(15), bs.GetLayout(16)),
            new Corridor(bs.GetLayout(15), bs.GetLayout(999), 1, true),
            
            
            new Corridor(bs.GetLayout(16), bs.GetLayout(21)),
            new Corridor(bs.GetLayout(17), bs.GetLayout(19)),
            new Corridor(bs.GetLayout(17), bs.GetLayout(20),2),
            new Corridor(bs.GetLayout(18), bs.GetLayout(20),2),
            new Corridor(bs.GetLayout(18), bs.GetLayout(21)),

            new Corridor(bs.GetLayout(19), bs.GetLayout(999), 2,true),
            new Corridor(bs.GetLayout(21), bs.GetLayout(999), 2,true)



            );

            Save(bs, "board setup.json");
        }



        public static T Load<T>(string fileName)
        {
            string path = Environment.CurrentDirectory;
            var json = File.ReadAllText(Path.Combine(path, fileName));
            T element = JsonConvert.DeserializeObject<T>(json);
            return element;
            //path.Log();
        }

        public static void Save<T>(T element, string fileName)
        {
            var json = JsonConvert.SerializeObject(element, Formatting.Indented);
            string path = Environment.CurrentDirectory;
            //path.Log();
            File.WriteAllText(Path.Combine(path, fileName), json);
        }
    }
}
