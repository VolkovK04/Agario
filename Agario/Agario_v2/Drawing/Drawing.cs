using System.Drawing;

namespace Agario_v2
{
    static class Drawing
    {
        static public void Clear(this Image img)
        {
            Graphics g = Graphics.FromImage(img);
            g.Clear(Color.White);
        }
        public static void DrawAgar(this Image img, Agar agar)
        {
            Graphics graphics = Graphics.FromImage(img);
            Brush brush = new SolidBrush(agar.Color);
            graphics.FillCircle(brush, agar.Position, agar.Size);
        }
        public static void DrawFood(this Image img, Food food)
        {
            Graphics graphics = Graphics.FromImage(img);
            Brush brush = new SolidBrush(food.Color);
            graphics.FillCircle(brush, food.Position, food.Size, 3);
        }
        static public void Draw(this Image img, Game game)
        {
            img.Clear();
            foreach (Food food in game.Foods)
                img.DrawFood(food);
            foreach (Agar agar in game.Agars)
                img.DrawAgar(agar);
        }

        static public void FillCircle(this Graphics graphics, Brush brush, Point position, double size, int ConturSize = 0)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            double r = size / 2;
            Rectangle rectangle = new Rectangle((int)(position.X - r), (int)(position.Y - r), (int)(2 * r), (int)(2 * r));
            graphics.FillEllipse(brush, rectangle);
            Pen pen = new Pen(Color.Black, ConturSize);
            graphics.DrawEllipse(pen, rectangle);
        }

    }
}
