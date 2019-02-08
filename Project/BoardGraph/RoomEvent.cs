using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public abstract class RoomEvent
    {
        public abstract void Perform(Board board, Room room, PlayerCharacter player);
    }

    public class NoiseToken : RoomEvent
    {
        public override void Perform(Board board, Room room, PlayerCharacter player)
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
                new Encounter().Perform(board, room, player);
            else
                corridor.noise = true;

        }
    }

    public class Claw : RoomEvent
    {
        public override void Perform(Board board, Room room, PlayerCharacter player)
        {
            Console.WriteLine("CLAW!");
        }
    }

    public class Calm : RoomEvent
    {
        public override void Perform(Board board, Room room, PlayerCharacter player)
        {
            if (player.slimed) new Claw().Perform(board, room, player);
            else Console.WriteLine("Calm!");
        }
    }

    public class Slime : RoomEvent
    {
        public override void Perform(Board board, Room room, PlayerCharacter player)
        {
            player.slimed = true;
            Console.WriteLine("You slip and fall onto some sticky foul smelling slime!");
        }
    }

    public class Fire : RoomEvent
    {
        public override void Perform(Board board, Room room, PlayerCharacter player)
        {
            Console.WriteLine("The room is ablaze with fire. Staying here is hazardous!");
        }
    }

    public class Malfunction : RoomEvent
    {
        public override void Perform(Board board, Room room, PlayerCharacter player)
        {
            Console.WriteLine("Mechanical damage has caused a local power outage.");
        }
    }

    public class DoorLock : RoomEvent
    {
        public override void Perform(Board board, Room room, PlayerCharacter player)
        {
            Console.WriteLine("The door slams shut behind you and refuses to open.");
        }
    }

    public class Encounter : RoomEvent
    {
        public override void Perform(Board board, Room room, PlayerCharacter player)
        {
            foreach (var corridor in room.corridors)
                corridor.noise = false;

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
