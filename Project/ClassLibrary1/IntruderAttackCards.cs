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

            
        }

        public string Transformation(AttackCard ac, Board board)
        {
            return "The creeper convulses and shakes as it undergoes metamorphorsis and changes into something much more hideous and dangerous...";
        }
    }

    public class Intruder : Enemy
    {
        public Type type;

        public Intruder(int size, int surpriseAttackChance, Type type) : base(size, surpriseAttackChance)
        {
        }
    }

    public enum Type
    {
        creeper, adult, breeder, queen
    }
}
