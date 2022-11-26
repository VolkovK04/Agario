using System;

namespace Agario_v2
{
    public struct Point
    {
        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public double X { get; set; }
        public double Y { get; set; }

        static public Point operator +(Point p, Vec v)
        {
            return new Point(p.X+v.X, p.Y+v.Y);
        }
        static public Point operator -(Point p, Vec v)
        {
            return new Point(p.X - v.X, p.Y - v.Y);
        }
        static public Vec operator -(Point p1, Point p2)
        {
            return new Vec(p1.X - p2.X, p1.Y - p2.Y);
        }

        public Point InMap(Size size)
        {
            double x = Math.Min(Math.Max(X, 0), size.Width);
            double y = Math.Min(Math.Max(Y, 0), size.Height);
            return new Point(x, y);
        }
        public double DistanceTo(Point p2)
        {
            return (p2 - this).Mod();
        }
    }
}
