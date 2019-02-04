using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public class Corridor
    {
        public bool noise;
        public bool doorClosed;
        public bool doorBroken;
        public bool isMonsterTunnel;
        public int width;
        public int[] roomIDs;
        


        public Corridor()
        {

        }

        public Corridor(Room roomA, Room roomB, int width = 1, bool tunnel = false)
        {
            this.isMonsterTunnel = tunnel;
            this.width = width;
            roomIDs = new int[2];
            roomIDs[0] = roomA.id;
            roomIDs[1] = roomB.id;
            roomA.corridors.Add(this);
            roomB.corridors.Add(this);
        }

        
    }
}
