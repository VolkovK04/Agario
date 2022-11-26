using System.Drawing;

namespace Agario
{
    struct Texture
    {
        public Texture(Color color, int conturSize = 0)
        {
            Brush = new SolidBrush(color);
            ConturSize = conturSize;
        }
        public Brush Brush { get; set; }
        public int ConturSize { get; set; }
    }
}
