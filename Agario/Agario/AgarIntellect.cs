using System;
using Agario.Entities;

namespace Agario
{
    class AgarIntellect
    {
        public AgarIntellect(Game game, Agar agar)
        {
            Game = game;
            Agar = agar;
        }
        private Game Game { get; }
        private Agar Agar { get; }


        private Vec Func(double size, Vec r)
        {
            return size / Math.Pow(r.Mod()+1, 3) * r;
        }
        private Vec CalculateWish(Entity entity)
        {
            Vec r = entity.Position - Agar.Position;
            if (Agar.Size > entity.Size * Game.GameRule.CanEatRate)
                return Func(entity.Size, r);
            if (entity.Size > Agar.Size * Game.GameRule.CanEatRate && entity is Agar)
                return -Func(entity.Size, r);
            return Vec.Zero;
        }
        public void Main()
        {
            Vec result = Vec.Zero;
            foreach (Food food in Game.Foods)
                result += CalculateWish(food);
            foreach (Agar agar1 in Game.Agars)
                result += CalculateWish(agar1);

            Agar.AddVelosity(result);
        }
    }
}
