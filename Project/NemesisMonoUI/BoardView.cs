using BoardGraph;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisMonoUI
{
    public static class BoardView
    {
        public static void DrawText(this Board board, GraphicsBatch graphicsBatch)
        {
            foreach (var room in board.rooms) room.DrawText(graphicsBatch);
        }

        public static void Draw(this Board board, GraphicsBatch graphicsBatch)
        {
            foreach (var room in board.rooms)
            {
                room.Draw(graphicsBatch);
            }
        }

    }
}
