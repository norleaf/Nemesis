using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public class Corridor : Observer
    {
        public NamedState<bool> Noise { get; private set; }
        public bool doorClosed;
        public bool doorBroken;
        public bool isMonsterTunnel;
        public int width;
        public int[] roomIDs;
        public Listener listener;


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
            Noise = new NamedState<bool>(false, "noise");
        }

        public bool HasNoise()
        {
            return Noise.State;
        }

        public void RemoveNoise(Board board)
        {
            if (isMonsterTunnel)
            {
                board.GetRoom(999).corridors.ForEach(r => r.Noise.State = false);
            }
            else
            {
                Noise.State = false;
            }
            NotifyListeners(Noise.ToString());
        }

        public void CreateNoise(Board board)
        {
            if(isMonsterTunnel)
            {
                board.GetRoom(999).corridors.ForEach(r => r.Noise.State = true);
            }
            else
            {
                Noise.State = true;
            }
            NotifyListeners(Noise.ToString());
        }

        public void NotifyListeners(string message)
        {
            listener.Notify(message);
        }
    }
}
