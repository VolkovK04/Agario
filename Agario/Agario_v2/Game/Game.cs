using System;
using System.Collections.Generic;

namespace Agario_v2
{
    class Game
    {
        private readonly static Random random = new Random();

        public Game(GameRules gameRules)
        {
            GameRule = gameRules;
            KillListId = new List<int>();
            Time = 0;
        }

        public List<Agar> Agars { get; }
        public List<Food> Foods { get; }

        public GameRules GameRule { get;}

        private List<int> KillListId { get; set; }

        public int Time { get; private set; }


        public void AddAgar(Agar agar)
        {
            int index = Agars.BinarySearch(agar);
            if (index < 0)
                Agars.Insert(~index, agar);
            else
                Agars.Insert(index, agar);
        }
        public void KillEntities()
        {
            foreach(int id in KillListId)
            {
                int index = Entities.FindIndex(x => x.Id == id);
                Entities.RemoveAt(index);
            }
            KillListId.Clear();
        }
        public int AddAgar()
        {
            Agar agar = new Agar(random.NextPoint(GameRule.MapSize))
            {
                Velosity = random.NextVec()
            };
            AddAgar(agar);

            return agar.Id;
        }
        public void AddAgars(int count)
        {
            for (int i=0; i<count; i++)
            {
                AddAgar();
            }
        }
        public void AddFood(int count)
        {
            for (int i=0; i<count; i++)
            {
                Food food = new Food(random.NextPoint(GameRule.MapSize));
                int index = Foods.BinarySearch(food);
                if (index < 0)
                    Foods.Insert(~index, food);
                else
                    Foods.Insert(index, food);
            }
        }
        private bool IsAlive(int id)
        {
            return KillListId.Find(x => x == id) < 0 || KillListId.Count == 0;
        }
        public void Step()
        {
            AddFood(GameRule.FoodGeneration);

            for (int i = 0; i < Agars.Count; i++)
            {
                Agar agar = Agars[i];
                agar.Position = (agar.Position + agar.Velosity * GameRule.TimeScale).InMap(GameRule.MapSize);
                for (int j = 0; j < i; j++)
                {
                    Agar agar1 = Agars[j];
                    if (!IsAlive(agar1.Id))
                        break;
                    if (agar.Size > agar1.Size * GameRule.CanEatRate)
                    {
                        if (agar.Position.DistanceTo(agar1.Position) < agar.Size / 2)
                        {
                            KillListId.Add(agar1.Id);
                            agar.AddSize(agar1.Size);
                        }
                    }
                    else
                        break;
                }
            }
            KillEntities();
            Agars.Sort();
            Time++;
        }

    }
}
