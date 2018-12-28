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
}
