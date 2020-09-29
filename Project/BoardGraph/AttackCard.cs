using System;
using System.Linq;

namespace BoardGraph
{
    public class AttackCard
    {
        public string name;
        public string description;
        public int life;
        public string[] types;
        public Action<AttackCard, Board> attack;
        public PlayerCharacter player;
        public Enemy enemy;

        public AttackCard(string name, int life, string[] types, Action<AttackCard, Board> attack)
        {
            this.name = name;
            this.life = life;
            this.types = types;
            this.attack = attack;
            description = "set description in card constructor";
        }

        public string EnemyAttacksPlayer(Enemy e, PlayerCharacter p, Board board)
        {
            enemy = e;
            player = p;
            if (Hits())
            {
                attack(this, board);
                return e.name + " attacks " + p.name;
            }

            return e.name + " misses " + p.name;
        }

        public virtual bool Hits()
        {
            return types.Contains(name);
        }
        

        public string IntruderTakesDamage(Enemy e, Board b)
        {
            if (life == 0)
            {
                return e.RunAway(b);
            }
            else if (e.lightWounds >= life)
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