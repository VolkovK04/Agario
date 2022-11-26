using Agario.Entities;

namespace Agario
{
    static class Player
    {
        public static Agar Agar { get; private set; }
        private static Vec vec = Vec.Zero;
        public static void SetAgar(Agar agar)
        {
            Agar = agar;
        }
        public static void SetDirection(Vec vec)
        {
            Player.vec = vec;
        }
        public static void Go()
        {
            Agar.AddVelosity(vec);
        }
    }
}
