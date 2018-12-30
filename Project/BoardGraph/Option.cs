using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public class Option
    {
        public string name;
        public string description;
        public int actionCost = 2;
        public Action<PlayerCharacter, Target, Room, Room> action;
        public PlayerCharacter player;
        public Target target;
        public Room room;
        public Room targetRoom;
        public bool requiresTarget;
        public bool requiresTargetRoom;
        public bool requiresCombat;
        public bool requiresNoCombat;

        public bool CanTakeAction(Board board)
        {
            var missingTarget = requiresTarget && target == null;
            var missingRoom = requiresTargetRoom && targetRoom == null;
            var notEnoughCards = player.handCards.Count(a => !a.contamination) < actionCost;
            var hostiles = room.GetRoomOccupants(board).Any(a => a.isHostile);
            var onlyInCombat = requiresCombat && !hostiles;
            var onlyOutOfCombat = requiresNoCombat && hostiles;

            return
                !missingTarget &&
                !missingRoom &&
                !notEnoughCards &&
                !onlyInCombat &&
                !onlyOutOfCombat;
        }

        public void ChooseOption()
        {
            player.actionsTakenInTurn++;
            player.PayActionCost(actionCost);
            action(player, target, room, targetRoom);
        }
    }

    public class Item : Option
    {
        public bool oneUse;
    }

    public class Card : Option
    {
        public bool contamination;
    }
}
