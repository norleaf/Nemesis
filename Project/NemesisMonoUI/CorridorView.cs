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
    public static class CorridorView
    {
        public static IEnumerable<VertexPositionColor> GetVerts(this Corridor corridor, Board board)
        {
            var rooms = corridor.roomIDs.Select(r =>  board.GetRoom(r));
            var verts = rooms.Select(r=> 
                new VertexPositionColor
                (
                    new Vector3(r.x*20,r.y*20,0),
                    r.id.GetColor(rooms)
                )
            );
            
            return verts;
        }

        public static Color GetColor(this int id, IEnumerable<Room> rooms)
        {
            Color color = id == rooms.Max(g => g.id) ? Color.BlanchedAlmond : Color.Black;
            color = rooms.Any(r=> r.id == 999) ? Color.AliceBlue : color;
            return color;
        }

        
    }
}
