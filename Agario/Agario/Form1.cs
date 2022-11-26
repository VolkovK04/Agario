using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Agario.Drawing;

namespace Agario
{
    public partial class Form1 : Form
    {
        private readonly Game game;
        private Bitmap img;
        private readonly Timer timer;
        readonly Selector selector;
        readonly Stopwatch stopwatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            Size MapSize = pictureBox1.Size;
            GameRule gameRules = new GameRule(MapSize);
            game = new Game(gameRules);
            //game.AddAgars(9);
            img = (Bitmap)MapSize;

            game.AddAgarWithPlayer();
            timer = new Timer
            {
                Interval = 1
            };
            timer.Tick += Timer_Tick;

            selector = new Selector(game);
            pictureBox1.Click += PictureBox_Click;
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            Point curPoint = ToGameCoordinate(Cursor.Position);
            selector.Select(curPoint);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            stopwatch.Restart();
            game.Go();
            img.Draw(game);
            pictureBox1.Image = img;


            Vec vec = ToGameCoordinate(Cursor.Position) - Player.Agar.Position;
            Player.SetDirection(vec);
            stopwatch.Stop();

            WriteLabels();
            ticks++;
        }
        int ticks = 0;
        private void WriteLabels()
        {
            if (selector.IsSelected)
                label1.Text = selector.SelectedEntity.Info();
            label2.Text = $"Time: {Math.Round(game.Time, 2)}";
            if (ticks%10==0)
            label3.Text = $"FPS: {1000 / stopwatch.ElapsedMilliseconds}";
        }
        private void StartStopBtn_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
        }

        private void PictureBox_SizeChanged(object sender, EventArgs e)
        {
            Size MapSize = pictureBox1.Size;
            game.GameRule.MapSize =MapSize;
            img = (Bitmap)MapSize;
        }

        private Point ToGameCoordinate(Point point)
        {
            return new Point
            {
                X = point.X - Location.X - 8,
                Y = point.Y - Location.Y - 32
            };
        }

    }
}
