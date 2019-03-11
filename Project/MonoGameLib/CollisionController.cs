using BoardGraph;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprites;
using System.Collections.Generic;
using System.Linq;

namespace MonoGameLib
{
    public class CollisionController
    {
        public List<Collidable> collidables;

        public CollisionController()
        {
            collidables = new List<Collidable>();
        }

        public bool CheckMousePosition(Point point, out List<Collidable> colliders)
        {
            collidables.ForEach(r => r.Hover = false);
         
            //Todo: Make a list where all things collided go to and then prioritise list to see if one or more should active
            colliders = collidables.Where(r => r.PointWithinBounds(point)).ToList();
            colliders.ForEach(r => r.Hover = true);
            
            return colliders.Any();
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