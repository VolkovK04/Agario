using System;

namespace Agario.Entities
{
    class Agar : Entity
    {
        private readonly static Random random = new Random();

        public Agar(Point position, Vec velosity, double size, GameRule gameRule) 
            : base(position, velosity, size, new Texture(random.NextColor(), 3), gameRule) { }
        public Agar(Point position, Vec velosity, GameRule gameRule) : this(position, velosity, gameRule.DefoultAgarSize, gameRule) { }
        public Agar(Point position, double size, GameRule gameRule) : this(position, new Vec(), size, gameRule) { }
        public Agar(Point position, GameRule gameRule) : this(position, new Vec(), gameRule) { }


        public bool Eat(Entity entity, double CanEatRate)
        {
            if (!entity.IsAlive)
                return false;
            if (Size > entity.Size * CanEatRate)
            {
                if (Position.DistanceTo(entity.Position) < Math.Sqrt(Size))
                {
                    entity.Kill();
                    AddSize(entity.Size);
                    return true;
                }
            }
            return false;
        }

    }
}
