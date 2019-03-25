using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib
{
    public class GraphicsBatch : SpriteBatch
    {
        public Texture2D Pixel { get; set; }
        public SpriteFont DefaultFont { get; set; }
        public GraphicsBatch(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            
        }
    }
}
