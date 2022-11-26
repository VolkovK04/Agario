using System;

namespace Agario.Entities
{
    abstract class Entity : IComparable
    {
        public event Action OnGo;
        public event Action OnKill;
        public event Action OnSizeChanged;

        public static IdGenerator idGenerator = new IdGenerator();

        public Entity(Point position, Vec velosity, double size, Texture texture, GameRule gameRule)
        {
            Position = position;
            Velosity = velosity;
            Size = size;
            Texture = texture;
            this.gameRule = gameRule;
        }

        private readonly GameRule gameRule;

        public int Id { get; } = idGenerator.SetId();
        public Point Position { get; private set; }
        public Vec Velosity { get; private set; }
        public double Size { get; private set; }       
        public Texture Texture { get; set; }
        public bool IsAlive { get; private set; } = true;

        public void AddVelosity(Vec acceleration)
        {
            double a = gameRule.Viscosity * gameRule.EntitySpeed * Math.Sqrt(gameRule.DefoultAgarSize/Size);
            acceleration = a* acceleration.Norm();
            Velosity *= (1 - gameRule.Viscosity);
            Velosity += acceleration;
        }

        public void Go()
        {
            OnGo?.Invoke();
            Point newPosition = Position + Velosity * gameRule.TimeScale;
            if (newPosition.X > gameRule.MapSize.Width || newPosition.X < 0)
                Velosity.X = 0;
            if (newPosition.Y > gameRule.MapSize.Height || newPosition.Y < 0)
                Velosity.Y = 0;

            Position = newPosition.InMap(gameRule.MapSize);
            LoseSize();
        }
        
        public void Kill()
        {
            OnKill?.Invoke();
            IsAlive = false;
        }
        
        public void AddSize(double addedSize)
        {
            Size += addedSize;
            OnSizeChanged?.Invoke();
        }
        
        public void LoseSize()
        {
            Size *= gameRule.SizeLoss;
            if (Size < 1)
                Kill();
            OnSizeChanged?.Invoke();
        }

        public int CompareTo(object obj)
        {
            int r= Size.CompareTo(((Entity)obj).Size);
            if (r != 0)
                return r;
            return Id.CompareTo(((Entity)obj).Id);
        }

        public string Info()
        {
            return
                $"EnityType\t {GetType()}\n" +
                $"Id\t {Id}\n" +
                $"Size\t {Math.Round(Size, 2)}\n" +
                $"Position.X\t {Math.Round(Position.X, 2)}\n" +
                $"Position.Y\t {Math.Round(Position.Y, 2)}\n" +
                $"Velosity\t {Math.Round(Velosity.Mod(), 2)}\n" +
                $"IsAlive\t {IsAlive}\n";
        }

    }
}
