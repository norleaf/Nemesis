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
        CorridorView[] corridorViews;


        public CorridorsView(Board board, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            corridorViews = board.corridors.Select(r => new CorridorView(r, board, graphicsDevice)).ToArray();

            //todo: have a vertice collection here that are all the union of all verts from the array of corridors
            var verts = board.corridors.SelectMany(r => r.GetVerts(board));
            vertices.AddRange(verts);
            Init(graphicsDevice);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {

            //todo: figure out how much can be done here commonly instead of in each corridorview 
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

        public void Draw(GraphicsBatch graphicsBatch)
        {
            throw new NotImplementedException();
        }
    }

    public class CorridorView : ViewBase
    {
        Corridor corridor;
        Color color;
        //todo: implement listener and have corridor broadcast whenever it StateChanges to view will know to change color...

        public CorridorView(Corridor corridor, Board board, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            var verts = board.corridors.SelectMany(r => r.GetVerts(board));
            vertices.AddRange(verts);
            Init(graphicsDevice);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
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
    }

    public static class CorridorViewExtensions
    {
        public static IEnumerable<VertexPositionColor> GetVerts(this Corridor corridor, Board board)
        {
            var rooms = corridor.roomIDs.Select(r =>  board.GetRoom(r));
            var verts = rooms.Select(r=> 
                new VertexPositionColor
                (
                    new Vector3(r.RoomCenterVector(),0),
                    r.id.GetColor(rooms)
                )
            );
            return verts;
        }

        public static Color GetColor(this int id, IEnumerable<Room> rooms)
        {
            Color color = id == rooms.Max(g => g.id) ? Color.BlanchedAlmond : Color.Black;
            color = rooms.Any(r=> r.id == 999) ? new Color(30,0,0) : color;
            return color;
        }
    }
}
