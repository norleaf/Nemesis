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
        public int actionCost = 2;
        public string actionName;
        [JsonIgnore]
        public Action<PlayerCharacter, Target, Room, Room> action;
        public string name;
        public string description;
        [JsonIgnore]
        public List<Corridor> corridors = new List<Corridor>();
        public bool isDiscovered = false;

        public int NoiseLevel()
        {
            return corridors.Count() - corridors.Sum(c => c.noise ? 1 : 0);
        }

        public List<Target> GetRoomOccupants(Board board)
        {
            return board.targets.Where(t => t.roomId == id).ToList();
        }

        public string RemoteDescription(Board board)
        {
            string description = "";
            var occupants = GetRoomOccupants(board);
            if (occupants.Any())
            {
                description = String.Format("A corridor leads to {0}, where you know ", name);
                for(int i = 0; i < occupants.Count(); i++)
                {
                    if      (i == 0) description += occupants[i].name;
                    else if (i >=1 && i <= occupants.Count()-2) description += ", " + occupants[i].name;
                    else if (i == occupants.Count() - 1) description += " and " + occupants[i].name;
                }
                description += (occupants.Count() == 1 ? " is " : " are ") + "present.";
            }
            else
            {
                string noise;
                switch (NoiseLevel())
                {
                    case 0:
                        noise = "slithering and scraping not common among the ship sounds...";
                        break;
                    case 1:
                        noise = "noises that might or might not be mechanical.";
                        break;
                    case 2:
                        noise = "leaking steam pipes whistling and working piston pumps and possibly something else...";
                        break;
                    default:
                        noise = "the omnipresent hum of the ship generator.";
                        break;
                }
                string room = isDiscovered ? "the " + name : "a unknown room";
                description = string.Format("A corridor leads to {0}, where you hear {1}", room, noise);
            }
            return description;
        }
    }

    public class Corridor
    {
        public bool noise;
        public bool doorClosed;
        public bool doorBroken;
        public bool isMonsterTunnel;
        public int width;
        public int[] rooms;
        

        public Corridor()
        {
            
        }

        public Corridor(Room roomA, Room roomB, int width = 1, bool tunnel = false)
        {
            this.isMonsterTunnel = tunnel;
            this.width = width;
            rooms = new int[2];
            rooms[0] = roomA.id;
            rooms[1] = roomB.id;
            roomA.corridors.Add(this);
            roomB.corridors.Add(this);
        }
    }

    

    public class RoomEvent
    {

    }
}
