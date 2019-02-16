using BoardGraph;
using Microsoft.Xna.Framework;
using MonoGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NemesisMonoUI
{
    public class RoomView : ViewBase, Collidable
    {
        Room room;
        public Rectangle rectangle;
        public Listener listener;
    //    public List<TargetView> targetView;
        
        public RoomView(Room room, BoardView boardView, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.room = room;
            rectangle = new Rectangle(room.RoomPoint(), new Point(RoomViewExtensions.roomSquareWidth));
            listener = boardView;
        //    targetView = new List<TargetView>();
            vertices = room.GetVerts(boardView.board.random).ToList();
            Init(graphicsDevice);
        }

        public override void Init(GraphicsDevice graphicsDevice)
        {
            verticeArray = vertices.ToArray();
            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), verticeArray.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(verticeArray);
            indices = new short[]
            {
                0,1,2,
                0,2,3,
                0,3,4,
                0,4,5,
                0,5,6,
                0,1,6
            };
            indexBuffer = new IndexBuffer(graphicsDevice, typeof(short), indices.Length, BufferUsage.WriteOnly);
        //    indexBuffer.SetData(indices);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            PrepareDraw(graphicsDevice);

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, baseVertex: 0, startIndex: 0, primitiveCount: indexBuffer.IndexCount );
            }
        }

        public void Draw(GraphicsBatch graphicsBatch)
        {
            //graphicsBatch.Draw
            //(
            //    texture: graphicsBatch.Pixel,
            //    destinationRectangle: rectangle,
            //    color: Color.DarkBlue
            //);
        }

        private void Debug()
        {
            if(room.name == "Cockpit")
            {
                Console.WriteLine(
                room.RoomPoint());
            }
        }

        bool Collidable.PointOnEdge(Point p)
        {
            throw new NotImplementedException();
        }

        bool Collidable.PointWithinBounds(Point p)
        {
            bool minX = p.X > rectangle.Left;
            bool maxX = p.X < rectangle.Right;
            bool minY = p.Y > rectangle.Top;
            bool maxY = p.Y < rectangle.Bottom;
            bool hit = minX && maxX && minY && maxY;

            return hit;
        }

        bool Collidable.RectangleTouch(Rectangle r)
        {
            throw new NotImplementedException();
        }

        bool Collidable.RectangleOverlap(Rectangle r)
        {
            throw new NotImplementedException();
        }

        bool Collidable.RectangleWithinBounds(Rectangle r)
        {
            throw new NotImplementedException();
        }

        void Collidable.Activate(Board board)
        {
            room.isDiscovered = true;
            board.roomEvents.Pick().Perform(board, room);
        }

        public override string ToString()
        {
            return room.name + " " + room.description;
        }
    }

    public static class RoomViewExtensions
    {
        public static int roomSquareWidth = 160;

        public static IEnumerable<VertexPositionColor> GetVerts(this Room room, Random random)
        {
            var hexScale = roomSquareWidth / 4;
            var vectors = new Vector2[] 
            {
                new Vector2(2,2) * hexScale,
                new Vector2(0,1) * hexScale,
                new Vector2(2,0) * hexScale,
                new Vector2(4,1)* hexScale,
                new Vector2(4,3)* hexScale,
                new Vector2(2,4)* hexScale,
                new Vector2(0,3) * hexScale
            };

            var colors = new Vector3[]
            {
                new Vector3(25,20,20),
                new Vector3(30,30,30),
                new Vector3(30,30,30),
                new Vector3(30,30,30),
                new Vector3(30,30,30),
                new Vector3(30,30,30),
                new Vector3(30,30,30)
               

               // Color.LightGray,
               // Color.DarkSeaGreen,
               // Color.DarkBlue,
               // Color.DarkSlateGray,
               // Color.Gray
            };

            var roomVector = room.RoomVector();
            return vectors
            .Select((r, i) => new VertexPositionColor
            {
                Position = new Vector3(r + roomVector, 0),
                Color = new Color(colors[i]/255f + RandomisedVector3(random, 5)/255f) 
            });
        }

        public static Vector3 RandomisedVector3(Random random, int size)
        {
            if (size > 256) size = 256;
            return new Vector3(random.Next(size), random.Next(size), random.Next(size));
        }
     
        public static int RoomScale { get => 20; }



        public static void DrawText(this Room room, GraphicsBatch graphicsBatch)
        {
            string name = room.isDiscovered ? room.name : "unknown";
            graphicsBatch.DrawString(graphicsBatch.DefaultFont, name, new Vector2(room.x, room.y) * RoomScale, Color.GhostWhite);
            graphicsBatch.DrawString(graphicsBatch.DefaultFont, room.RoomPoint().ToString(), new Vector2(room.x, room.y+1) * RoomScale, Color.GhostWhite);
        }
      
        public static Point RoomPoint(this Room room)
        {
            return new Point(room.x * RoomScale, room.y * RoomScale);
        }

        public static Vector2 RoomVector(this Room room)
        {
            return new Vector2(room.x * RoomScale, room.y * RoomScale);
        }

        public static Vector2 RoomCenterVector(this Room room)
        {
            return new Vector2(room.x * RoomScale + roomSquareWidth/2f, room.y * RoomScale + roomSquareWidth/2f);
        }
    }
}
