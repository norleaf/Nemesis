using System;
using System.Collections.Generic;
using Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameLib
{
    public static class ImageLoader
    {
        public static void LoadImages(this ContentManager content, List<SpriteGroup> sprites)
        {
           
       
        }

        private static void CreateImageGroup(this ContentManager content, List<SpriteGroup> sprites, int x, int y, params string[] imgs)
        {
            var sprGrp = new SpriteGroup();
            foreach (var img in imgs)
            {
                sprGrp.Sprites.Add(
                    new Sprite
                    {
                        Pos = new Vector2(x,y),
                        Tex = content.Load<Texture2D>(img)
                    }    
                );
            }
            sprites.Add(sprGrp);
        }
    }
}