using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using KursProject.DeliverJson;

namespace KursProject
{
    public partial class MailSend : Form
    {
        List<Vertex> vertices;
        List<EdgeN> edgeNs;
        public MailSend(List<Vertex> v, List<EdgeN> e)
        {
            this.edgeNs = e;
            this.vertices = v;
            InitializeComponent();
        }

        private void SendM_Click(object sender, EventArgs e)
        {
            NetMessage message = new NetMessage();

            string cond = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            string email = Mail.Text;

            if (!Regex.IsMatch(email,cond))
            {
                Correct.Text = "Неверно указан адрес\nэлектронной почты";
                Correct.ForeColor = Color.Red;
                return;
            }
            Correct.ForeColor = Color.Black;
            Correct.Text = "";
            string path = "";
            
            if (NameF == null) path = "..\\..\\..\\temp\\temp.json";
            else path = "..\\..\\..\\temp\\" + NameF.Text + ".json";

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ListSerializer listSerializer = new ListSerializer(vertices, edgeNs);
                JsonSerializer.Serialize<ListSerializer>(fs, listSerializer);
                Console.WriteLine("Data has been saved to file");
            }

            message.To_Message = Mail.Text;

            try { message.MessageSend(path); }
            catch { MessageBox.Show("Не удалость отправить файл", "Ошибка"); return; }
            FileInfo file = new(path);
            file.Delete();

        }

        private void Back_ToMainView_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
