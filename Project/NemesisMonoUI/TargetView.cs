using MonoGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using BoardGraph;
using Microsoft.Xna.Framework;

namespace NemesisMonoUI
{
    public static class TargetViewExtensions
    {
        public static void DrawTargetText(this Target target, int index, Room room, GraphicsBatch graphicsBatch)
        {
            var padding = 2;
            Color color = target is PlayerCharacter ? Color.Blue : Color.Red;
            graphicsBatch.DrawString(graphicsBatch.DefaultFont, target.name, new Vector2(room.x, room.y + index + padding) * RoomViewExtensions.RoomScale, color, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 0);
        }
    }

    public class TargetView : ViewBase, Listener
    {
        public Body body;
        public Target target;
        public Room room;

        public TargetView(Target target, Room room, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.offset = room.RoomCenterVector3();
            this.target = target;
            target.listeners.Add(this);
            this.room = room;
            MakeBody(graphicsDevice);
            Init(graphicsDevice);
        }

        private void MakeBody(GraphicsDevice graphicsDevice)
        {
            body = new Body();
            Circle circle = new Circle(-30, -10, 25, 20);
            vertices.AddRange(circle.ring.Select(r => new VertexPositionColor(r,Color.DarkOliveGreen)));
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            PrepareDraw(graphicsDevice);
            indexBuffer.SetData(indices.ToArray());
            graphicsDevice.SetVertexBuffer(vertexBuffer);
            graphicsDevice.Indices = indexBuffer;
            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            graphicsDevice.RasterizerState = rasterizerState;

            //basicEffect.CurrentTechnique.Passes[0].Apply();  Is there ever going to be more than one Pass? Else just use this instead
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                //graphicsDevice.DrawIndexedPrimitives(PrimitiveType.LineStrip, baseVertex: 0, startIndex: 0, primitiveCount: VerticeArray.Length /* divide by two for half circle I think/ 2*/);
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.LineStrip, baseVertex: 0, startIndex: 0, primitiveCount: VerticeArray.Length );
            }
            
        }

        public void Notify(params object[] messages)
        {
            throw new NotImplementedException();
        }

        public void NotifyMove(Room room)
        {
            
            this.room = room;
            this.offset = room.RoomCenterVector3();
            vertexBuffer.SetData(VerticeArray);
        }
    }

    public class TargetsView : ViewBase
    {
        public List<TargetView> targets;
        public Board board;

        public TargetsView(Board board, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            targets = targets.New();
            this.board = board;
        }

        public void Add(Target target, Room room, GraphicsDevice graphicsDevice)
        {
            var view = new TargetView(target, room, graphicsDevice);
            targets.Add(view);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            targets.Draw(graphicsDevice);
        }

        internal void AddAll(Board board, GraphicsDevice graphicsDevice)
        {
            targets.Clear();
            foreach (var target in board.targets.All)
            {
                var room = target.GetRoom(board);
                Add(target, room, graphicsDevice);
            }
        }
    }
}
