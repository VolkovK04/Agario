namespace Agario_v2
{
    class GameRules
    {
        public readonly static GameRules Defoult = new GameRules()
        {
            MapSize = new Size(1000, 1000),
            FoodGeneration = 1,
            TimeScale = 10,
            CanEatRate = 1.1
        };
        private GameRules() { }
        public GameRules(Size mapSize)
        {
            MapSize = mapSize;
            FoodGeneration = Defoult.FoodGeneration;
            TimeScale = Defoult.TimeScale;
            CanEatRate = Defoult.CanEatRate;
        }
        public Size MapSize { get; set; }
        public int FoodGeneration { get; set; }
        public double TimeScale { get; set; }
        public double CanEatRate { get; set; }

    }
}
