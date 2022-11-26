namespace Agario
{
    class GameRule
    {
        private GameRule() { }
        public GameRule(Size mapSize)
        {
            MapSize = mapSize;
        }
        public Size MapSize { get; set; } = new Size(1000, 1000);
        public int FoodGeneration { get; set; } = 1;
        public double TimeScale { get; set; } = 0.01;
        public double CanEatRate { get; set; } = 1.2;
        public double Viscosity { get; set; } = 0.1;
        public double SizeLoss { get; set; } = 0.999;
        public double DefoultFoodSize { get; set; } = 50;
        public double DefoultAgarSize { get; set; } = 100;
        public double EntitySpeed { get; set; } = 500;
    }
}
