using System;

namespace Agario.Entities
{
    class Food : Entity
    {
        private readonly static Random random = new Random();

        public Food(Point position, GameRule gameRule) 
            : base(position, new Vec(), gameRule.DefoultFoodSize, new Texture(random.NextColor()), gameRule) { }
        public Food(GameRule gameRule) : this(random.NextPoint(gameRule.MapSize), gameRule) { }
    }
}
