using System;

namespace Agario
{
    public class Vec
    {
        public readonly static Vec Zero = new Vec();
        public static Vec FromArg(double Mod, double Arg)
        {
            return new Vec(Mod * Math.Cos(Arg), Mod * Math.Sin(Arg));
        }

        public Vec(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Vec() : this(0, 0) { }
        public double X { get; set; }
        public double Y { get; set; }

        public double Mod()
        {
            return Math.Sqrt(X*X+Y*Y);
        }
        public double Arg()
        {
            return Math.Atan2(Y, X);
        }

        public void MaxMod(double maxMod)
        {
            Vec result  = Math.Min(maxMod, Mod()) * Norm();
            X = result.X;
            Y = result.Y;
        }
        public Vec Norm()
        {
            if (Mod() == 0)
                return Vec.Zero;
            return this / Mod();
        }

        static public Vec operator +(Vec v1, Vec v2)
        {
            return new Vec(v1.X+v2.X, v1.Y+v2.Y);
        }
        static public Vec operator -(Vec v1, Vec v2)
        {
            return new Vec(v1.X - v2.X, v1.Y - v2.Y);
        }
        static public Vec operator *(Vec v, double k)
        {
            return new Vec(v.X * k, v.Y * k);
        }
        static public Vec operator *(double k, Vec v)
        {
            return new Vec(v.X * k, v.Y * k);
        }
        static public Vec operator /(Vec v, double k)
        {
            return new Vec(v.X / k, v.Y / k);
        }
        static public Vec operator -(Vec v)
        {
            return new Vec(-v.X, -v.Y);
        }
    }
}
