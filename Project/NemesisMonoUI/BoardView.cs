using BoardGraph;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisMonoUI
{
    public static class ViewExtensions
    {
        public static void DrawText(this BoardView view, GraphicsBatch graphicsBatch)
        {
            foreach (var room in view.board.rooms.Values)
            {
                room.DrawText(graphicsBatch);
            }
            view.nemesisConsole.DrawText(graphicsBatch);
        }
    }

    public class BoardView : ViewBase, Listener
    {
        public Board board;
        public RoomView[] roomView;
        public TargetsView targetsView;
        public CorridorView corridorView;
        public NemesisConsole nemesisConsole;
       
        public BoardView(Board board, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.board = board;
            roomView = board.Rooms().Select(r => new RoomView(r, this, graphicsDevice)).ToArray();
            targetsView = new TargetsView(board,graphicsDevice);
            targetsView.AddAll(board, graphicsDevice);
            corridorView = new CorridorView(board, graphicsDevice);
            nemesisConsole = new NemesisConsole(new Rectangle(1600,0,320,1080));
            nemesisConsole.Add("New game.");
        }

        public void DrawGraphics(GraphicsBatch graphicsBatch)
        {
            foreach (var room in roomView)
            {
                room.Draw(graphicsBatch);
            }
            Draw(graphicsBatch.GraphicsDevice);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {

            
            corridorView.Draw(graphicsDevice);
            foreach (var room in roomView)
            {
                room.Draw(graphicsDevice);
            }
            targetsView.Draw(graphicsDevice);
            
        }

        public void Notify(object[] messages)
        {
            nemesisConsole.Add(messages);
        }



        private void DrawTestVertices(GraphicsDevice graphicsDevice)
        {
         //  basicEffect.CurrentTechnique.Passes[0].Apply();
         //  graphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, verticeArray, vertexOffset: 0, primitiveCount: verticeArray.Length / 2);
        }

        public void DemoFromInternet_DrawingIn3D()
        {

            //  Matrix world = Matrix.CreateTranslation(0, 0, 0);
            //  Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            //  Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 100f);

            /*
            basicEffect = new BasicEffect(graphicsDevice);
            // vertex position and color information for icosahedron
            vertices[0] = new VertexPositionColor(new Vector3(-0.26286500f, 0.0000000f, 0.42532500f), Color.Red);
            vertices[1] = new VertexPositionColor(new Vector3(0.26286500f, 0.0000000f, 0.42532500f), Color.Orange);
            vertices[2] = new VertexPositionColor(new Vector3(-0.26286500f, 0.0000000f, -0.42532500f), Color.Yellow);
            vertices[3] = new VertexPositionColor(new Vector3(0.26286500f, 0.0000000f, -0.42532500f), Color.Green);
            vertices[4] = new VertexPositionColor(new Vector3(0.0000000f, 0.42532500f, 0.26286500f), Color.Blue);
            vertices[5] = new VertexPositionColor(new Vector3(0.0000000f, 0.42532500f, -0.26286500f), Color.Indigo);
            vertices[6] = new VertexPositionColor(new Vector3(0.0000000f, -0.42532500f, 0.26286500f), Color.Purple);
            vertices[7] = new VertexPositionColor(new Vector3(0.0000000f, -0.42532500f, -0.26286500f), Color.White);
            vertices[8] = new VertexPositionColor(new Vector3(0.42532500f, 0.26286500f, 0.0000000f), Color.Cyan);
            vertices[9] = new VertexPositionColor(new Vector3(-0.42532500f, 0.26286500f, 0.0000000f), Color.Black);
            vertices[10] = new VertexPositionColor(new Vector3(0.42532500f, -0.26286500f, 0.0000000f), Color.DodgerBlue);
            vertices[11] = new VertexPositionColor(new Vector3(-0.42532500f, -0.26286500f, 0.0000000f), Color.Crimson);

            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), 12, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(vertices);

            short[] indices = new short[60];
            indices[0] = 0; indices[1] = 6; indices[2] = 1;
            indices[3] = 0; indices[4] = 11; indices[5] = 6;
            indices[6] = 1; indices[7] = 4; indices[8] = 0;
            indices[9] = 1; indices[10] = 8; indices[11] = 4;
            indices[12] = 1; indices[13] = 10; indices[14] = 8;
            indices[15] = 2; indices[16] = 5; indices[17] = 3;
            indices[18] = 2; indices[19] = 9; indices[20] = 5;
            indices[21] = 2; indices[22] = 11; indices[23] = 9;
            indices[24] = 3; indices[25] = 7; indices[26] = 2;
            indices[27] = 3; indices[28] = 10; indices[29] = 7;
            indices[30] = 4; indices[31] = 8; indices[32] = 5;
            indices[33] = 4; indices[34] = 9; indices[35] = 0;
            indices[36] = 5; indices[37] = 8; indices[38] = 3;
            indices[39] = 5; indices[40] = 9; indices[41] = 4;
            indices[42] = 6; indices[43] = 10; indices[44] = 1;
            indices[45] = 6; indices[46] = 11; indices[47] = 7;
            indices[48] = 7; indices[49] = 10; indices[50] = 6;
            indices[51] = 7; indices[52] = 11; indices[53] = 2;
            indices[54] = 8; indices[55] = 10; indices[56] = 3;
            indices[57] = 9; indices[58] = 11; indices[59] = 0;

            indexBuffer = new IndexBuffer(graphicsDevice, typeof(short), indices.Length, BufferUsage.WriteOnly);
            indexBuffer.SetData(indices);
              */

            //basicEffect.World = world;
            //basicEffect.View = view;
            //basicEffect.Projection = projection;
            //basicEffect.VertexColorEnabled = true;

            //FROM BELOW THIS POINT PUT CODE IN A DRAW METHOD

            //graphicsDevice.SetVertexBuffer(vertexBuffer);
            //graphicsDevice.Indices = indexBuffer;

            //RasterizerState rasterizerState = new RasterizerState();
            //rasterizerState.CullMode = CullMode.None;
            //graphicsDevice.RasterizerState = rasterizerState;

            //foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            //{
            //    pass.Apply();

            //    //graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList,baseVertex:0,startIndex:0,primitiveCount:20);
            //    graphicsDevice.DrawIndexedPrimitives(PrimitiveType.LineStrip,baseVertex:0,startIndex:0,primitiveCount:20);
            //}

        }

        public void NotifyMove(Room room)
        {
            throw new NotImplementedException();
        }
    }


}
