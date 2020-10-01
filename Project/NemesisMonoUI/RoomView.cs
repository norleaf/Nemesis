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
        VertexBuffer borderBuffer;
        VertexPositionColor[] borderVertices;

        public bool Hover { get; set; }

        public RoomView(Room room, BoardView boardView, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.room = room;
            rectangle = new Rectangle(room.RoomPoint(), new Point(RoomViewExtensions.roomSquareWidth));
            listener = boardView;
            vertices = room.GetVerts(boardView.board.random).ToList();
            borderVertices = room.GetBorder();
            Init(graphicsDevice);
        }

        public override void Init(GraphicsDevice graphicsDevice)
        {
            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), VerticeArray.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(VerticeArray);
            borderBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), borderVertices.Length, BufferUsage.WriteOnly);
            borderBuffer.SetData(borderVertices);
            indices = new List<short>
            {
                0,1,2,
                0,2,3,
                0,3,4,
                0,4,5,
                0,5,6,
                0,1,6
            };
            indexBuffer = new IndexBuffer(graphicsDevice, typeof(short), indices.Count, BufferUsage.WriteOnly);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            PrepareDraw(graphicsDevice);

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, baseVertex: 0, startIndex: 0, primitiveCount: indexBuffer.IndexCount);
                if (Hover)
                {
                    graphicsDevice.SetVertexBuffer(borderBuffer);
                    graphicsDevice.DrawPrimitives(PrimitiveType.LineStrip, 0, borderBuffer.VertexCount - 1);
                }
            }
        }

        //public void Draw(GraphicsBatch graphicsBatch)
        //{
        //    //graphicsBatch.Draw
        //    //(
        //    //    texture: graphicsBatch.Pixel,
        //    //    destinationRectangle: rectangle,
        //    //    color: Color.DarkBlue
        //    //);
        //}

        private void Debug()
        {
            if (room.name == "Cockpit")
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
            Option[] options;
            if(room.IsActionable(board, out options))
            {
                //todo: if more than one option show selection.
                
                options[0].ChooseOption(board, board.activePlayer);
            }
            //room.isDiscovered = true;
            //board.activePlayer.roomId = room.id;
            //board.activePlayer.listeners.NotifyMove(room);
            //board.roomEvents.Pick().Perform(board, room);
        }

        public override string ToString()
        {
            return room.name + " " + room.description;
        }
    }

    public static class RoomViewExtensions
    {
        public static int roomSquareWidth = 160;
        public static int hexScale = roomSquareWidth / 4;
        public static Vector3[] HexShapeVectors = new Vector3[]
        {
            new Vector3(0,1,0) * hexScale,
            new Vector3(2,0,0) * hexScale,
            new Vector3(4,1,0)* hexScale,
            new Vector3(4,3,0)* hexScale,
            new Vector3(2,4,0)* hexScale,
            new Vector3(0,3,0) * hexScale
        };
        public static Vector3 RoomCenter = new Vector3(2, 2, 0) * hexScale;

        public static VertexPositionColor[] GetBorder(this Room room)
        {
            return HexShapeVectors.Select(r => new VertexPositionColor { Position = r + room.RoomVector(), Color = Color.White * 0.6f }).ToArray();
        }

        public static IEnumerable<VertexPositionColor> GetVerts(this Room room, Random random)
        {

            var vectors = RoomCenter.StartList().InsertRange(HexShapeVectors);

            var darkgrae = new Vector3(30, 30, 30);
            var darkreddish = new Vector3(25, 20, 20);

            var colors = new Vector3[]
            {
                darkreddish,
                darkgrae, darkgrae, darkgrae,
                darkgrae, darkgrae, darkgrae
            };

            var roomVector = room.RoomVector();
            return vectors
            .Select((r, i) => new VertexPositionColor
            {
                Position = r + roomVector,
                Color = new Color(colors[i] / 255f + RandomisedVector3(random, 5) / 255f)
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
            graphicsBatch.DrawString(graphicsBatch.DefaultFont, name, new Vector2(room.x, room.y) * RoomScale, Color.GhostWhite, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 0);
            graphicsBatch.DrawString(graphicsBatch.DefaultFont, room.RoomPoint().ToString(), new Vector2(room.x, room.y + 1) * RoomScale, Color.GhostWhite, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 0);
            
        }

        public static Point RoomPoint(this Room room)
        {
            return new Point(room.x * RoomScale, room.y * RoomScale);
        }

        public static Vector3 RoomVector(this Room room)
        {
            return new Vector3(room.x * RoomScale, room.y * RoomScale, 0);
        }

        public static Vector2 RoomCenterVector(this Room room)
        {
            return new Vector2(room.x * RoomScale + roomSquareWidth / 2f, room.y * RoomScale + roomSquareWidth / 2f);
        }

        public static Vector3 RoomCenterVector3(this Room room)
        {
            return new Vector3(room.x * RoomScale + roomSquareWidth / 2f, room.y * RoomScale + roomSquareWidth / 2f, 0);
        }
    }
}
