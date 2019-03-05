using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib
{
    public class Circle
    {
        public int segments; //delete?
        public float width; //delete?
        public Vector3 center;
        public List<Vector3> ring;

        public Circle(float x, float y, float width, int segments)
        {
            center = new Vector3(x, y, 0);
            Vector3 rotator = new Vector3(width, 0, 0);
            ring = new List<Vector3>();
            float rotation = (float)Math.PI * 2 / (float)segments;
            for (int i = 0; i < segments; i++)
            {

                var matrix = Matrix.CreateRotationZ(rotation * i);
                ring.Add(center + Vector3.TransformNormal(rotator,matrix));
            }
        }
    }
}
