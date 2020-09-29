using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public class NemesisIntruder : Enemy
    {
        public Type type;
       
        public NemesisIntruder(int surpriseAttackChance, Type type) : base(TypeSize(type), surpriseAttackChance)
        {
            this.type = type;
            this.name = type.ToString();
        }

        public static void GenerateIntruderBag(Bag<Enemy> bag)
        {
            bag.Put(new NemesisIntruder(0, Type.nothing));

            for (int i = 0; i < 8; i++)
                bag.Put(new NemesisIntruder(1,  Type.larvae));

            for (int i = 0; i < 3; i++)
                bag.Put(new NemesisIntruder(1, Type.creeper));

            for (int i = 0; i < 4; i++)
                bag.Put(new NemesisIntruder(2, Type.adult));
            for (int i = 0; i < 5; i++)
                bag.Put(new NemesisIntruder(3, Type.adult));
            for (int i = 0; i < 3; i++)
                bag.Put(new NemesisIntruder(4, Type.adult));
            
            bag.Put(new NemesisIntruder(3, Type.breeder));
            bag.Put(new NemesisIntruder(4, Type.breeder));
            bag.Put(new NemesisIntruder(4, Type.queen));
        }

        public static int TypeSize(Type type)
        {
            if (type == Type.queen) return 4;
            else return (int)type;
        }

    }
    public enum Type
    {
        nothing,
        larvae,
        creeper, adult, breeder, queen
    }

}
