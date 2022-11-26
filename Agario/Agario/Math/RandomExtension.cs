using System;
using System.Drawing;

namespace Agario
{
    public static class RandomExtension
    {
        static public Color NextColor(this Random random)
        {
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }
        static public Point NextPoint(this Random random, Size MapSize)
        {
            return new Point(random.NextDouble() * MapSize.Width, random.NextDouble() * MapSize.Height);
        }
        static public Vec NextVec(this Random random)
        {
            return Vec.FromArg(1, random.NextDouble()*2*Math.PI);
        }

    }
}
