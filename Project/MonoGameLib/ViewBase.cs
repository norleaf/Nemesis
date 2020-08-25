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
        public Vector3 offset;
        public VertexBuffer vertexBuffer;
        public IndexBuffer indexBuffer;
        public BasicEffect basicEffect;
        public List<VertexPositionColor> vertices;
        public VertexPositionColor[] VerticeArray
        {
            get => vertices.Select(q => new VertexPositionColor(q.Position + offset, q.Color)).ToArray();
        }
        public List<short> indices;

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
            offset = Vector3.Zero;
            vertices = new List<VertexPositionColor>();
            indices = new List<short>();
        }

        public virtual void Init(GraphicsDevice graphicsDevice)
        {
            if (vertices.Any())
            {
                
                vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), VerticeArray.Length, BufferUsage.WriteOnly);
                vertexBuffer.SetData(VerticeArray);
                indices = vertices.Select((r, i) => (short)i).ToList();
                indexBuffer = new IndexBuffer(graphicsDevice, typeof(short), indices.Count(), BufferUsage.WriteOnly);
            }
        }

        public virtual void PrepareDraw(GraphicsDevice graphicsDevice)
        {
            if (indices.Any())
            {
                indexBuffer.SetData(indices.ToArray());
                graphicsDevice.SetVertexBuffer(vertexBuffer);
                graphicsDevice.Indices = indexBuffer;
                RasterizerState rasterizerState = new RasterizerState();
                rasterizerState.CullMode = CullMode.None;
                graphicsDevice.RasterizerState = rasterizerState;
            }
        }

        public abstract void Draw(GraphicsDevice graphicsDevice);

        public void DefaultDraw(GraphicsDevice graphicsDevice) //Do not make this method virtual, it is meant to be final
        {
            PrepareDraw(graphicsDevice);
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, baseVertex: 0, startIndex: 0, primitiveCount: indexBuffer.IndexCount);
            }
        }

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

        public static VertexPositionColor[] Offset(this List<VertexPositionColor> list, Vector3 offset)
        {
            return list.Select(q => new VertexPositionColor(q.Position + offset, q.Color)).ToArray();
        }

        public static void Add(this List<VertexPositionColor> list, int x, int y, Color color)
        {
            list.Add(new VertexPositionColor(new Vector3(x, y, 0), color));
        }

        public static List<VertexPositionColor> ToVertexPositionColors(this List<Vector3> vector3s, Dictionary<int, Color> colors)
        {
            var vecPosCols = vector3s
                .Select((vector, i) => new VertexPositionColor
                {
                    Position = vector,
                    Color = colors.ContainsKey(i) ? colors[i] : Color.Violet//colors[colors.Keys.Max(k => k)]
                });

            return vecPosCols.ToList();
        }

        public static List<Vector3> ToVector3s(this string input)
        {
            var vectors = input.Split(';', 'x', ' ')
                .Where(c => !string.IsNullOrEmpty(c)
                )
                .Select(r => r.Split(',')
                    .Select(p => int.Parse(p.Trim())).ToArray())
                .Select(r => new Vector3(r[0], r[1], 0));
            return vectors.ToList();
        }
    }
}
