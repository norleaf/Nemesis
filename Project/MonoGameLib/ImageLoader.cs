using System;
using System.Collections.Generic;
using Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace NemesisGame
{
    public class ImageLoader
    {
        static ContentManager Content { get; set; }

        public static void LoadImages(ContentManager content, List<SpriteGroup> sprites)
        {
            if (Content == null) Content = content;
            int i = 0;
            //B
            CreateImageGroup(sprites, 200 * (i % 4), 0, "B","B2","banan","betonblander");

            //T
            i++;
            CreateImageGroup(sprites, 200 * (i % 4), 0, "T", "tiger","tog","traktor");

            //G
            i++;
            CreateImageGroup(sprites, 200 * (i % 4), 0, "G", "gravko", "giraf","gyngehest");

            //P
            i++;
            CreateImageGroup(sprites, 200 * (i % 4), 0, "P", "papegøje","plask", "pizza","poelsebroed","pompom"); //

            //M
            i++;
            CreateImageGroup(sprites, 200 * (i % 4), 200, "M", "moon","mor");

            //E
            i++;
            CreateImageGroup(sprites, 200 * (i % 4), 200, "E");

            //K
            i++;
            CreateImageGroup(sprites, 200 * (i % 4), 200, "K","ko","kop","kasse","kaj");
          
            //S
            i++;
            CreateImageGroup(sprites, 200 * (i % 4),200, "S","sko","støvle","skammel","skrældebil","sander");
            
       
        }

        private static void CreateImageGroup(List<SpriteGroup> sprites, int x, int y, params string[] imgs)
        {
            var sprGrp = new SpriteGroup();
            foreach (var img in imgs)
            {
                sprGrp.Sprites.Add(
                    new Sprite
                    {
                        Pos = new Vector2(x,y),
                        Tex = Content.Load<Texture2D>(img)
                    }    
                );
            }
            sprites.Add(sprGrp);
        }
    }
}