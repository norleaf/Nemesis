using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public static class BasicOptions
    {
        public static List<Option> list;
    }

    public static class OptionDescritions
    {
        public static string DescribeSituation(this PlayerCharacter player, Board board)
        {
            Room room = player.GetRoom(board);
            var description = "You are in the " + room.name + ".";
            if (room.isOnFire) description = description.Replace(".", "") + " and the room is on fire. ";
            description += player.DescribeOccupants(board, room);
            description += player.DescribeOptions(board, room);
            return description;
        }



        public static string DescribeOccupants(this PlayerCharacter player, Board board, Room room)
        {
            string description = " ";
            var targets = room.GetRoomOccupants(board).Where(t => t != player);
            foreach (var target in targets.OrderBy(t => t.isHostile))
            {
                description += target.name + ", ";
            }
            if (targets.Count() == 0) description = "You are alone in the room.";
            else description = description.TrimEnd(',') + "are in the room with you.";
            return description;
        }

        public static string DescribeOptions(this PlayerCharacter player, Board board, Room room)
        {
            var description = " ";
            if (room.isMalfunctioning) description += "The power is out. ";

            foreach (var option in player.options)
            {
                if(option is MoveOption)
                {
                    option.description = option.targetRoom.RemoteDescription(board);
                }
                description += "\r\n";
                description += string.Format("({0}) ", player.options.IndexOf(option) + 1);
                description += option.description + ".";
            }
            return description;
        }
    }
}
