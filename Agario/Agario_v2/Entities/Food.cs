using System;
using System.Drawing;

namespace Agario_v2
{
    class Food
    {
        public static double DefoultSize = 50;

        public static IdGenerator idGenerator = new IdGenerator();

        private readonly static Random random = new Random();

        public Food(Point position, double size, Color color)
        {
            Position = position;
            Size = size;
            Color = color;
            Id = idGenerator.SetId();
        }
        public Food(Point position, double size) : this(position, size, random.NextColor()) { }
        public Food(Point position) : this(position, DefoultSize) { }

        public int Id { get; }
        public Point Position { get; set; }
        public double Size { get; private set; }
        public Color Color { get; }
    }
}
