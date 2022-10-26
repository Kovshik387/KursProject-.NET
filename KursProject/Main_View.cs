using System.Drawing.Imaging;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;

namespace KursProject
{
    public partial class Main_View : Form
    {
        public Graph graph;
        public List<Vertex> vertex_l;
        public List<EdgeN> edge_n;
        public List<string> cycle_matrix;
        public Algoritm alg;
        int flag = -1;
        bool Arrow = true;
        bool NewLocation = true;
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
                    FillListView();
                    Field.Image = graph.BitMap;
                    break;
                case 3:
                    if (NewLocation)
                    {
                        graph.ChangeColorVertex(vertex_l, edge_n, e.X - graph.Radius, e.Y - graph.Radius);
                        graph.Position = graph.SearchVertex(vertex_l, e.X - graph.Radius, e.Y - graph.Radius);
                        NewLocation = false;
                    }
                    else
                    {
                        if (graph.Position != -1) graph.DragVertex(vertex_l, graph.Position, e.X - graph.Radius, e.Y - graph.Radius);
                        graph.DrawGraph(vertex_l, edge_n);
                        NewLocation = true;
                    }
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
                            listView1.Items.Clear();
                            graph.SearchStringGraph(vertex_l, e.X - graph.Radius, e.Y - graph.Radius, edge_n);
                            FillListView();
                        }
                        Field.Image = graph.BitMap;
                        Arrow = true;
                        graph.DrawGraph(vertex_l, edge_n);
                        break;
                    }
                case 5:
                    graph.DrawGraph(vertex_l, edge_n);
                    Field.Image = graph.BitMap;
                    break;
                default:
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
        }

        private void Delete_vertex_Click(object sender, EventArgs e)
        {
            flag = 2;
            Draww.Enabled = true;
            delete_vertex.Enabled = false;
            view_vertex.Enabled = true;
            Chain.Enabled = true;
        }

        private void View_vertex_Click(object sender, EventArgs e)
        {
            flag = 3;
            Draww.Enabled = true;
            delete_vertex.Enabled = true;
            view_vertex.Enabled = false;
            Chain.Enabled = true;
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
        }

        private void Cycle_Click(object sender, EventArgs e)
        {
            ListBoxMatrix.Items.Clear();
            cycle_matrix.Clear();

            int[] color = new int[vertex_l.Count];
            for (int i = 0; i < vertex_l.Count; i++)
            {
                for (int j = 0; j < vertex_l.Count;j++)
                    color[j] = 1;
                List<int> cycle = new() {i + 1};
                alg.DFSKontur(i, i, edge_n, color, -1, cycle,cycle_matrix);
            }


            if (cycle_matrix.Count == 0) MessageBox.Show("В данном графе нет контура", "Состояние");

            for (int i = 0; i < cycle_matrix.Count; i++) ListBoxMatrix.Items.Add(cycle_matrix[i]);
           
        }

        private void ListBoxMatrix_Click_1(object sender, EventArgs e)
        {
            graph.ClearField();
            graph.DrawGraph(vertex_l, edge_n);

            try
            {
                
                if (ListBoxMatrix == null) { graph.DrawGraph(vertex_l, edge_n ); ListBoxMatrix!.ClearSelected(); return; } ;

                var temp = ListBoxMatrix.SelectedItem.ToString()!.Split("-");

                List<EdgeN> buffer = new();

                for (int i = 0; i < temp.Length - 1; i++)
                {
                    buffer.Add(new(int.Parse(temp[i].ToString()), int.Parse(temp[i + 1].ToString())));
                }
                graph.DrawCycle(vertex_l, buffer);

                Field.Image = graph.BitMap;
            }
            catch (Exception exc) { MessageBox.Show("Элемент не выбран\n" + exc.Message, "Ошибка"); }

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EdgeN ede = edge_n[int.Parse(listView1.FocusedItem.SubItems[0].Text) - 1];
            
            //graph.DrawLine(ede, vertex_l);
            Field.Image = graph.BitMap;
            graph.DrawGraph(vertex_l, edge_n, int.Parse(listView1.FocusedItem.SubItems[0].Text) - 1);
            ListBoxMatrix.Items.Clear();
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            graph.RemoveEdge(edge_n, int.Parse(listView1.FocusedItem.SubItems[0].Text) - 1);
            Console.WriteLine(int.Parse(listView1.FocusedItem.SubItems[0].Text));
            FillListView();
            graph.DrawGraph(vertex_l, edge_n);
            Field.Image = graph.BitMap;
        }

        private void FillListView()
        {
            listView1.Items.Clear();
            for (int i = 0; i < edge_n.Count; i++)
            {
                ListViewItem newItem = new((i + 1).ToString());

                int buff1 = edge_n[i].x + 1;
                int buff2 = edge_n[i].y + 1;

                string buff_str = $"{buff1}->{buff2}";
                ListViewItem.ListViewSubItem Path = new(newItem, buff_str);
                newItem.SubItems.Add(Path);
                listView1.Items.AddRange(new ListViewItem[] { newItem });
            }
        }

        private void Control_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (Control.SelectedIndex)
            {
                case 0:
                    Draww.Enabled = true;
                    delete_vertex.Enabled = true;
                    view_vertex.Enabled = true;
                    Chain.Enabled = true;
                    Arrow = true;
                    NewLocation = true;
                    break;
                case 1:
                    graph.DrawGraph(vertex_l, edge_n);
                    Arrow = true;
                    NewLocation = true;
                    flag = -1;
                    break;
                case 2:
                    graph.DrawGraph(vertex_l, edge_n);
                    Arrow = true;
                    NewLocation = true;
                    flag = -1;
                    break;
                default: break;
            }
        }

        private void SaveGraph_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            string path = saveFileDialog1.FileName;
            graph.BitMap!.Save(path,ImageFormat.Png);
        }

        private async void SaveSerial_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.Cancel) return;

            string path = saveFileDialog2.FileName;
            File.Delete(path); // На случай если мы будем перезаписывать файл

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ListSerializer listSerializer = new ListSerializer(vertex_l, edge_n);

                
                await JsonSerializer.SerializeAsync<ListSerializer>(fs,listSerializer);
                Console.WriteLine("Data has been saved to file");
            }

        }

        private async void OpenSerial_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            string path = openFileDialog1.FileName;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                ListSerializer? listSerializer = await JsonSerializer.DeserializeAsync<ListSerializer>(fs);
                vertex_l = listSerializer!.SerialVertex!;
                edge_n = listSerializer!.SerialEdge!;
                graph.DrawGraph(vertex_l, edge_n);
                FillListView();
                Field.Image = graph.BitMap;
            }
        }

        // Переосмысление: дискретная математика и линейная алгебра > мой хуй
    }

}