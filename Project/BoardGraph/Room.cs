using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoardGraph.RoomEvent;

namespace BoardGraph
{

    public class Room
    {
        public int id;
        public int x;
        public int y;
        //public int actionCost = 2;
        //public string actionName;
        [JsonIgnore]
        public List<Option> options;
        public string name;
        public string description;
        [JsonIgnore]
        public List<Corridor> corridors;
        public bool isDiscovered = false;
        public bool isOnFire = false;
        public bool isMalfunctioning = false;
        public bool hasComputer;
        public int itemsLeftToFind;
        public List<Item> heavyItemsOnGround;

        

        public Room(int id, int x, int y, string name, string description="", bool isDiscovered=false,  bool hasComputer = false)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.options = new List<Option>();
            this.name = name;
            this.description = description;
            this.corridors = new List<Corridor>();
            this.isDiscovered = isDiscovered;
            this.isOnFire = false;
            this.isMalfunctioning = false;
            this.hasComputer = hasComputer;
            this.itemsLeftToFind = 0;
            this.heavyItemsOnGround = new List<Item>();
        }

        public void Init()
        {
            this.options = new List<Option>();
            this.corridors = new List<Corridor>();
            this.heavyItemsOnGround = new List<Item>();

        }

        public int NoiseLevel()
        {
            return corridors.Count() - corridors.Sum(c => c.noise ? 1 : 0);
        }

        public List<Target> GetRoomOccupants(Board board)
        {
            return board.targets.Where(t => t.roomId == id).ToList();
        }

        

        public virtual IEnumerable<Option> GetOptions(PlayerCharacter player)
        {
            return options;
        }

        public List<Room> GetAdjoiningRooms(Board board)
        {
            return
                board.rooms
                .Where(room => corridors.Where(c => !c.doorClosed).SelectMany(c => c.roomIDs).Contains(room.Key))
                .Where(room => room.Key != this.id && room.Key != 999)
                .Select(o=>o.Value)
                .ToList();



        }

        public virtual void RollForNoise(Board board)
        {
            if (!GetRoomOccupants(board).Any())
            {
                int roll = board.random.Next(10);
                RoomEvent evt;
                if (roll < 1) evt = new Claw();
                else if (roll < 2) evt = new Calm();
                else evt = new NoiseToken();

                evt.Perform(board, this);
            }
        }
    }





    

}
