using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprites;
using Microsoft.Xna.Framework.Input;
using BoardGraph;
using Microsoft.Xna.Framework;

namespace MonoGameLib
{
    public class InputController
    {
        Board board;
        public CollisionController cc;
        private bool mousePressed = false;
        private Point lastMousePosition;
        public Listener listener;

        public InputController(Board board)
        {
            this.board = board;
            cc = new CollisionController();
        }

        public void Update()
        {
            var state = Mouse.GetState();
            if(state.LeftButton == ButtonState.Pressed && mousePressed==false)
            {
                
                mousePressed = true;
                UpdateMousePress(state);
            }
            else if(state.LeftButton == ButtonState.Released && mousePressed == true)
            {
                mousePressed = false;
            }
            if(state.Position.X != lastMousePosition.X || state.Position.Y != lastMousePosition.Y )
            {
                lastMousePosition = state.Position;
                Collidable collider;
                if(cc.CheckMousePosition(state.Position, out collider))
                {
                    //Todo: not sure if we really do anything here...
                }
            }
        }

        public void UpdateMousePress(MouseState state)
        {
            Collidable collider;
            if(cc.CheckMousePosition(state.Position, out collider))
            {
                listener.Notify(collider);
                collider.Activate(board);
            }
        }
    }

    
}
