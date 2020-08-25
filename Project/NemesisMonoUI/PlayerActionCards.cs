using BoardGraph;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisMonoUI
{
    public class PlayerActionCards : ViewBase, Listener
    {
        private Board board;
        public PlayerActionCards(GraphicsDevice graphicsDevice, Board board) : base(graphicsDevice)
        {
            this.board = board;
            
            vertices.Add(new VertexPositionColor { Position = new Vector3(500, 500, 0), Color = new Color(255,255,255) });
            vertices.Add(new VertexPositionColor { Position = new Vector3(550, 500, 0), Color = new Color(0,250,0) });
            vertices.Add(new VertexPositionColor { Position = new Vector3(550, 550, 0), Color = new Color(255,0,255) });
            vertices.Add(new VertexPositionColor { Position = new Vector3(500, 550, 0), Color = new Color(255,0,255) });
            Init(graphicsDevice);
        }

        public override void Init(GraphicsDevice graphicsDevice)
        {
            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), VerticeArray.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(VerticeArray);
            indices = new List<short>
            {
                0,1,2,
                0,2,3
            };
            indexBuffer = new IndexBuffer(graphicsDevice, typeof(short), indices.Count, BufferUsage.WriteOnly);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            PrepareDraw(graphicsDevice);
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, baseVertex: 0, startIndex: 0, primitiveCount: indexBuffer.IndexCount);

            }
        }

            public void Notify(params object[] messages)
        {
            throw new NotImplementedException();
        }

        public void NotifyMove(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
