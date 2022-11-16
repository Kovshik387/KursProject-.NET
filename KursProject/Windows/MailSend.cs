using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using KursProject.DeliverJson;
using KursProject.ServiceSerializer;
using TransferDataPackage.DataSerializations;

namespace KursProject
{
    public partial class MailSend : Form
    {
        List<Vertex> vertices;
        List<EdgeN> edgeNs;
        public MailSend(List<Vertex> vertices, List<EdgeN> edgeNs)
        {
            this.vertices = vertices;
            this.edgeNs = edgeNs;
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
            string path = (string)default!;
            message.To_Message = Mail.Text;
            
            if (NameF == null) path = "File.json";
            else path = NameF.Text + ".json";

            FileObjectSerializer fileObjectSerializer = new FileObjectSerializer();
            fileObjectSerializer.CreateJsonData(path, new ListSerializer(vertices, edgeNs));

            try { message.MessageSend(path); }
            catch { MessageBox.Show("Не удалость отправить файл", "Ошибка"); return; }
            File.Delete(path);
        }

        private void Back_ToMainView_Click(object sender, EventArgs e) => this.Close();
    }
}
