namespace Agario.Entities
{
    class AgarWithII : Agar
    {
        public AgarWithII(Point position, Vec velosity, Game game) : base(position, velosity, game.GameRule)
        {
            OnGo += new AgarIntellect(game, this).Main;
        }
    }
}
