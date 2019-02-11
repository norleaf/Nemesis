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
    public class Light : ViewBase
    {
        public Light(Rectangle rect ,GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            vertices = new List<VertexPositionColor>
            {
                new VertexPositionColor(new Vector3(300,300,0),Color.GhostWhite)
            };
            Init(graphicsDevice);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            PrepareDraw(graphicsDevice);

        }
    }
}
