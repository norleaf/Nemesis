using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib
{
    public interface Drawable
    {
        void Draw(GraphicsDevice graphicsDevice);
        void Draw(GraphicsBatch graphicsBatch);
    }
}
