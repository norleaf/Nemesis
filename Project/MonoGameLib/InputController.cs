using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprites;
using Microsoft.Xna.Framework.Input;
using BoardGraph;

namespace MonoGameLib
{
    public class InputController
    {
        Board board;
        public CollisionController cc;
        private bool mousePressed = false;

        public InputController(Board board)
        {
            this.board = board;
            cc = new CollisionController();
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
            Collidable collider = null;
            cc.CheckMouseClick(out hit, out collider);
            if(hit)
            {
                collider.Activate(board);
            }
        }
    }

    
}
