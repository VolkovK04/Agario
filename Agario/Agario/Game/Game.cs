using System;
using System.Collections.Generic;
using Agario.Entities;
using System.Drawing;

namespace Agario
{
    class Game
    {
        private readonly static Random random = new Random();

        public Game(GameRule gameRules, params Agar[] agars)
        {
            Agars = new List<Agar>(agars);
            GameRule = gameRules;
        }

        public List<Agar> Agars { get; } = new List<Agar>();
        public List<Food> Foods { get; } = new List<Food>();
        public GameRule GameRule { get;}
        public double Time { get; private set; } = 0;

        private void KillDeadEntities()
        {
            Foods.RemoveAll(x => !x.IsAlive);
            Agars.RemoveAll(x => !x.IsAlive);
        }
        public void AddAgarWithPlayer()
        {
            Agar agar = new AgarWithPlayer(random.NextPoint(GameRule.MapSize), Vec.Zero, GameRule)
            {
                Texture = new Texture(Color.Red, 3)
            };
            Player.SetAgar(agar);
            agar.OnKill += AddAgarWithPlayer;
            Agars.SortAdd(agar);
        }
        public void AddAgar()
        {
            Agar agar = new AgarWithII(random.NextPoint(GameRule.MapSize), Vec.Zero, this);
            agar.OnKill += AddAgar;
            Agars.SortAdd(agar);
        }
        public void AddAgars(int count)
        {
            for (int i=0; i<count; i++)
                AddAgar();
        }
        private void AddFood(int count)
        {
            for (int i=0; i<count; i++)
            {
                Food food = new Food(random.NextPoint(GameRule.MapSize), GameRule);
                Foods.Add(food);
            }
        }
        public void Go()
        {
            if ((int)Time%30==0)
            AddFood(GameRule.FoodGeneration);

            for (int i = 0; i < Agars.Count; i++)
            {
                Agars[i].Go();

                foreach(Food food in Foods)
                {
                    Agars[i].Eat(food, GameRule.CanEatRate);
                }

                for (int j = 0; j < i; j++)
                {
                    Agars[i].Eat(Agars[j], GameRule.CanEatRate);
                }
            }
            KillDeadEntities();
            Agars.Sort();
            Time++;
        }

    }
}
