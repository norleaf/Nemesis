using MonoGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NemesisMonoUI
{
    public class NemesisConsole
    {
        public Rectangle rectangle;
        public List<String> strings;
        public Vector2 lineHeight;

        public NemesisConsole(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            strings = new List<string>();
            lineHeight = new Vector2(0, 15);
        }

        public void Add(params object[] lines)
        {
            foreach (var line in lines)
            {
                strings.Add(line.ToString());
            }
        }

        public void DrawText(GraphicsBatch graphicsBatch)
        {
            for (var i = 0; i < strings.Count; i++)
            {
                var pos = rectangle.Location.ToVector2() + lineHeight * i;
                graphicsBatch.DrawString(graphicsBatch.DefaultFont, strings[i], pos, Color.GhostWhite, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 0);
            }
        }
    }
}
