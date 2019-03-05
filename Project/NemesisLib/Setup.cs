using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public class Setup
    {
       // public string setupFileName = "board setup.json";
        public Board board;

        public Setup()
        {
            board = new Board();
            var player = new Captain();
            player.firstPlayer = true;
            board.activePlayer = player;
            board.targets.Add(player);
            var layout = new Layout();
            board.rooms = layout.AllRooms;
            board.corridors = layout.Corridors;
            AddRoomEventTokens(board);

            var bagBasic = new NemesisBasicRooms();
            var bagAdditional = new NemesisAdditionalRooms();

            foreach (var room in board.rooms.Values)
            {
                if(room is BasicRoom)
                {
                    var hidden = bagBasic.Pick();
                    hidden.AbsorbLayout(room);
                }
                if(room is AdditionalRoom)
                {
                    var hidden = bagAdditional.Pick();
                    hidden.AbsorbLayout(room);
                }
            }

        }

        public void AddIntrudersTokens(Board board)
        {
            //TODO: figure out if nemesis intruders needs to be classes
            //find out how many starts in the token bag
            throw new NotImplementedException();
        }

        public void AddRoomEventTokens(Board board)
        {
            for (int i = 0; i < 5; i++)
            {
                board.roomEvents.Put(new Calm());
            }
            for (int i = 0; i < 3; i++)
            {
                board.roomEvents.Put(new Claw());
            }
            for (int i = 0; i < 3; i++)
            {
                board.roomEvents.Put(new Fire());
            }
            for (int i = 0; i < 3; i++)
            {
                board.roomEvents.Put(new Malfunction());
            }
            for (int i = 0; i < 3; i++)
            {
                board.roomEvents.Put(new Slime());
            }
            for (int i = 0; i < 3; i++)
            {
                board.roomEvents.Put(new DoorLock());
            }
        }
    }

    public static class exts
    {
        public static void AbsorbLayout(this Room hiddenRoom, Room room)
        {
            room.name = hiddenRoom.GetType().Name;
            room.options = hiddenRoom.options;
            room.description = hiddenRoom.description;
            room.hasComputer = hiddenRoom.hasComputer;
        }
    }
}
