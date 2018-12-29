using Microsoft.Xna.Framework.Input;
using Sprites;
using System.Collections.Generic;

namespace Game1
{
    public class CollisionController
    {
        private List<SpriteGroup> sprites;

        public CollisionController(List<SpriteGroup> sprites)
        {
            this.sprites = sprites;
        }

        public void CheckMouseClick(out bool collision, out SpriteGroup group)
        {
            collision = false;
            group = null;
            var mousePos = Mouse.GetState().Position;
            foreach (var spriteGrp in sprites)
            {
                if(spriteGrp.Current.HasPointWithinBounds(mousePos))
                {
                    collision = true;
                    group = spriteGrp;
                }
            }
        }

        
    }
}