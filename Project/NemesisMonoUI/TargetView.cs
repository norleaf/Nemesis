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
    public class TargetView : ViewBase, Listener
    {
        public Target target;
        public Room room;

        public TargetView(Target target, Room room, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.target = target;
            this.room = room;
            SetVertices();
            Init(graphicsDevice);
        }

        private void SetVertices()
        {
            var points = new Point[]
            {
                new Point(-5,0),
                new Point(-6,-10),
                new Point(0,-12),
                new Point(6,-10),
                new Point(5,0),
                new Point(0,15)
            };
            //Todo: Make a dictionary of the chosen colors...
            var vpcs = "-5,0;-6,-10;0,-12;6,-10;5,0;0,15".VerticeLines(new Dictionary<int, Color> { {0,Color.White }, { 1, Color.CadetBlue }, { 2, Color.Blue }, { 3, Color.DarkRed } });

            vertices.AddRange(vpcs);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.LineList, baseVertex: 0, startIndex: 0, primitiveCount: verticeArray.Length / 2);
            }
        }

        public void Notify(params object[] messages)
        {
            throw new NotImplementedException();
        }

        public void NotifyMove(Room room)
        {
            
            this.room = room;
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
