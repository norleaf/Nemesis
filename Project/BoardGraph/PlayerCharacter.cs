using System;
using System.Collections.Generic;
using System.Linq;
using static BoardGraph.RoomEvent;

namespace BoardGraph
{
    public class PlayerCharacter : Target
    {
        public int number;
        public bool slimed = false;
        public bool infested = false;
        public bool signalSent = false;
        public bool passed = false;
        public bool firstPlayer = false;
        public List<SevereWound> severeWounds;
        public int actionsTakenInTurn = 0;
        public int actionLimit = 2;
        public int handLimit = 5;
        //TODO list of selected cards for moving handcards to discards when paying cost
        public Deck<Card> deck;
        public List<Item> items;
        public List<Option> options;
        public List<Objective> objectives;




        public PlayerCharacter()
        {
            isHostile = false;
            severeWounds = new List<SevereWound>();
            deck = new Deck<Card>();
            items = new List<Item>();
            options = new List<Option>();
            objectives = new List<Objective>();
        }

        public void CalculateOptions(Board board)
        {

            options.Clear();
            if (actionsTakenInTurn >= actionLimit)
                EndTurn(board);
            else if (!HasUsableHandCards())
            {
                Pass();
                EndTurn(board);
            }
            else
            {
                int cardsLeft = deck.HandCards.Count(a => !a.contamination);
                Room room = GetRoom(board);
                options.AddRange(room.GetOptions(this));
                List<Target> targets = room.GetRoomOccupants(board);
                bool inCombat = targets.Any(t => t.isHostile);
                if (inCombat)
                {

                }
                else
                {
                    options.AddRange(GetMoveOptions(room, board));
                }
            }
        }



        public void HealLightWound(int wounds)
        {
            lightWounds -= wounds;
            if (lightWounds < 0) lightWounds = 0;
        }

        public void GainLightWound(int wounds, Board board)
        {

            lightWounds += wounds;
            if (lightWounds > 2)
            {
                lightWounds = 0;
                GainSeriousWound(board);
            }
        }

        public void GainSeriousWound(Board board)
        {
            //todo: serious wound gain
            //if 4th die
            //else draw from pile and add to wounds
            throw new NotImplementedException();
        }

        public List<Move> GetMoveOptions(Room currentRoom, Board board)
            => currentRoom.GetAdjoiningRooms(board)
                .Select(destination => new Move
                {
                    name = "MOVE",
                    actionCost = 1,
                    description = "",
                    targetRoom = destination,
                    player = this,
                    room = currentRoom,
                    target = null,
                    board = board

                })
                .ToList();

        public void Pass()
        {
            passed = true;

        }

        public void FillHand()
        {
            while (deck.HandCards.Count() < handLimit) DrawCard();
        }

        public void DrawCard()
        {
            deck.DrawCard();
        }

        public void Discard(Card card)
        {
            deck.Discard(card);
        }

        public int UsableHandCards()
        {
            return deck.HandCards.Where(r => !r.contamination).Count();
        }

        public void PayActionCost(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                List<Card> eligibleCards = deck.HandCards.Where(c => !c.contamination).ToList();
                var card = eligibleCards[random.Next(eligibleCards.Count())];
                Discard(card);
            }
        }

        public bool HasUsableHandCards()
        {
            return deck.HandCards
                .Any(r => !r.contamination);
        }

        private void EndTurn(Board board)
        {
            actionsTakenInTurn = 0;
            board.NextPlayer(this);
        }
    }

    public class Objective
    {
        //Todo: objective
        public string name;
        public Func<PlayerCharacter, Board, bool> SolutionA;
        public Func<PlayerCharacter, Board, bool> SolutionB;
    }

    public class SevereWound
    {
        //Todo: severe wounds
    }


}