namespace Agario.Entities
{
    class AgarWithPlayer : Agar
    {
        public AgarWithPlayer(Point position, Vec velosity, GameRule gameRule) : base(position, velosity, gameRule)
        {
            Player.SetAgar(this);
            OnGo += Player.Go;
        }
    }
}
