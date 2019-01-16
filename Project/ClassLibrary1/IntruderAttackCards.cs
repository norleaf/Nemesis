using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    

    public class IntruderAttackCardsDeck
    {
        // 0,0, 2,2, 3,3,3,3, 4,4,4,4,4, 5,5,5,5,5, 6,6
        //transformation

        public List<AttackCard> deck;

        public IntruderAttackCardsDeck()
        {
            deck = new List<AttackCard>();

            deck.Add(
                new AttackCard
                {
                    attack = Summoning,
                    types = SetTypes(Type.creeper,Type.queen),
                    name = "Summoning",
                    life = 0
                }
                );
            
        }

        public string[] SetTypes(params Type[] types)
        {
            return types.Select(t => t.ToString()).ToArray();
        }

        public string Summoning(AttackCard ac, Board board)
        {
            throw new NotImplementedException();
            return "";
        }

        public string Transformation(AttackCard ac, Board board)
        {
            new NotImplementedException();
            return "The creeper convulses and shakes as it undergoes metamorphorsis and changes into something much more hideous and dangerous...";
        }

        public string Scratch(AttackCard ac, Board board)
        {
            ac.player.GainLightWound(1);
            throw new NotImplementedException();
            return "";
        }

        public string Frenzy(AttackCard ac, Board board)
        {
            throw new NotImplementedException();
            return "";
        }

        public string Bite(AttackCard ac, Board board)
        {
            throw new NotImplementedException();
            return "";
        }

        public string TailAttack(AttackCard ac, Board board)
        {
            throw new NotImplementedException();
            return "";
        }

        public string Slime(AttackCard ac, Board board)
        {
            throw new NotImplementedException();
            return "";
        }

        public string ClawAttack(AttackCard ac, Board board)
        {
            throw new NotImplementedException();
            return "";
        }
    }

    public class Intruder : Enemy
    {
        public Type type;

        public Intruder(int size, int surpriseAttackChance, Type type) : base(size, surpriseAttackChance)
        {
            name = type.ToString();
        }
    }

    public enum Type
    {
        creeper, adult, breeder, queen
    }
}
