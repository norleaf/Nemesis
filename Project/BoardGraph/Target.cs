using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGraph
{
    public class Target
    {
        public TargetListeners listeners;
        public Random random = new Random();
        public string name;
        public int roomId;
        public int lightWounds = 0;
        public bool isHostile;

        public Target()
        {
            listeners = new TargetListeners();
        }

        public Room GetRoom(Board board)
        {
            return board.rooms[roomId];
        }

        
    }

    public class Targets
    {
        private List<Target> targets;
        public Targets()
        {
            targets = new List<Target>();
        }

        public IEnumerable<Target> Enemies
        {
            get => targets.Where(t => t is Enemy);
        }

        public List<PlayerCharacter> Players
        {
            get => targets
                .Where(t => t is PlayerCharacter)
                .Select(t => (PlayerCharacter)t)
                .ToList();
        }

        public IEnumerable<Target> All
        {
            get => targets;
        }

        public void Add(Target target)
        {
            targets.Add(target);
        }

        public List<Target> InRoom(int id)
        {
            return targets.Where(t => t.roomId == id).ToList();
        }

        public void Remove(Target target)
        {
            targets.Remove(target);
        }
    }
}