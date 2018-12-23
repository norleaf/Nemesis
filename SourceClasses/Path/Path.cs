using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace NemesisClasses
{
    public class Path
    {
        public List<Point> points;
        public Point currentPoint;
        public int speed;

        public Path()
        {
            points = new List<Point>();
        }

        public void AddPoint(Point point)
        {
            points.Add(point);
        }

        public Point GetNextPoint()
        {
            Point p;
            if (points == null || points.Count == 0) throw new Exception("Trying to GetNextPoint with no points in path");
            if (currentPoint == null) p = points[0];
            else
            {
                int index = points.IndexOf(currentPoint);
                p = points[index + 1];
            }
            return p;
        }

        /// <summary>
        /// position is the origin of the movement, destination will allways be the next point in the path.
        /// make sure there are points in the path.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Point GetNextStep(Point position)
        {
            if (points == null || points.Count == 0) throw new Exception("Trying to GetNextStep with no points in path");
            if (currentPoint == null) currentPoint = points[0];
            if (speed == 0) speed = 1;
            Vector2 vector = Vector2.Subtract(currentPoint.ToVector2(), position.ToVector2());
            Point step;
            if (vector.Length() < speed) step = currentPoint;
            else step = vector.Unit().Scale(speed).ToPoint();

            return step;
        }

        /// <summary>
        /// format of data should be x1,y1;x2,y2;...xn,yn
        /// </summary>
        /// <param name="data"></param>
        public void PopulateList(string data)
        {
            points.Clear();
            string[] pointsStrings = data.Split(';');
            List<Point> list = pointsStrings
                .Select(o => o.Split(',')
                    .Select(s => int.Parse(s))
                    .ToArray()
                )
                .Select(o => new Point(o[0], o[1]))
                .ToList()
                ;
        }
    }
}