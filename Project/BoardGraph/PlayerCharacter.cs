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
        public bool passed = false;
        public bool firstPlayer = false;
        public List<SevereWound> severeWounds = new List<SevereWound>();
        public int actionsTakenInTurn = 0;
        public int actionLimit = 2;
        public int handLimit = 5;
        //TODO list of selected cards for moving handcards to discards when paying cost
        public Deck<Card> deck = new Deck<Card>(); 
        public List<Item> items = new List<Item>();
        public List<Option> options = new List<Option>();
        public List<Objective> objectives = new List<Objective>();
        

     

    public PlayerCharacter()
        {
            isHostile = false;
        }

        public void CalculateOptions(Board board)
        {
            
            options.Clear();
            if (actionsTakenInTurn >= actionLimit)
                EndTurn(board);
            else if (!HasUsableHandCards())
                Pass();
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
            //cannot go below zero
            throw new NotImplementedException();
        }

        public void GainLightWound(int wounds)
        {
            // if goes above 2 set to zero and add serious wound
            throw new NotImplementedException();
        }

        public void GainSeriousWound()
        {
            //if 4th die
            //else draw from pile and add to wounds
            throw new NotImplementedException();
        }

        public List<MoveOption> GetMoveOptions(Room currentRoom, Board board)
            =>  currentRoom.GetAdjoiningRooms(board)
                .Select(destination => new MoveOption
                {
                    name = "MOVE",
                    action = BasicActions.Move,
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

    public class BasicActions
    {
        public static void Move(Option option)
        {

            option.player.roomId = option.targetRoom.id;
            option.targetRoom.RollForNoise(option.board);
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
        public Random random = new Random();
        public string name;
        public int roomId;
        public int lightWounds = 0;
        public bool isHostile;

        public Room GetRoom(Board board)
        {
            return board.rooms[roomId];
        }
    }

    

    public class Enemy : Target
    {
        public int size;
        public int surpriseAttackChance;

        public Enemy(int size, int surpriseAttackChance)
        {
            isHostile = true;
            this.size = size;
            this.surpriseAttackChance = surpriseAttackChance;
        }

        public virtual string Kill(Board board)
        {
            board.GetRoom(this.roomId).heavyItemsOnGround.Add(new Carcass());
            board.targets.Remove(this);
            return name + " dies!";
            
        }

        public virtual string PainfulGrunt()
        {
            return name + " hisses and growls in pain but keeps on advancing...";
        }

        public virtual string RunAway(Board b)
        {
            var room = b.GetRoom(roomId);
            var corridors = room.corridors;
            return name + " shrieks and howls with pain and retreats to ";
        }

        public virtual void DrawAttackCard(Board board)
        {
            
        }

        internal bool isInCombat(Board board)
        {
            return GetRoom(board)
                .GetRoomOccupants(board)
                .Any(t => t is PlayerCharacter);
        }

        internal void Attack(Board board)
        {
            var player = PickTarget(board);
            AttackCard card = board.attackCards.DrawCard();
            card.EnemyAttacksPlayer(this, player, board);
        }

        private PlayerCharacter PickTarget(Board board)
        {
            var players = GetRoom(board).GetRoomOccupants(board)
                .Where(o => o is PlayerCharacter)
                .Select(o=> (PlayerCharacter)o)
                .OrderBy(o=>o.deck.HandCards.Count())
                .ThenBy(o=>o.number)
                .ToList();
            return players[0];
        }

        internal void Move(Board board)
        {
            throw new NotImplementedException();
        }
    }


}