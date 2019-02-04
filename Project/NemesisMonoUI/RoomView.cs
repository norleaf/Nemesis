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
        private const int LayerDepth = 1;

        public static void DrawText(this Room room, GraphicsBatch graphicsBatch)
        {
            graphicsBatch.DrawString(graphicsBatch.DefaultFont, room.name, new Vector2(room.x, room.y) * 20, Color.Black);

        }
        public static void Draw(this Room room, GraphicsBatch graphicsBatch)
        {
            
            graphicsBatch.Draw(
                texture: graphicsBatch.Pixel,
                destinationRectangle: new Rectangle(room.RoomPoint(), new Point(50, 30)),
                color: Color.Gray
            //    layerDepth: LayerDepth
                );
        }

        public static Point RoomPoint(this Room room)
        {
            return new Point(room.x * 20, room.y * 20);
        }
    }
}
