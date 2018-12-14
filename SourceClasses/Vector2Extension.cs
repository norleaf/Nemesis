using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisClasses
{
    public static class Vector2Extension
    {
        public static Vector2 Unit(this Vector2 vector)
        {
            return Vector2.Normalize(vector);
        }

        public static Vector2 Scale(this Vector2 vector, float scalar)
        {
            return Vector2.Multiply(vector, scalar);
        }

        public static void Dump(this Point point)
        {
            Console.WriteLine(point.X + "," + point.Y); 
        }
    }
}
