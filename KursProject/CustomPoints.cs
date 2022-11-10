using System.Drawing.Drawing2D;
using System.Windows.Forms.VisualStyles;

namespace KursProject
{
    [Serializable]
    public class Vertex //Вершина
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vertex() { }

        public Vertex(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    [Serializable]
    public class EdgeN
    {   // ребро
        public int IdStart { get; set; }
        public int IdEnd { get; set; }

        public EdgeN(int IdStart, int IdEnd)
        {
            this.IdStart = IdStart;
            this.IdEnd = IdEnd;
        }
    }
}