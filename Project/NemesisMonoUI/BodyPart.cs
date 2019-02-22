using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLib;

namespace NemesisMonoUI
{
    public class BodyPart
    {
        public Vector3 offset;
        public List<VertexPositionColor> vertexList;
        
        public BodyPart(Vector3 offset)
        {
            this.offset = offset;
            vertexList = new List<VertexPositionColor>();
        }

        public BodyPart(int x, int y)
        {
            offset = new Vector3(x,y,0);
            vertexList = new List<VertexPositionColor>();
        }

        public void Start(int x, int y, Color color)
        {
            vertexList.Add(new VertexPositionColor(new Vector3(x, y, 0) * 6 + offset, color));
        }

    }

    public class Helmet : BodyPart
    {
        public Helmet(int x, int y) : base(x,y)
        {
            Start(-5, 0, Color.Azure);
            Start(-5, -5, Color.Azure);
            Start(-5, -5, Color.Azure);
            Start(-3, -7, Color.Azure);
            Start(-3, -7, Color.Azure);
            Start(0, -8, Color.Azure);
            Start(0, -8, Color.Azure);
            Start(3, -7, Color.Azure);
            Start(3, -7, Color.Azure);
            Start(5, -5, Color.White);
            Start(5, -5, Color.Yellow);
            Start(5, 0, Color.Azure);
            Start(5, 0, Color.Azure);
            Start(-5, 0, Color.Azure);
        }
    }
}