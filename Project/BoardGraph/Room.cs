using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Option> options = new List<Option>();
        public string name;
        public string description;
        [JsonIgnore]
        public List<Corridor> corridors = new List<Corridor>();
        public bool isDiscovered = false;
        public bool isOnFire = false;
        public bool isMalfunctioning = false;
        public bool hasComputer;
        public int itemsLeftToFind;
        public List<Item> heavyItemsOnGround = new List<Item>();

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

        public void RollForNoise(Board board)
        {
            if (GetRoomOccupants(board).Count() == 1)
            {
                //TODO check for claw and X
                /* pseudo-code
                 roll a percent die. <10=claw, <20=nothing if not slimed otherwise claw
                 organise the corridors to spread over the remaining 80 percent dependent on width
                 divide 80 by total corridor width to find interval size

                 */
                int roll = board.random.Next(100);
                int noiseLimit = corridors.Sum(c => c.width);
                int currentNoise = corridors.Where(c=>c.noise).Sum(c => c.width);
                int result = board.random.Next(noiseLimit) + 1;

            }

        }
    }





    public class RoomEvent
    {
        public RoomEvent()
        {

        }

        public virtual void  Perform(Room room, PlayerCharacter player)
        {
            Console.WriteLine("room event performed");
        }

        public class Claw : RoomEvent
        {
            public override void Perform(Room room, PlayerCharacter player)
            {
                Console.WriteLine("CLAW!");
            }
        }

        public class Calm : RoomEvent
        {
            public override void Perform(Room room, PlayerCharacter player)
            {
                Console.WriteLine("Calm!");
            }
        }
    }

}
