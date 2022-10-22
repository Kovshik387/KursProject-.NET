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
        public List<string> cycle_matrix;
        public Algoritm alg;
        int flag = -1;
        bool Arrow = true;
        public Main_View()
        {
            InitializeComponent();
            vertex_l = new List<Vertex>();
            edge_n = new List<EdgeN>();
            cycle_matrix = new List<string>();
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
                    graph.DrawGraph(vertex_l, edge_n);
                    Field.Image = graph.BitMap;
                    break;
                case 2:
                    graph.RemoveVertex(vertex_l,edge_n, e.X - graph.Radius, e.Y - graph.Radius);
                    graph.DrawGraph(vertex_l, edge_n);
                    Field.Image = graph.BitMap;
                    break;
                case 3:
                    graph.ChangeColorVertex(vertex_l, edge_n, e.X - graph.Radius, e.Y - graph.Radius);
                    Field.Image = graph.BitMap;
                    break;
                case 4:
                    if (Arrow) { 
                        graph.ChangeColorVertex(vertex_l, edge_n, e.X - graph.Radius, e.Y - graph.Radius); 
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
                        graph.DrawGraph(vertex_l, edge_n);
                        break;
                    }
                case 5:
                    graph.RemoveEdge(vertex_l, edge_n,e.X,e.Y);
                    graph.DrawGraph(vertex_l, edge_n);
                    Field.Image = graph.BitMap;
                    break;
            }
        }
        private void Draww_Click(object sender, EventArgs e)
        {
            flag = 1;
            Draww.Enabled = false;
            delete_vertex.Enabled = true;
            view_vertex.Enabled = true;
            Chain.Enabled = true;
            DeleteEdge.Enabled = true;
        }

        private void Delete_vertex_Click(object sender, EventArgs e)
        {
            flag = 2;
            Draww.Enabled = true;
            delete_vertex.Enabled = false;
            view_vertex.Enabled = true;
            Chain.Enabled = true;
            DeleteEdge.Enabled = true;
        }

        private void View_vertex_Click(object sender, EventArgs e)
        {
            flag = 3;
            Draww.Enabled = true;
            delete_vertex.Enabled = true;
            view_vertex.Enabled = false;
            Chain.Enabled = true;
            DeleteEdge.Enabled = true;
        }

        private void Chain_Click(object sender, EventArgs e)
        {
            graph.DrawGraph(vertex_l, edge_n);
            Field.Image = graph.BitMap;
            flag = 4;
            Draww.Enabled = true;
            delete_vertex.Enabled = true;
            view_vertex.Enabled = true;
            Chain.Enabled = false;
            DeleteEdge.Enabled = true;
        }
        private void DeleteEdge_Click(object sender, EventArgs e)
        {
            graph.DrawGraph(vertex_l, edge_n);
            Field.Image = graph.BitMap;
            flag = 5;
            Draww.Enabled = true;
            delete_vertex.Enabled = true;
            view_vertex.Enabled = true;
            Chain.Enabled = true;
            DeleteEdge.Enabled = false;
        }

        private void Cycle_Click(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Clear();
            cycle_matrix.Clear();

            int[] color = new int[vertex_l.Count];
            for (int i = 0; i < vertex_l.Count; i++)
            {
                for (int j = 0; j < vertex_l.Count;j++)
                    color[j] = 1;
                List<int> cycle = new() {i + 1};
                alg.DFScycle(i, i, edge_n, color, -1, cycle,cycle_matrix);
            }

            for (int i = 0; i < cycle_matrix.Count; i++) listBoxMatrix.Items.Add(cycle_matrix[i]);
        }

        private void ListBoxMatrix_Click(object sender, EventArgs e)
        {
            graph.ClearField();
            graph.DrawGraph(vertex_l, edge_n);

            try
            {
                //if (listBoxMatrix.Items.Count == 0) return;
                if (listBoxMatrix.SelectedItem == null) { graph.DrawGraph(vertex_l, edge_n); listBoxMatrix.ClearSelected(); return; } ;

                string temp = listBoxMatrix.SelectedItem.ToString()!.Replace("-","");

                List<EdgeN> buffer = new();

                var splito4ek = temp.Split("-");

                for (int i = 0; i < temp.Length - 1; i++)
                {
                    buffer.Add(new(int.Parse(temp[i].ToString()), int.Parse(temp[i + 1].ToString())));
                }
                graph.DrawCycle(vertex_l, buffer);

                Field.Image = graph.BitMap;
            }
            catch(Exception exc) { MessageBox.Show("Ёлемент не выбран\n" + exc.Message, "ќшибка"); }

        }

        // ѕереосмысление: дискретна€ математика и линейна€ алгебра > мой хуй
    }

}