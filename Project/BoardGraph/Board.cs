using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public class Board
    {
        public Random random;
        public List<Room> rooms;
        public List<Corridor> corridors;
        public Queue<RoomEvent> roomEvents;
        public List<Target> targets;

        public Board()
        {
            random = new Random();
            rooms = new List<Room>();
            corridors = new List<Corridor>();
            roomEvents = new Queue<RoomEvent>();
            targets = new List<Target>();
        }

        
    }

    public class BoardSetup
    {
        public List<Room> fixedRooms;
        public List<Room> basicRooms;
        public List<Room> additionalRooms;
        public List<Room> boardLayout;
        public List<Corridor> corridors;

        public BoardSetup()
        {
            corridors = new List<Corridor>();
            fixedRooms = new List<Room>();
            basicRooms = new List<Room>();
            additionalRooms = new List<Room>();
            boardLayout = new List<Room>();
        }

        public Room GetLayout(int id)
        {
            return boardLayout.Single(r => r.id == id);
        }
     }

    public static class Extensions
    {
        public static List<T> Shuffle<T>(this List<T> list )
        {
            var random = new Random();
            var tempList = new List<T>();
            while (list.Any())
            {
                T element = list[random.Next(list.Count())];
                tempList.Add(element);
                list.Remove(element);
            }
            list.AddRange(tempList);
            return list;
        }

        public static void Add<T>(this List<T> list, params T[] elements)
        {
            list.AddRange(elements);
        }
    }
}
