using KursProject;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace KursProject
{
    [Serializable]
    public class Vertex //Вершина
    {
        public int x { get; set; }
        public int y { get; set; }

        public Vertex() { }

        public Vertex(int v_x, int v_y)
        {
            this.x = v_x;
            this.y = v_y;
        }
    }

    [Serializable]
    public class EdgeN : ICloneable // переосмысление
    {   // ребро
        public int IdStart { get; set; }
        public int IdEnd { get; set; }

        public EdgeN(int x,int y)
        {
            this.IdStart = x;
            this.IdEnd = y;
        }
        public object Clone() => MemberwiseClone();

    }

    public class Configuration
    {

        public static Pen SelectedPen = new(Color.SkyBlue)
        {
            Width = 5,
            EndCap = LineCap.ArrowAnchor,
        };

        public static Pen SelectedMiddle = new(Color.SkyBlue)
        {
            Width = 5,
            CustomEndCap = new AdjustableArrowCap(3, 4),
        };

        public static Pen selectedPen = new(Color.Black)
        {
            Width = 3,
        };

        public static Pen EdgePen = new(Color.DarkGray)
        {
            Width = 5,
            EndCap = LineCap.ArrowAnchor,
        };

        public static Pen MiddleEdgePen = new(Color.DarkGray)
        {
            Width = 6,
            //EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor,
            CustomEndCap = new AdjustableArrowCap(3, 4),
        };

        public static Font font = new Font("Times New Roman", 15);
        public static Brush brush = Brushes.Black;
        public static Brush insidebrush = Brushes.White;
        public static Brush SelectedBrush = Brushes.SkyBlue;
        public static Brush StartCycle = Brushes.RoyalBlue;
    }

    public class Algoritm
    {
        public void DFSKontur(int postition, int endVert, List<EdgeN> E, int[] color, int unavailableEdge, List<int> cycle, List<string> cycle_matrix)
        {
            if (postition != endVert)       // если значения равны, то мы не должны присваивать ей цвет, иначе мы не вернёмся в неё
                color[postition] = 2;       // любое значение отличное от "белого" и "чёрного"
            else
            {
                if (cycle.Count >= 2)
                {
                    string s = cycle[0].ToString();
                    for (int i = 1; i < cycle.Count; i++)
                        s += "-" + cycle[i].ToString();
                    cycle_matrix.Add(s);
                    return;
                } 
            }

            for (int i = 0; i < E.Count; i++)
            {
                if (i == unavailableEdge) continue;

                if (color[E[i].IdEnd] == 1 && E[i].IdStart == postition)
                {
                    List<int> cycleNEW = new(cycle);
                    cycleNEW.Add(E[i].IdEnd + 1);
                    DFSKontur(E[i].IdEnd, endVert, E, color, i, cycleNEW, cycle_matrix);
                    color[E[i].IdEnd] = 1;
                }
            }

        }
    }

    public class Graph
    {
        public Graphics graphics;
        public int Radius { get; private set; } = 15;
        public Bitmap? BitMap { get; set; }

        public Vertex? StartVertex = new(0, 0);

        public int Position { get; set; } = 0;
        public Graph(int Widht, int Height)
        {
            BitMap = new Bitmap(Widht, Height);
            graphics = Graphics.FromImage(BitMap);
        }

        public int counter = 0;
        public void DrawCycle(List<Vertex> vert, List<EdgeN> edge)
        {
            ClearField();
            for (int i = 0; i < edge.Count; i++)
            {
                if (edge[i].IdStart == edge[i].IdEnd) graphics.DrawArc(Configuration.SelectedPen,
                    vert[edge[i].IdStart - 1].x - Radius, vert[edge[i].IdStart - 1].y - Radius, 2 * Radius, 2 * Radius, 90, 270);
                else
                {
                    graphics.DrawLine(Configuration.SelectedPen, vert[edge[i].IdStart - 1].x + Radius, vert[edge[i].IdStart - 1].y + Radius,
                    vert[edge[i].IdEnd - 1].x + Radius, vert[edge[i].IdEnd - 1].y + Radius);
                    graphics.DrawLine(Configuration.SelectedMiddle, vert[edge[i].IdStart - 1].x + Radius, vert[edge[i].IdStart - 1].y + Radius,
                          (vert[edge[i].IdStart - 1].x + Radius + vert[edge[i].IdEnd - 1].x + Radius) / 2, (vert[edge[i].IdStart - 1].y + Radius + vert[edge[i].IdEnd - 1].y + Radius) / 2);
                }
            }

            graphics.FillEllipse(Configuration.StartCycle, vert[edge[0].IdStart - 1].x, vert[edge[0].IdStart - 1].y, Radius * 2, Radius * 2);
            graphics.DrawString((edge[0].IdStart).ToString(), Configuration.font, Configuration.insidebrush, vert[edge[0].IdStart - 1].x + 6, vert[edge[0].IdStart - 1].y + 4);

            for (int i = 1; i < edge.Count; i++)
            {
                graphics.FillEllipse(Configuration.SelectedBrush, vert[edge[i].IdStart - 1].x, vert[edge[i].IdStart - 1].y, Radius * 2, Radius * 2);
                graphics.DrawString((edge[i].IdStart).ToString(), Configuration.font, Configuration.insidebrush, vert[edge[i].IdStart - 1].x + 6, vert[edge[i].IdStart - 1].y + 4);

            }

        }

        public void DrawGraph(List<Vertex> vert, List<EdgeN> edge, int cursor)
        {

            ClearField();
            for (int i = 0; i < edge.Count; i++)
            {

                if (i == cursor)
                    if (edge[cursor].IdStart == edge[cursor].IdEnd){
                        graphics.DrawArc(Configuration.SelectedPen,
                            vert[edge[cursor].IdStart].x - Radius, vert[edge[cursor].IdStart].y - Radius, 2 * Radius, 2 * Radius, 90, 270);
                        continue;
                    }
                    else
                    {
                        graphics.DrawLine(Configuration.SelectedPen, vert[edge[cursor].IdStart].x + Radius, vert[edge[cursor].IdStart].y + Radius,
                        vert[edge[cursor].IdEnd].x + Radius, vert[edge[cursor].IdEnd].y + Radius);
                        graphics.DrawLine(Configuration.SelectedMiddle, vert[edge[cursor].IdStart].x + Radius, vert[edge[cursor].IdStart].y + Radius,
                        (vert[edge[cursor].IdStart].x + Radius + vert[edge[cursor].IdEnd].x + Radius) / 2, (vert[edge[cursor].IdStart].y + Radius + vert[edge[cursor].IdEnd].y + Radius) / 2);
                        continue;
                    }           

                if (edge[i].IdStart == edge[i].IdEnd) graphics.DrawArc(Configuration.EdgePen,
                    vert[edge[i].IdStart].x - Radius, vert[edge[i].IdEnd].y - Radius, 2 * Radius, 2 * Radius, 90, 270);
                else
                {
                    graphics.DrawLine(Configuration.EdgePen, vert[edge[i].IdStart].x + Radius, vert[edge[i].IdStart].y + Radius,
                        vert[edge[i].IdEnd].x + Radius, vert[edge[i].IdEnd].y + Radius);
                    graphics.DrawLine(Configuration.MiddleEdgePen, vert[edge[i].IdStart].x + Radius, vert[edge[i].IdStart].y + Radius,
                          (vert[edge[i].IdStart].x + Radius +  vert[edge[i].IdEnd].x + Radius) / 2, (vert[edge[i].IdStart].y + Radius + vert[edge[i].IdEnd].y + Radius) / 2);
                }
            }

            for (int i = 0; i < vert.Count; i++)
            {
                graphics.FillEllipse(Configuration.brush, vert[i].x, vert[i].y, Radius * 2, Radius * 2);
                graphics.DrawString((i + 1).ToString(), Configuration.font, Configuration.insidebrush, vert[i].x + 6, vert[i].y + 4);
            }
        }

        public void DrawGraph(List<Vertex> vert, List<EdgeN> edge)
        {

            ClearField();
            for (int i = 0; i < edge.Count; i++)
            {
                if (edge[i].IdStart == edge[i].IdEnd) graphics.DrawArc(Configuration.EdgePen,
                    vert[edge[i].IdStart].x - Radius, vert[edge[i].IdEnd].y - Radius, 2 * Radius, 2 * Radius, 90, 270);
                else
                {
                    graphics.DrawLine(Configuration.EdgePen, vert[edge[i].IdStart].x + Radius, vert[edge[i].IdStart].y + Radius,
                        vert[edge[i].IdEnd].x + Radius, vert[edge[i].IdEnd].y + Radius);
                    graphics.DrawLine(Configuration.MiddleEdgePen, vert[edge[i].IdStart].x + Radius, vert[edge[i].IdStart].y + Radius,
                          (vert[edge[i].IdStart].x + Radius + vert[edge[i].IdEnd].x + Radius) / 2, (vert[edge[i].IdStart].y + Radius + vert[edge[i].IdEnd].y + Radius) / 2);
                }
            }

            for (int i = 0; i < vert.Count; i++)
            {
                graphics.FillEllipse(Configuration.brush, vert[i].x, vert[i].y, Radius * 2, Radius * 2);
                graphics.DrawString((i + 1).ToString(), Configuration.font, Configuration.insidebrush, vert[i].x + 6, vert[i].y + 4);
            }
        }

        public bool InTheRangeVertex(List<Vertex> vertex, int x, int y)
        {
            foreach (var item in vertex)
                if ((Math.Abs(x - item.x) <= Radius * 4) && (Math.Abs(y - item.y) <= Radius * 4)) return true;
            return false;
        }

        public int SearchVertex(List<Vertex> vertex, int x, int y)
        {
            for (int i = 0; i < vertex.Count; i++)
                if ((Math.Abs(x - vertex[i].x) <= Radius * 4) && (Math.Abs(y - vertex[i].y) <= Radius * 4)) return i;
            return -1;
        }

        public void DragVertex(List<Vertex> vertex,int cursor,int x, int y)
        {
            vertex[cursor].x = x;
            vertex[cursor].y = y;
        }

        public void DrawLine(EdgeN edge, List<Vertex> vert)
        {
            if (edge.IdStart == edge.IdEnd) graphics.DrawArc(Configuration.SelectedPen,
                vert[edge.IdStart].x - Radius, vert[edge.IdStart].y - Radius, 2 * Radius, 2 * Radius, 90, 270);
            else
            {
                graphics.DrawLine(Configuration.SelectedPen, vert[edge.IdStart].x + Radius, vert[edge.IdStart].y + Radius,
                vert[edge.IdEnd].x + Radius, vert[edge.IdEnd].y + Radius);
                graphics.DrawLine(Configuration.SelectedMiddle, vert[edge.IdStart].x + Radius, vert[edge.IdStart].y + Radius,
                      (vert[edge.IdStart].x + Radius + vert[edge.IdEnd].x + Radius) / 2, (vert[edge.IdStart].y + Radius + vert[edge.IdEnd].y + Radius) / 2);
            }
        }
        public void RemoveEdge(List<Vertex> vertex, List<EdgeN> edge,int x, int y)
        {
            for (int i = 0; i < edge.Count;i++)
            {
                if (edge[i].IdStart == edge[i].IdEnd) // Петля
                {
                    if ((Math.Pow((vertex[edge[i].IdStart].x - Radius - x), 2) + (Math.Pow((vertex[edge[i].IdEnd].y - Radius - y), 2))) <= (Math.Pow(Radius + 4, 2))
                        &&
                       (Math.Pow((vertex[edge[i].IdStart].x - Radius - x), 2) + (Math.Pow((vertex[edge[i].IdEnd].y - Radius - y), 2))) >= (Math.Pow(Radius - 4, 2)))
                        edge.RemoveAt(i);
                }
            }
        }

        public void RemoveEdge(List<EdgeN> edge, int cursor)
        {
            if (edge.Count == 0) edge.Clear();
            else edge.RemoveAt(cursor);
        }
        public void RemoveVertex(List<Vertex> vertex, List<EdgeN> edge, int x, int y)
        {
            for (int i = 0; i < vertex.Count; i++)
            {
                if ((Math.Abs(x - vertex[i].x) <= Radius) && (Math.Abs(y - vertex[i].y) <= Radius))
                {
                    for (int j = 0; j < edge.Count;j++)
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
        public void SearchStringGraph(List<Vertex> vert, int x, int y,List<EdgeN> ede)
        {
            int index = SearchVertex(vert, x, y);

            if (index != -1)
            {
                ede.Add(new(Position,index));
                
                counter = 0;
                StartVertex = null;
            }
        }
        public void ChangeColorVertex(List<Vertex> vert, List<EdgeN> edge, int x, int y)
        {
            for (int i = 0; i < vert.Count; i++)
            {
                if ((Math.Abs(x - vert[i].x) <= Radius) && (Math.Abs(y - vert[i].y) <= Radius))
                {
                    DrawGraph(vert, edge);
                    graphics.FillEllipse(Configuration.SelectedBrush, vert[i].x, vert[i].y, Radius * 2, Radius * 2);
                    graphics.DrawString((i + 1).ToString(), Configuration.font, Configuration.brush, vert[i].x + 6, vert[i].y + 4);
                    StartVertex = vert[i];
                    Position = i;
                    counter = 1;
                    break;
                }
                else { DrawGraph(vert, edge); StartVertex = null; counter = 0; }
            }
        }

        public void ClearField()
        {
            graphics.Clear(Color.White);
        }

        // Переосмысление


    }
}