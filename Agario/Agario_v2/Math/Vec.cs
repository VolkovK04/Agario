using System;

namespace Agario_v2
{
    public struct Vec
    {
        public static Vec FromArg(double Mod, double Arg)
        {
            return new Vec(Mod * Math.Cos(Arg), Mod * Math.Sin(Arg));
        }

        public Vec(double x, double y)
        {
            X = x;
            Y = y;
        }

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

        public Vec Norm()
        {
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
