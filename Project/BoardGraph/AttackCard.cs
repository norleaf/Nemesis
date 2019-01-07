using System;
using System.Linq;

namespace BoardGraph
{
    public class AttackCard
    {
        public string name;
        public int life;
        public string[] types;
        public Func<AttackCard, Board, string> attack;
        public PlayerCharacter player;
        public Enemy enemy;
        

        public string EnemyAttacksPlayer(Enemy e, PlayerCharacter p, Board board)
        {
            if (types.Contains(e.name))
            {
                enemy = e;
                player = p;
                return attack(this, board);
            }
            return e.name + " misses " + p.name;
        }

        public string IntruderTakesDamage(Enemy e, Board b)
        {
            if(life==0)
            {
                return e.RunAway(b);
            }
            else if(e.lightWounds >= life)
            {
                return e.Kill(b);
            }
            else
            {
                return e.PainfulGrunt();
            }
        }
    }
}