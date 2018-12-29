using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class Sprite
    {

        public Texture2D Tex { get; set; }
        public Vector2 Pos { get; set; }


        public bool HasPointWithinBounds(Point point)
        {
            return Pos.X < point.X && Pos.X + Tex.Width > point.X
                && Pos.Y < point.Y && Pos.Y + Tex.Height > point.Y;
        }

    }
}