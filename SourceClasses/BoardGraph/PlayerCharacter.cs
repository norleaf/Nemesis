using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGraph
{
    public class PlayerCharacter : Target
    {
        public int number;
        public bool slimed = false;
        public bool signalSent = false;
        public List<SevereWound> severeWounds = new List<SevereWound>();
        public int actionsTakenInTurn = 0;
        public int actionLimit = 2;
        public int handLimit = 5;
        public List<Card> handCards = new List<Card>();
        public List<Card> discards = new List<Card>();
        public List<Card> drawPile = new List<Card>();
        public List<Item> items = new List<Item>();
        public List<Option> options = new List<Option>();
        public List<Objective> objectives = new List<Objective>();
        Random random = new Random();

        public void CalculateOptions(Board board)
        {
            options.Clear();
            if (actionsTakenInTurn >= actionLimit)
                EndTurn();
            else if (handCards.Count(a => !a.contamination) == 0)
                Pass();
            else
            {
                int cardsLeft = handCards.Count();
                Room room = board.rooms.Single(r => r.id == roomId);
                foreach (var corridor in room.corridors.Distinct().Where(r => !r.isMonsterTunnel && !r.doorClosed))
                {
                    Room destination = board.rooms.Single(r => r.id != room.id);
                    options.Add(new Option
                    {
                        name = "MOVE",
                        action = BasicActions.Move,
                        actionCost = 1,
                        description = destination.RemoteDescription(board),
                        destination = destination,
                        player = this,
                        room = room,
                        target = null
                    });
                }
            }
        }



        public void Pass()
        {
            while (handCards.Count() < handLimit) DrawCard();
        }

        public void DrawCard()
        {
            if (drawPile.Count() == 0) ShuffleDiscards();
            Card card = drawPile[0];
            handCards.Add(card);
            drawPile.Remove(card);
        }

        public void Discard(Card card)
        {
            handCards.Remove(card);
            discards.Add(card);
        }

        public void PayActionCost(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                List<Card> eligibleCards = handCards.Where(c => !c.contamination).ToList();
                var card = eligibleCards[random.Next(eligibleCards.Count())];
                Discard(card);
            }
        }

        private void ShuffleDiscards()
        {
            while (discards.Any())
            {
                var card = discards[random.Next(discards.Count())];
                drawPile.Add(card);
                discards.Remove(card);
            }
        }

        private void EndTurn()
        {
            actionsTakenInTurn = 0;
        }
    }

    public class BasicActions
    {
        public static void Move(PlayerCharacter player, Target target, Room room, Room destination)
        {
            player.roomId = destination.id;
        }
    }

    public class Objective
    {
    }

    public class SevereWound
    {

    }

    public class Target
    {
        public string name;
        public int roomId;
        public int lightWounds = 0;
    }

    public class Option
    {
        public string name;
        public string description;
        public int actionCost;
        public Action<PlayerCharacter, Target, Room, Room> action;
        public PlayerCharacter player;
        public Target target;
        public Room room;
        public Room destination;

        public void ChooseOption()
        {
            player.actionsTakenInTurn++;
            player.PayActionCost(actionCost);
            action(player, target, room, destination);
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