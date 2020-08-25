using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib
{
    public class Box : ViewBase
    {
        private Rectangle rectangle;
        private Color color;

        public Box(int x, int y, int with, int height, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.rectangle = new Rectangle(x, y, with, height);
        }

        public Box(int x, int y, int with, int height, Color color, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.rectangle = new Rectangle(x, y, with, height);
            this.color = color;
            Init(graphicsDevice);
        }

        public Box SetColor(Color color)
        {
            this.color = color;
            return this;
        }

        public override void Init(GraphicsDevice graphicsDevice)
        {
            
            var r = this.rectangle;
            if (color == null) color = new Color(255, 255, 255);
            vertices.Add(new VertexPositionColor { Position = new Vector3(Corner(r.Left, r.Top), 0), Color = color });
            vertices.Add(new VertexPositionColor { Position = new Vector3(Corner(r.Right, r.Top), 0), Color = color });
            vertices.Add(new VertexPositionColor { Position = new Vector3(Corner(r.Right, r.Bottom), 0), Color = color });
            vertices.Add(new VertexPositionColor { Position = new Vector3(Corner(r.Left, r.Bottom), 0), Color = color });
            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), VerticeArray.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(VerticeArray);
            indices = new List<short>
            {
                0,1,2,
                2,3,0
            };
            indexBuffer = new IndexBuffer(graphicsDevice, typeof(short), indices.Count, BufferUsage.WriteOnly);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            DefaultDraw(graphicsDevice);
        }

        public Vector2 Corner(int x, int y)
        {
            return new Vector2(x, y);
        }
    }

   
}
