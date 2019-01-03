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
        public Action<Option> action;
        public PlayerCharacter player;
        public Target target;
        public Room room;
        public Room targetRoom;
        public Board board;
        public bool requiresTarget      = false;
        public bool requiresTargetRoom  = false;
        public bool requiresCombat      = false;
        public bool requiresNoCombat    = false;
        public bool requiresComputer    = false;

        public virtual bool CanTakeAction(Board board)
        {
            var missingTarget = requiresTarget && target == null;
            var missingRoom = requiresTargetRoom && targetRoom == null;
            var notEnoughCards = player.handCards.Count(a => !a.contamination) < actionCost;
            var hostiles = room.GetRoomOccupants(board).Any(a => a.isHostile);
            var onlyInCombat = requiresCombat && !hostiles;
            var onlyOutOfCombat = requiresNoCombat && hostiles;
            var missingComputer = requiresComputer && !room.hasComputer;

            return
                !missingTarget &&
                !missingRoom &&
                !notEnoughCards &&
                !onlyInCombat &&
                !onlyOutOfCombat &&
                !missingComputer;
        }

        public void ChooseOption()
        {
            player.actionsTakenInTurn++;
            player.PayActionCost(actionCost);
            action(this);
        }
    }

    
}
