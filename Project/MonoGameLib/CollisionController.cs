using BoardGraph;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprites;
using System.Collections.Generic;

namespace MonoGameLib
{
    public class CollisionController
    {
        public List<Collidable> collidables;

        public CollisionController()
        {
            collidables = new List<Collidable>();
        }

        public void CheckMouseClick(out bool collision, out Collidable collider)
        {
            collision = false;
            collider = null;
            var mousePos = Mouse.GetState().Position;
            foreach (var item in collidables)
            {
                if(item.PointWithinBounds(mousePos))
                {
                    collision = true;
                    collider = item;
                }
            }
        }

        
    }

    public interface Collidable
    {
        bool PointOnEdge(Point p);
        bool PointWithinBounds(Point p);
        bool RectangleTouch(Rectangle r);
        bool RectangleOverlap(Rectangle r);
        bool RectangleWithinBounds(Rectangle r);
        void Activate(Board board);
    }
}