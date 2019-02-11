﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public abstract class Option
    {
        public abstract void Perform();
        
        public string name;
        public string description;
        public int actionCost = 2;
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

        public Option(bool requiresTarget = false, bool requiresTargetRoom = false, bool requiresCombat = false, bool requiresNoCombat = false, bool requiresComputer = false)
        {
            this.requiresTarget = requiresTarget;
            this.requiresTargetRoom = requiresTargetRoom;
            this.requiresCombat = requiresCombat;
            this.requiresNoCombat = requiresNoCombat;
            this.requiresComputer = requiresComputer;
        }

        public virtual bool CanTakeAction(Board board)
        {
            if (this.board == null) this.board = board;
            var missingTarget = requiresTarget && target == null;
            var missingRoom = requiresTargetRoom && targetRoom == null;
            var notEnoughCards = player.deck.HandCards.Count(a => !a.contamination) < actionCost;
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

        public void ChooseOption(Board board)
        {
            if (CanTakeAction(board))
            {
                player.actionsTakenInTurn++;
                player.PayActionCost(actionCost);
                Perform();
            }
        }
    }

    public class Move : Option
    {
        public Move(): base(requiresTargetRoom: true, requiresNoCombat:true)
        {
            actionCost = 1;
        }

        public override void Perform()
        {
            if (!targetRoom.isDiscovered)
            {
                var token = board.roomEvents.Pick();
                token.Perform(board, targetRoom, player);
                targetRoom.isDiscovered = true;
                if (token is Claw || token is Calm)
                {
                    player.roomId = targetRoom.id;
                    return;
                }
            }
            targetRoom.RollForNoise(board, player);
            player.roomId = targetRoom.id;
        }
    }


}
