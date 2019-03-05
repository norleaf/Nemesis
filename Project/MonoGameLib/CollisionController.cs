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

        public bool CheckMousePosition(Point point, out Collidable collider)
        {
            bool collision = false;
            collider = null;
            //Todo: Make a list where all things collided go to and then prioritise list to see if one or more should active
            foreach (var item in collidables)
            {
                item.Hover = false;
                if(item.PointWithinBounds(point))
                {
                    item.Hover = true;
                    collision = true;
                    collider = item;
                }
            }
            return collision;
        }
    }

    public interface Collidable
    {
        bool Hover { get; set; }

        bool PointOnEdge(Point p);
        bool PointWithinBounds(Point p);
        bool RectangleTouch(Rectangle r);
        bool RectangleOverlap(Rectangle r);
        bool RectangleWithinBounds(Rectangle r);
        void Activate(Board board);
    }
}