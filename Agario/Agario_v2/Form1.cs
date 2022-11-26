using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agario_v2
{
    public partial class Form1 : Form
    {
        private readonly Game game;
        private readonly Bitmap img;
        public Form1()
        {
            InitializeComponent();
            Size MapSize = pictureBox1.Size;
            GameRules gameRules = new GameRules(MapSize);
            game = new Game(gameRules);
            game.AddAgars(10);

            img = (Bitmap)MapSize;
            img.Draw(game);
            pictureBox1.Image = img;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            game.Step();
            img.Draw(game);
            pictureBox1.Image = img;
        }

        private void StartStopBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
    }
}
