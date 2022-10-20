using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Windows.Forms.VisualStyles;

namespace KursProject
{
    public partial class Main_View : Form
    {
        Graph graph;
        public List<Vertex> vertex_l;
        public List<EdgeN> edge_n;
        int flag = -1;
        bool Arrow = true;
        Algoritm alg;
        public Main_View()
        {
            InitializeComponent();
            vertex_l = new List<Vertex>();
            edge_n = new List<EdgeN>();
            alg = new Algoritm();
            graph = new Graph(Field.Size.Width, Field.Size.Height);
            Field.Image = graph.BitMap;
        }

        private void Field_MouseClick(object sender, MouseEventArgs e)
        {
            switch (flag)
            { 
                case 1:
                    if (graph.InTheRangeVertex(vertex_l, e.X, e.Y)) return;
                    vertex_l.Add(new(e.X - graph.Radius , e.Y - graph.Radius));
                    graph.DrawGraph(vertex_l, edge_n, Configuration.eclipsePen);
                    Field.Image = graph.BitMap;
                    break;
                case 2:
                    graph.RemoveVertex(vertex_l,edge_n, e.X - graph.Radius, e.Y - graph.Radius);
                    graph.DrawGraph(vertex_l, edge_n, Configuration.eclipsePen);
                    Field.Image = graph.BitMap;
                    break;
                case 3:
                    graph.ChangeColorVertex(vertex_l, edge_n, Configuration.eclipsePen, e.X - graph.Radius, e.Y - graph.Radius);
                    Field.Image = graph.BitMap;
                    break;
                case 4:
                    if (Arrow) { 
                        graph.ChangeColorVertex(vertex_l, edge_n, Configuration.eclipsePen, e.X - graph.Radius, e.Y - graph.Radius); 
                        Arrow = false;
                        Field.Image = graph.BitMap; 
                        break; 
                    }
                    else
                    {
                        if (graph.counter == 1)
                        {
                            graph.SearchStringGraph(vertex_l, e.X - graph.Radius, e.Y - graph.Radius,edge_n);
                        }
                        Field.Image = graph.BitMap;
                        Arrow = true;
                        graph.DrawGraph(vertex_l, edge_n, Configuration.eclipsePen);
                        break;
                    }
            }
        }
        private void Draww_Click(object sender, EventArgs e)
        {
            flag = 1;
            Draww.Enabled = false;
            delete_vertex.Enabled = true;
            view_vertex.Enabled = true;
            Chain.Enabled = true;
        }

        private void delete_vertex_Click(object sender, EventArgs e)
        {
            flag = 2;
            Draww.Enabled = true;
            delete_vertex.Enabled = false;
            view_vertex.Enabled = true;
            Chain.Enabled = true;
        }

        private void view_vertex_Click(object sender, EventArgs e)
        {
            flag = 3;
            Draww.Enabled = true;
            delete_vertex.Enabled = true;
            view_vertex.Enabled = false;
            Chain.Enabled = true;
        }

        private void Chain_Click(object sender, EventArgs e)
        {
            graph.DrawGraph(vertex_l, edge_n, Configuration.eclipsePen);
            Field.Image = graph.BitMap;
            flag = 4;
            Draww.Enabled = true;
            delete_vertex.Enabled = true;
            view_vertex.Enabled = true;
            Chain.Enabled = false;
        }

        private void Cycle_Click(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Clear();
            int[] color = new int[vertex_l.Count];
            for (int i = 0; i < vertex_l.Count; i++)
            {
                for (int j = 0; j < vertex_l.Count;j++)
                {
                    color[j] = 1;
                    List<int> cycle = new List<int>();
                    cycle.Add(i + 1);
                    DFScycle(i, i, edge_n, color, -1, cycle);
                }
            }
            
            List<string> boom = new();

            for (int i = 0; i < listBoxMatrix.Items.Count; i++)
            {
                string? buffer = listBoxMatrix.Items[i].ToString();
                if (buffer[0] == buffer[buffer.Length - 1])
                    boom.Add(new string(buffer.Reverse().ToArray()));
            }

            boom = boom.Distinct().ToList();

            listBoxMatrix.Items.Clear();

            for (int i = 0; i < boom.Count; i++)
            {
                listBoxMatrix.Items.Add(boom[i]);
            }

        }

        public void DFScycle(int u, int endV, List<EdgeN> E, int[] color, int unavailableEdge, List<int> cycle)
        {
            //если u == endV, то эту вершину перекрашивать не нужно, иначе мы в нее не вернемс€, а вернутьс€ необходимо
            if (u != endV)
                color[u] = 2;
            else
            {
                if (cycle.Count >= 2)
                {
                    cycle.Reverse();
                    string s = cycle[0].ToString();
                    for (int i = 1; i < cycle.Count; i++)
                        s += "-" + cycle[i].ToString();
                    bool flag = false; //есть ли палиндром дл€ этого цикла графа в листбоксе?
                    for (int i = 0; i < listBoxMatrix.Items.Count; i++)
                        if (listBoxMatrix.Items[i].ToString() == s)
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
                        listBoxMatrix.Items.Add(s);
                    }
                    return;
                }
            }
            for (int w = 0; w < E.Count; w++)
            {
                if (w == unavailableEdge)
                    continue;
                if (color[E[w].y] == 1 && E[w].x == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].y + 1);
                    DFScycle(E[w].x, endV, E, color, w, cycleNEW);
                    color[E[w].y] = 1;
                }
                else if (color[E[w].x] == 1 && E[w].y == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].x + 1);
                    DFScycle(E[w].x, endV, E, color, w, cycleNEW);
                    color[E[w].x] = 1;
                }
            }
        }


        private void listBoxMatrix_Click(object sender, EventArgs e)
        {
            graph.ClearField();
            graph.DrawGraph(vertex_l, edge_n, Configuration.eclipsePen);

            try
            {
                if (listBoxMatrix.Items.Count == 0) return;

                string? temp = listBoxMatrix.SelectedItem.ToString();

                temp = temp.Replace("-", "");
                temp = temp.Replace(" ", "");

                List<EdgeN> buffer = new();

                for (int i = 0; i < temp.Length - 1; i++)
                {
                    int buff_1 = int.Parse(temp[i].ToString());
                    int buff_2 = int.Parse(temp[i + 1].ToString());
                    buffer.Add(new(buff_1, buff_2));
                    Console.WriteLine(temp[i]);
                    Console.WriteLine(temp[i + 1]);
                }
                Console.WriteLine();
                //graph.DrawGraph(vertex_l, edge_n,Configuration.eclipsePen);
                graph.DrawCycle(vertex_l, buffer);

                Field.Image = graph.BitMap;
            }
            catch(Exception exc) { MessageBox.Show("Ёлемент не выбран" + exc.Message, "ќшибка"); }

        }
    }
}