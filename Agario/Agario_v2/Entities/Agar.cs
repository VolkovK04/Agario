using System;
using System.Drawing;

namespace Agario_v2
{
    class Agar
    {
        private readonly static Random random = new Random();

        public static IdGenerator idGenerator = new IdGenerator();

        public static double DefoultSize = 100;
        
        public Agar(Point position, Vec velosity, double size, Color color)
        {
            Position = position;
            Velosity = velosity;
            Size = size;
            Color = color;
            Id = idGenerator.SetId();
        }
        public Agar(Point position, Vec velosity, double size) : this(position, velosity, size, random.NextColor()) { }
        public Agar(Point position, double size) : this(position, new Vec(), size) { }
        public Agar(Point position) : this(position, DefoultSize) { }

        public int Id { get; }
        public Point Position { get; set; }
        public double Size { get; private set; }
        public Vec Velosity { get; set; }
        public Color Color { get; }
        public void AddSize(double addedSize)
        {
            Size = Math.Sqrt(Size * Size + addedSize * addedSize);
        }


    }
}
