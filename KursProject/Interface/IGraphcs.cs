using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject.Interface
{
    interface IGraphcs
    {
        public int Radius { get; }
        public Bitmap? BitMap { get; set; }
        public int Position { get; set; }
        public abstract void DrawGraph(List<Vertex> vert, List<EdgeN> edge);
        public abstract bool InTheRangeVertex(List<Vertex> vertex, int x, int y);
        public abstract int SearchVertex(List<Vertex> vertex, int x, int y);
        public abstract void DragVertex(List<Vertex> vertex, int cursor, int x, int y);
        public abstract void ChangeColorVertex(List<Vertex> vert, List<EdgeN> edge, int x, int y);
        public abstract void RemoveEdge(List<EdgeN> edge, int cursor);
        public abstract void RemoveVertex(List<Vertex> vertex, List<EdgeN> edge, int x, int y);
        public abstract void SearchStringGraph(List<Vertex> vert, int x, int y, List<EdgeN> ede);
    }
}
