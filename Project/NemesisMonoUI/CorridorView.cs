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
    public class CorridorView : ViewBase
    {
        public CorridorView(Board board, GraphicsDevice graphicsDevice) : base(graphicsDevice)
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
