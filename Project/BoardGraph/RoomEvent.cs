using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public abstract class RoomEvent
    {
        public abstract void Perform(Board board, Room room);

        
    }

    public class NoiseToken : RoomEvent
    {
        public override void Perform(Board board, Room room)
        {
            int totalWidth = room.corridors.Sum(c => c.width);
            int roll = board.random.Next(totalWidth) + 1;
            int index = 0;
            while (roll > room.corridors[index].width)
            {
                roll -= room.corridors[index].width;
                index++;
            }
            Corridor corridor = room.corridors[index];
            if (corridor.noise)
                new Encounter().Perform(board, room);
            else
            {
                corridor.noise = true;
                corridor.NotifyListeners();
            }

        }
    }

    public class Claw : RoomEvent
    {
        public override void Perform(Board board, Room room)
        {
            var adjacentRooms = room.GetAdjoiningRooms(board);
            var adjacentHostiles = adjacentRooms.SelectMany(r => r.GetRoomOccupants(board)).Where(r => r.isHostile);
            if (adjacentHostiles.Any(r => !r.InCombat(board)))
            {
                foreach ( var hostile in adjacentHostiles.Where(r => !r.InCombat(board)))
                {
                    hostile.roomId = room.id;
                    hostile.listeners.NotifyMove(room);
                }
            }
            else
            {
                room.corridors.ForEach(r => r.noise = true);
                Console.WriteLine("CLAW!");
            }
        }
    }

    public class Calm : RoomEvent
    {
        public override void Perform(Board board, Room room)
        {
            if (board.activePlayer.slimed) new Claw().Perform(board, room);
            else Console.WriteLine("Calm!");
        }
    }

    public class Slime : RoomEvent
    {
        public override void Perform(Board board, Room room)
        {
            board.activePlayer.slimed = true;
            Console.WriteLine("You slip and fall onto some sticky foul smelling slime!");
        }
    }

    public class Fire : RoomEvent
    {
        public override void Perform(Board board, Room room)
        {
            Console.WriteLine("The room is ablaze with fire. Staying here is hazardous!");
        }
    }

    public class Malfunction : RoomEvent
    {
        public override void Perform(Board board, Room room)
        {
            Console.WriteLine("Mechanical damage has caused a local power outage.");
        }
    }

    public class DoorLock : RoomEvent
    {
        public override void Perform(Board board, Room room)
        {
            Console.WriteLine("The door slams shut behind you and refuses to open.");
        }
    }

    public class Encounter : RoomEvent
    {
        public override void Perform(Board board, Room room)
        {
            foreach (var corridor in room.corridors)
                corridor.noise = false;
            var player = board.activePlayer;
            var enemy = board.enemies.Pick();
            board.targets.Add(enemy);
            if(enemy.surpriseAttackChance > player.UsableHandCards())
            {
                enemy.Attack(board, player);
            }
            Console.WriteLine("An intruder appears out of the darkness!");
        }
    }
}
