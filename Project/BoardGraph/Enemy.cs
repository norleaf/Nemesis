using System;
using System.Linq;

namespace BoardGraph
{
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

        public bool isInCombat(Board board)
        {
            return GetRoom(board)
                .GetRoomOccupants(board)
                .Any(t => t is PlayerCharacter);
        }

        public void Attack(Board board, PlayerCharacter player)
        {
            AttackCard card = board.attackCards.DrawCard();
            card.EnemyAttacksPlayer(this, player, board);
        }

        //public void Attack(Board board)
        //{
        //    var player = PickTarget(board);

        //}

        public PlayerCharacter PickTarget(Board board)
        {
            var players = GetRoom(board).GetRoomOccupants(board)
                .Where(o => o is PlayerCharacter)
                .Select(o => (PlayerCharacter)o)
                .OrderBy(o => o.deck.HandCards.Count())
                .ThenBy(o => o.number)
                .ToList();
            return players[0];
        }

        public void Move(Board board)
        {
            //todo: move aliens

            throw new NotImplementedException();
        }

        public void Attack(Board board)
        {
            if (isInCombat(board))
            {
                var player = PickTarget(board);
                Attack(board, player);
            }

        }
    }


}