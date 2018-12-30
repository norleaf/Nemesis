using BoardGraph;
using Microsoft.Xna.Framework;
using MonoGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisMonoUI
{
    public static class RoomView
    {
        public static void Draw(this Room room, GraphicsBatch graphicsBatch)
        {
            graphicsBatch.DrawString(graphicsBatch.DefaultFont, room.name, new Vector2(room.x, room.y) * 20, Color.Black);
        }
    }
}
