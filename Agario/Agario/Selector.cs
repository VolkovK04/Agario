using System;
using System.Collections.Generic;
using Agario.Entities;

namespace Agario
{
    class Selector
    {
        private readonly Game game;
        public Selector(Game game)
        {
            this.game = game;
        }
        public bool IsSelected { get; private set; } = false;
        public Entity SelectedEntity { get; private set; }
        public bool Select(Point point)
        {
            List<Entity> entities = new List<Entity>();
            entities.AddRange(game.Foods);
            entities.AddRange(game.Agars);
            entities.Sort();
            entities.Reverse();
            foreach(var entity in entities)
            {
                if (entity.Position.DistanceTo(point) < Math.Sqrt(entity.Size))
                {
                    SelectedEntity = entity;
                    IsSelected = true;
                    return true;
                }
            }
            return false;
        }
    }
}
