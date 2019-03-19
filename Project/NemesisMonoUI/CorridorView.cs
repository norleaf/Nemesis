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
    public class CorridorsView : ViewBase
    {
        List<CorridorView> corridorViews;


        public CorridorsView(Board board, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            corridorViews = board.corridors.Select(r => new CorridorView(r, board, graphicsDevice)).ToList();
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            corridorViews.ForEach(r => r.Draw(graphicsDevice));
        }

        public void Draw(GraphicsBatch graphicsBatch)
        {
            throw new NotImplementedException();
        }
    }

    public class CorridorView : ViewBase, Listener
    {
        public static Color noiseColor = new Color(255, 0, 0);
        Corridor corridor;
     
        public CorridorView(Corridor corridor, Board board, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.corridor = corridor;
            corridor.listener = this;
            noiseColor = Color.Red;
            var verts = GetVerts(corridor,board);
            vertices.AddRange(verts);
            Init(graphicsDevice);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            if(corridor.noise)
            {
                vertices = vertices.Select(r => new VertexPositionColor(r.Position,noiseColor)).ToList();
                vertexBuffer.SetData(VerticeArray);
            }
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
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.LineList, baseVertex: 0, startIndex: 0, primitiveCount: VerticeArray.Length / 2);
            }
        }

        public IEnumerable<VertexPositionColor> GetVerts(Corridor corridor, Board board)
        {
            var rooms = corridor.roomIDs.Select(r => board.GetRoom(r));
            var verts = rooms.Select(r =>
                new VertexPositionColor
                (
                    new Vector3(r.RoomCenterVector(), 0),
                    r.id.GetColor(rooms)
                )
            );
            return verts;
        }

        public void Notify(params object[] messages)
        {
            foreach(var message in messages)
            {
                switch (message)
                {
                    case "noise":
                        Console.WriteLine("here!");
                        break;
                    default:
                        break;
                }
            }
        }

        public void NotifyMove(Room room)
        {
            throw new NotImplementedException();
        }
    }

    public static class CorridorViewExtensions
    {
        //public static IEnumerable<VertexPositionColor> GetVerts(this Corridor corridor, Board board)
        //{
        //    var rooms = corridor.roomIDs.Select(r =>  board.GetRoom(r));
        //    var verts = rooms.Select(r=> 
        //        new VertexPositionColor
        //        (
        //            new Vector3(r.RoomCenterVector(),0),
        //            r.id.GetColor(rooms)
        //        )
        //    );
        //    return verts;
        //}

        public static Color technical = new Color(0,0,30);
        public static Color color1 = Color.Black;
        public static Color color2 = Color.BlanchedAlmond;
        

        public static Color GetColor(this int id, IEnumerable<Room> rooms)
        {
            Color color = id == rooms.Max(g => g.id) ? color1 : color2;
            color = rooms.Any(r=> r.id == 999) ? technical : color;
            return color;
        }
    }
}
