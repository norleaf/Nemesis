using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprites;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class InputController
    {
        CollisionController cc;
        private List<SpriteGroup> sprites;
        private bool mousePressed = false;

        public InputController()
        {
            
        }

        public InputController(List<SpriteGroup> sprites)
        {
            this.sprites = sprites;
            cc = new CollisionController(sprites);
        }

        public void Update()
        {
            if(Mouse.GetState().LeftButton== ButtonState.Pressed && mousePressed==false)
            {
                mousePressed = true;
                UpdateMousePress();
            }
            else if(Mouse.GetState().LeftButton == ButtonState.Released && mousePressed == true)
            {
                mousePressed = false;
            }
        }

        public void UpdateMousePress()
        {
            
            bool hit = false;
            SpriteGroup spriteGrp = null;
            cc.CheckMouseClick(out hit, out spriteGrp);
            if(hit)
            {
                spriteGrp.Next();
            }
        }
    }
}
