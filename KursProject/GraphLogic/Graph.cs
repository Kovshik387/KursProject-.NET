using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject.GraphLogic
{
    public class Graph : GraphBase
    {
        public Graph(int Widht, int Height)
        {
            BitMap = new Bitmap(Widht, Height);
            graphics = Graphics.FromImage(BitMap);
        }

        public override void DrawCycle(List<Vertex> vert, List<EdgeN> edge)
        {
            ClearField();
            for (int i = 0; i < edge.Count; i++)
            {
                if (edge[i].IdStart == edge[i].IdEnd) graphics?.DrawArc(Configuration.SelectedPen,
                    vert[edge[i].IdStart - 1].X - Radius, vert[edge[i].IdStart - 1].Y - Radius, 2 * Radius, 2 * Radius, 90, 270);
                else
                {
                    graphics?.DrawLine(Configuration.SelectedPen, vert[edge[i].IdStart - 1].X + Radius, vert[edge[i].IdStart - 1].Y + Radius,
                    vert[edge[i].IdEnd - 1].X + Radius, vert[edge[i].IdEnd - 1].Y + Radius);
                    graphics?.DrawLine(Configuration.SelectedMiddle, vert[edge[i].IdStart - 1].X + Radius, vert[edge[i].IdStart - 1].Y + Radius,
                          (vert[edge[i].IdStart - 1].X + Radius + vert[edge[i].IdEnd - 1].X + Radius) / 2, (vert[edge[i].IdStart - 1].Y + Radius + vert[edge[i].IdEnd - 1].Y + Radius) / 2);
                }
            }

            graphics!.FillEllipse(Configuration.StartCycle, vert[edge[0].IdStart - 1].X, vert[edge[0].IdStart - 1].Y, Radius * 2, Radius * 2);
            graphics!.DrawString((edge[0].IdStart).ToString(), Configuration.font, Configuration.insidebrush, vert[edge[0].IdStart - 1].X + 6, vert[edge[0].IdStart - 1].Y + 4);

            for (int i = 1; i < edge.Count; i++)
            {
                graphics!.FillEllipse(Configuration.SelectedBrush, vert[edge[i].IdStart - 1].X, vert[edge[i].IdStart - 1].Y, Radius * 2, Radius * 2);
                graphics!.DrawString((edge[i].IdStart).ToString(), Configuration.font, Configuration.insidebrush, vert[edge[i].IdStart - 1].X + 6, vert[edge[i].IdStart - 1].Y + 4);

            }
        }

        public override void DrawGraph(List<Vertex> vert, List<EdgeN> edge, int cursor)
        {

            ClearField();
            for (int i = 0; i < edge.Count; i++)
            {
                if (i == cursor)
                    if (edge[cursor].IdStart == edge[cursor].IdEnd)
                    {
                        graphics!.DrawArc(Configuration.SelectedPen,
                            vert[edge[cursor].IdStart].X - Radius, vert[edge[cursor].IdStart].Y - Radius, 2 * Radius, 2 * Radius, 90, 270);
                        continue;
                    }
                    else
                    {
                        graphics!.DrawLine(Configuration.SelectedPen, vert[edge[cursor].IdStart].X + Radius, vert[edge[cursor].IdStart].Y + Radius,
                        vert[edge[cursor].IdEnd].X + Radius, vert[edge[cursor].IdEnd].Y + Radius);
                        graphics!.DrawLine(Configuration.SelectedMiddle, vert[edge[cursor].IdStart].X + Radius, vert[edge[cursor].IdStart].Y + Radius,
                        (vert[edge[cursor].IdStart].X + Radius + vert[edge[cursor].IdEnd].X + Radius) / 2, (vert[edge[cursor].IdStart].Y + Radius + vert[edge[cursor].IdEnd].Y + Radius) / 2);
                        continue;
                    }

                if (edge[i].IdStart == edge[i].IdEnd) graphics!.DrawArc(Configuration.EdgePen,
                    vert[edge[i].IdStart].X - Radius, vert[edge[i].IdEnd].Y - Radius, 2 * Radius, 2 * Radius, 90, 270);
                else
                {
                    graphics!.DrawLine(Configuration.EdgePen, vert[edge[i].IdStart].X + Radius, vert[edge[i].IdStart].Y + Radius,
                        vert[edge[i].IdEnd].X + Radius, vert[edge[i].IdEnd].Y + Radius);
                    graphics!.DrawLine(Configuration.MiddleEdgePen, vert[edge[i].IdStart].X + Radius, vert[edge[i].IdStart].Y + Radius,
                          (vert[edge[i].IdStart].X + Radius + vert[edge[i].IdEnd].X + Radius) / 2, (vert[edge[i].IdStart].Y + Radius + vert[edge[i].IdEnd].Y + Radius) / 2);
                }
            }

            for (int i = 0; i < vert.Count; i++)
            {
                graphics!.FillEllipse(Configuration.brush, vert[i].X, vert[i].Y, Radius * 2, Radius * 2);
                graphics!.DrawString((i + 1).ToString(), Configuration.font, Configuration.insidebrush, vert[i].X + 6, vert[i].Y + 4);
            }
        }
        public override void DrawGraph(List<Vertex> vert, List<EdgeN> edge)
        {

            ClearField();
            for (int i = 0; i < edge.Count; i++)
            {
                if (edge[i].IdStart == edge[i].IdEnd) graphics?.DrawArc(Configuration.EdgePen,
                    vert[edge[i].IdStart].X - Radius, vert[edge[i].IdEnd].Y - Radius, 2 * Radius, 2 * Radius, 90, 270);
                else
                {
                    graphics!.DrawLine(Configuration.EdgePen, vert[edge[i].IdStart].X + Radius, vert[edge[i].IdStart].Y + Radius,
                        vert[edge[i].IdEnd].X + Radius, vert[edge[i].IdEnd].Y + Radius);
                    graphics!.DrawLine(Configuration.MiddleEdgePen, vert[edge[i].IdStart].X + Radius, vert[edge[i].IdStart].Y + Radius,
                          (vert[edge[i].IdStart].X + Radius + vert[edge[i].IdEnd].X + Radius) / 2, (vert[edge[i].IdStart].Y + Radius + vert[edge[i].IdEnd].Y + Radius) / 2);
                }
            }

            for (int i = 0; i < vert.Count; i++)
            {
                graphics!.FillEllipse(Configuration.brush, vert[i].X, vert[i].Y, Radius * 2, Radius * 2);
                graphics!.DrawString((i + 1).ToString(), Configuration.font, Configuration.insidebrush, vert[i].X + 6, vert[i].Y + 4);
            }
        }

        public override bool InTheRangeVertex(List<Vertex> vertex, int x, int y)
        {
            foreach (var item in vertex)
                if ((Math.Abs(x - item.X) <= Radius * 4) && (Math.Abs(y - item.Y) <= Radius * 4)) return true;
            return false;
        }

        public override int SearchVertex(List<Vertex> vertex, int x, int y)
        {
            for (int i = 0; i < vertex.Count; i++)
                if ((Math.Abs(x - vertex[i].X) <= Radius * 4) && (Math.Abs(y - vertex[i].Y) <= Radius * 4)) return i;
            return -1;
        }

        public override void DragVertex(List<Vertex> vertex, int cursor, int x, int y)
        {
            vertex[cursor].X = x;
            vertex[cursor].Y = y;
        }

        public void DrawLine(EdgeN edge, List<Vertex> vert)
        {
            if (edge.IdStart == edge.IdEnd) graphics!.DrawArc(Configuration.SelectedPen,
                vert[edge.IdStart].X - Radius, vert[edge.IdStart].Y - Radius, 2 * Radius, 2 * Radius, 90, 270);
            else
            {
                graphics!.DrawLine(Configuration.SelectedPen, vert[edge.IdStart].X + Radius, vert[edge.IdStart].Y + Radius,
                vert[edge.IdEnd].X + Radius, vert[edge.IdEnd].Y + Radius);
                graphics.DrawLine(Configuration.SelectedMiddle, vert[edge.IdStart].X + Radius, vert[edge.IdStart].Y + Radius,
                      (vert[edge.IdStart].X + Radius + vert[edge.IdEnd].X + Radius) / 2, (vert[edge.IdStart].Y + Radius + vert[edge.IdEnd].Y + Radius) / 2);
            }
        }

        public override void RemoveEdge(List<EdgeN> edge, int cursor)
        {
            if (edge.Count == 0) edge.Clear();
            else edge.RemoveAt(cursor);
        }
        public override void RemoveVertex(List<Vertex> vertex, List<EdgeN> edge, int x, int y)
        {
            for (int i = 0; i < vertex.Count; i++)
            {
                if ((Math.Abs(x - vertex[i].X) <= Radius) && (Math.Abs(y - vertex[i].Y) <= Radius))
                {
                    for (int j = 0; j < edge.Count; j++)
                    {
                        if (edge[j].IdStart == i || edge[j].IdEnd == i)
                        {
                            edge.RemoveAt(j);
                            j--;
                        }
                        else
                        {
                            if (edge[j].IdStart > i) edge[j].IdStart--;
                            if (edge[j].IdEnd > i) edge[j].IdEnd--;
                        }
                    }
                    vertex.RemoveAt(i);
                    break;
                }
            }
        }
        public override void SearchStringGraph(List<Vertex> vert, int x, int y, List<EdgeN> ede)
        {
            int index = SearchVertex(vert, x, y);

            if (index != -1)
            {
                ede.Add(new(Position, index));

                counter = 0;
                StartVertex = null;
            }
        }
        public override void ChangeColorVertex(List<Vertex> vert, List<EdgeN> edge, int x, int y)
        {
            for (int i = 0; i < vert.Count; i++)
            {
                if ((Math.Abs(x - vert[i].X) <= Radius) && (Math.Abs(y - vert[i].Y) <= Radius))
                {
                    DrawGraph(vert, edge);
                    graphics!.FillEllipse(Configuration.SelectedBrush, vert[i].X, vert[i].Y, Radius * 2, Radius * 2);
                    graphics!.DrawString((i + 1).ToString(), Configuration.font, Configuration.brush, vert[i].X + 6, vert[i].Y + 4);
                    StartVertex = vert[i];
                    Position = i;
                    counter = 1;
                    break;
                }
                else { DrawGraph(vert, edge); StartVertex = null; counter = 0; }
            }
        }

        public override void ClearField()
        {
            graphics!.Clear(Color.White);
        }

    }
}
