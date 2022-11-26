using System;
using System.Drawing;
using Agario.Entities;

namespace Agario.Drawing
{
    static class Drawing
    {
        static public Color BackGroundColor = Color.White;
        static public void Clear(this Image img)
        {
            Graphics g = Graphics.FromImage(img);
            g.Clear(BackGroundColor);
        }
        public static void DrawEntity(this Image img, Entity entity)
        {
            Graphics graphics = Graphics.FromImage(img);
            graphics.FillCircle(entity.Texture.Brush, entity.Position, entity.Size, entity.Texture.ConturSize);
        }
        public static void Draw(this Image img, Game game)
        {
            img.Clear();
            foreach (Entity entity in game.Foods)
                img.DrawEntity(entity);
            foreach (Entity entity in game.Agars)
                img.DrawEntity(entity);
        }
        public static void FillCircle(this Graphics graphics, Brush brush, Point position, double size, int ConturSize = 0)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            double r = Math.Sqrt(size);
            Rectangle rectangle = new Rectangle((int)(position.X - r), (int)(position.Y - r), (int)(2 * r), (int)(2 * r));
            graphics.FillEllipse(brush, rectangle);
            Pen pen = new Pen(Color.Black, ConturSize);
            graphics.DrawEllipse(pen, rectangle);
        }
    }
}
