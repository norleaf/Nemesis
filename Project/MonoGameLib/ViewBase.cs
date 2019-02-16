using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib
{
    public abstract class ViewBase
    {
        public VertexBuffer vertexBuffer;
        public IndexBuffer indexBuffer;
        public BasicEffect basicEffect;
        public List<VertexPositionColor> vertices;
        public VertexPositionColor[] verticeArray;
        public short[] indices;

        public ViewBase(GraphicsDevice graphicsDevice)
        {
            basicEffect = new BasicEffect(graphicsDevice);
            basicEffect.VertexColorEnabled = true;
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter
            (
                0, graphicsDevice.Viewport.Width,     // left, right
                graphicsDevice.Viewport.Height, 0,    // bottom, top
                0, 1
            );
            vertices = new List<VertexPositionColor>();
        }

        public virtual void Init(GraphicsDevice graphicsDevice)
        {
            verticeArray = vertices.ToArray();
            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), verticeArray.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(verticeArray);
            indices = vertices.Select((r, i) => (short)i).ToArray();
            indexBuffer = new IndexBuffer(graphicsDevice, typeof(short), indices.Length, BufferUsage.WriteOnly);
            //indexBuffer.SetData(indices);
        }

        public virtual void PrepareDraw(GraphicsDevice graphicsDevice)
        {
            indexBuffer.SetData(indices);
            graphicsDevice.SetVertexBuffer(vertexBuffer);
            graphicsDevice.Indices = indexBuffer;
            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            graphicsDevice.RasterizerState = rasterizerState;
        }

        public abstract void Draw(GraphicsDevice graphicsDevice);

    }

    public static class ViewExtensions
    {
        public static void Draw<T>(this List<T> list, GraphicsDevice graphicsDevice) where T : ViewBase
        {
            foreach (var item in list)
            {
                item.PrepareDraw(graphicsDevice);
                item.Draw(graphicsDevice);
            }
        }

        public static List<VertexPositionColor> VerticeLines(this string values, Dictionary<int,Color> colors)
        {
            var points = values.Split(';').Select(r => r.Split(',').Select(p => int.Parse(p)).ToArray()).Select(r => new Point(r[0], r[1]));
            var vpcs = points
                .Select((r, i) => new VertexPositionColor
                {
                    Position = new Vector3(r.ToVector2(), 0),
                    Color = colors.ContainsKey(i) ? colors[i] : colors[colors.Keys.Max(k => k)]
                });

            return vpcs.ToList();
        }
    }
}
