using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
   public static class RoomDescriptions
   {
        
        public static string RemoteDescription(this Room room, Board board)
        {
            string description = "";
            var occupants = room.GetRoomOccupants(board);
            if (occupants.Any())
            {
                description = String.Format("A corridor leads to {0}, where you know ", room.name);
                for (int i = 0; i < occupants.Count(); i++)
                {
                    if (i == 0) description += occupants[i].name;
                    else if (i >= 1 && i <= occupants.Count() - 2) description += ", " + occupants[i].name;
                    else if (i == occupants.Count() - 1) description += " and " + occupants[i].name;
                }
                description += (occupants.Count() == 1 ? " is " : " are ") + "present.";
            }
            else
            {
                string noise = room.NoiseLevel().RoomNoiseDescription();
                
                string roomname = room.isDiscovered ? "the " + room.name : "a unknown room";
                description = string.Format("A corridor leads to {0}, where you hear {1}", roomname, noise);
            }
            return description;
        }
    }
}
