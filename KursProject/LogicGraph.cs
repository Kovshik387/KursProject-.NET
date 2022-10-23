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
    public class Vertex //Вершина
    {
        public int v_x;
        public int v_y;

        public Vertex(int v_x, int v_y)
        {
            this.v_x = v_x;
            this.v_y = v_y;
        }
    }

    public class EdgeN : ICloneable // переосмысление
    {
        public int x, y;

        public EdgeN(int x,int y)
        {
            this.x = x;
            this.y = y;
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
            //если u == endV, то эту вершину перекрашивать не нужно, иначе мы в нее не вернемся, а вернуться необходимо
            if (postition != endVert)
                color[postition] = 2;
            else
            {
                if (cycle.Count >= 2)
                {
                    cycle.Reverse();
                    string s = cycle[0].ToString();
                    for (int i = 1; i < cycle.Count; i++)
                        s += "-" + cycle[i].ToString();
                    bool flag = false; //есть ли палиндром для этого цикла графа в листбоксе?
                    for (int i = 0; i < cycle_matrix.Count; i++)
                        if (cycle_matrix[i].ToString() == s)
                        {
                            flag = true;
                            break;
                        }
                    if (!flag)
                    {
                        cycle.Reverse();
                        s = cycle[0].ToString();
                        for (int i = 1; i < cycle.Count; i++)
                            s += "-" + cycle[i].ToString();
                        cycle_matrix.Add(s);
                    }
                    return;
                }
            }

            for (int w = 0; w < E.Count; w++)
            {
                if (w == unavailableEdge) continue;

                if (color[E[w].y] == 1 && E[w].x == postition)
                {
                    List<int> cycleNEW = new(cycle);
                    cycleNEW.Add(E[w].y + 1);
                    DFSKontur(E[w].y, endVert, E, color, w, cycleNEW, cycle_matrix);
                    color[E[w].y] = 1;
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
                if (edge[i].x == edge[i].y) graphics.DrawArc(Configuration.SelectedPen,
                    vert[edge[i].x - 1].v_x - Radius, vert[edge[i].x - 1].v_y - Radius, 2 * Radius, 2 * Radius, 90, 270);
                else
                {
                    graphics.DrawLine(Configuration.SelectedPen, vert[edge[i].x - 1].v_x + Radius, vert[edge[i].x - 1].v_y + Radius,
                    vert[edge[i].y - 1].v_x + Radius, vert[edge[i].y - 1].v_y + Radius);
                    graphics.DrawLine(Configuration.SelectedMiddle, vert[edge[i].x - 1].v_x + Radius, vert[edge[i].x - 1].v_y + Radius,
                          (vert[edge[i].x - 1].v_x + Radius + vert[edge[i].y - 1].v_x + Radius) / 2, (vert[edge[i].x - 1].v_y + Radius + vert[edge[i].y - 1].v_y + Radius) / 2);
                }
            }

            graphics.FillEllipse(Configuration.StartCycle, vert[edge[0].x - 1].v_x, vert[edge[0].x - 1].v_y, Radius * 2, Radius * 2);
            graphics.DrawString((edge[0].x).ToString(), Configuration.font, Configuration.insidebrush, vert[edge[0].x - 1].v_x + 6, vert[edge[0].x - 1].v_y + 4);

            for (int i = 1; i < edge.Count; i++)
            {
                graphics.FillEllipse(Configuration.SelectedBrush, vert[edge[i].x - 1].v_x, vert[edge[i].x - 1].v_y, Radius * 2, Radius * 2);
                graphics.DrawString((edge[i].x).ToString(), Configuration.font, Configuration.insidebrush, vert[edge[i].x - 1].v_x + 6, vert[edge[i].x - 1].v_y + 4);

            }

        }

        public void DrawGraph(List<Vertex> vert, List<EdgeN> edge, int cursor)
        {

            ClearField();
            for (int i = 0; i < edge.Count; i++)
            {

                if (i == cursor)  if (edge[cursor].x == edge[cursor].y) graphics.DrawArc(Configuration.SelectedPen,
                vert[edge[cursor].x].v_x - Radius, vert[edge[cursor].x].v_y - Radius, 2 * Radius, 2 * Radius, 90, 270);
            else
            {
                graphics.DrawLine(Configuration.SelectedPen, vert[edge[cursor].x].v_x + Radius, vert[edge[cursor].x].v_y + Radius,
                vert[edge[cursor].y].v_x + Radius, vert[edge[cursor].y].v_y + Radius);
                graphics.DrawLine(Configuration.SelectedMiddle, vert[edge[cursor].x].v_x + Radius, vert[edge[cursor].x].v_y + Radius,
                      (vert[edge[cursor].x].v_x + Radius + vert[edge[cursor].y].v_x + Radius) / 2, (vert[edge[cursor].x].v_y + Radius + vert[edge[cursor].y].v_y + Radius) / 2);
                continue;
            }

                if (edge[i].x == edge[i].y) graphics.DrawArc(Configuration.EdgePen,
                    vert[edge[i].x].v_x - Radius, vert[edge[i].y].v_y - Radius, 2 * Radius, 2 * Radius, 90, 270);
                else
                {
                    graphics.DrawLine(Configuration.EdgePen, vert[edge[i].x].v_x + Radius, vert[edge[i].x].v_y + Radius,
                        vert[edge[i].y].v_x + Radius, vert[edge[i].y].v_y + Radius);
                    graphics.DrawLine(Configuration.MiddleEdgePen, vert[edge[i].x].v_x + Radius, vert[edge[i].x].v_y + Radius,
                          (vert[edge[i].x].v_x + Radius +  vert[edge[i].y].v_x + Radius) / 2, (vert[edge[i].x].v_y + Radius + vert[edge[i].y].v_y + Radius) / 2);
                }
            }

            for (int i = 0; i < vert.Count; i++)
            {
                graphics.FillEllipse(Configuration.brush, vert[i].v_x, vert[i].v_y, Radius * 2, Radius * 2);
                graphics.DrawString((i + 1).ToString(), Configuration.font, Configuration.insidebrush, vert[i].v_x + 6, vert[i].v_y + 4);
            }
        }

        public void DrawGraph(List<Vertex> vert, List<EdgeN> edge)
        {

            ClearField();
            for (int i = 0; i < edge.Count; i++)
            {
                if (edge[i].x == edge[i].y) graphics.DrawArc(Configuration.EdgePen,
                    vert[edge[i].x].v_x - Radius, vert[edge[i].y].v_y - Radius, 2 * Radius, 2 * Radius, 90, 270);
                else
                {
                    graphics.DrawLine(Configuration.EdgePen, vert[edge[i].x].v_x + Radius, vert[edge[i].x].v_y + Radius,
                        vert[edge[i].y].v_x + Radius, vert[edge[i].y].v_y + Radius);
                    graphics.DrawLine(Configuration.MiddleEdgePen, vert[edge[i].x].v_x + Radius, vert[edge[i].x].v_y + Radius,
                          (vert[edge[i].x].v_x + Radius + vert[edge[i].y].v_x + Radius) / 2, (vert[edge[i].x].v_y + Radius + vert[edge[i].y].v_y + Radius) / 2);
                }
            }

            for (int i = 0; i < vert.Count; i++)
            {
                graphics.FillEllipse(Configuration.brush, vert[i].v_x, vert[i].v_y, Radius * 2, Radius * 2);
                graphics.DrawString((i + 1).ToString(), Configuration.font, Configuration.insidebrush, vert[i].v_x + 6, vert[i].v_y + 4);
            }
        }

        public bool InTheRangeVertex(List<Vertex> vertex, int x, int y)
        {
            foreach (var item in vertex)
                if ((Math.Abs(x - item.v_x) <= Radius * 4) && (Math.Abs(y - item.v_y) <= Radius * 4)) return true;
            return false;
        }

        public int SearchVertex(List<Vertex> vertex, int x, int y)
        {
            for (int i = 0; i < vertex.Count; i++)
                if ((Math.Abs(x - vertex[i].v_x) <= Radius * 4) && (Math.Abs(y - vertex[i].v_y) <= Radius * 4)) return i;
            return -1;
        }

        public void DragVertex(List<Vertex> vertex,int cursor,int x, int y)
        {
            vertex[cursor].v_x = x;
            vertex[cursor].v_y = y;
        }

        public void DrawLine(EdgeN edge, List<Vertex> vert)
        {
            if (edge.x == edge.y) graphics.DrawArc(Configuration.SelectedPen,
                vert[edge.x].v_x - Radius, vert[edge.x].v_y - Radius, 2 * Radius, 2 * Radius, 90, 270);
            else
            {
                graphics.DrawLine(Configuration.SelectedPen, vert[edge.x].v_x + Radius, vert[edge.x].v_y + Radius,
                vert[edge.y].v_x + Radius, vert[edge.y].v_y + Radius);
                graphics.DrawLine(Configuration.SelectedMiddle, vert[edge.x].v_x + Radius, vert[edge.x].v_y + Radius,
                      (vert[edge.x].v_x + Radius + vert[edge.y].v_x + Radius) / 2, (vert[edge.x].v_y + Radius + vert[edge.y].v_y + Radius) / 2);
            }
        }
        public void RemoveEdge(List<Vertex> vertex, List<EdgeN> edge,int x, int y)
        {
            for (int i = 0; i < edge.Count;i++)
            {
                if (edge[i].x == edge[i].y) // Петля
                {
                    if ((Math.Pow((vertex[edge[i].x].v_x - Radius - x), 2) + (Math.Pow((vertex[edge[i].y].v_y - Radius - y), 2))) <= (Math.Pow(Radius + 4, 2))
                        &&
                       (Math.Pow((vertex[edge[i].x].v_x - Radius - x), 2) + (Math.Pow((vertex[edge[i].y].v_y - Radius - y), 2))) >= (Math.Pow(Radius - 4, 2)))
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
                if ((Math.Abs(x - vertex[i].v_x) <= Radius) && (Math.Abs(y - vertex[i].v_y) <= Radius))
                {
                    for (int j = 0; j < edge.Count;j++)
                    {
                        if (edge[j].x == i || edge[j].y == i)
                        {
                            edge.RemoveAt(j);
                            j--;
                        }
                        else
                        {
                            if (edge[j].x > i) edge[j].x--;
                            if (edge[j].y > i) edge[j].y--;
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
                if ((Math.Abs(x - vert[i].v_x) <= Radius) && (Math.Abs(y - vert[i].v_y) <= Radius))
                {
                    DrawGraph(vert, edge,-1);
                    graphics.FillEllipse(Configuration.SelectedBrush, vert[i].v_x, vert[i].v_y, Radius * 2, Radius * 2);
                    graphics.DrawString((i + 1).ToString(), Configuration.font, Configuration.brush, vert[i].v_x + 6, vert[i].v_y + 4);
                    StartVertex = vert[i];
                    Position = i;
                    counter = 1;
                    break;
                }
                else { DrawGraph(vert, edge,-1); StartVertex = null; counter = 0; }
            }
        }

        public void ClearField()
        {
            graphics.Clear(Color.White);
        }

        // Переосмысление


    }
}