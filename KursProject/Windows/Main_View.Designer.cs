namespace KursProject
{
    partial class Main_View
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Field = new System.Windows.Forms.PictureBox();
            this.Draww = new System.Windows.Forms.Button();
            this.delete_vertex = new System.Windows.Forms.Button();
            this.view_vertex = new System.Windows.Forms.Button();
            this.Chain = new System.Windows.Forms.Button();
            this.Cycle = new System.Windows.Forms.Button();
            this.Control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Send_JSON = new System.Windows.Forms.Button();
            this.OpenSerial = new System.Windows.Forms.Button();
            this.SaveSerial = new System.Windows.Forms.Button();
            this.SaveGraph = new System.Windows.Forms.Button();
            this.Delete_Edge = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ListBoxMatrix = new System.Windows.Forms.ListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            this.Control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Delete_Edge.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Field
            // 
            this.Field.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Field.Location = new System.Drawing.Point(12, 12);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(608, 502);
            this.Field.TabIndex = 0;
            this.Field.TabStop = false;
            this.Field.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Field_MouseClick);
            // 
            // Draww
            // 
            this.Draww.Location = new System.Drawing.Point(6, 6);
            this.Draww.Name = "Draww";
            this.Draww.Size = new System.Drawing.Size(165, 25);
            this.Draww.TabIndex = 1;
            this.Draww.Text = "Добавление Вершины";
            this.Draww.UseVisualStyleBackColor = true;
            this.Draww.Click += new System.EventHandler(this.Draww_Click);
            // 
            // delete_vertex
            // 
            this.delete_vertex.Location = new System.Drawing.Point(6, 37);
            this.delete_vertex.Name = "delete_vertex";
            this.delete_vertex.Size = new System.Drawing.Size(165, 25);
            this.delete_vertex.TabIndex = 2;
            this.delete_vertex.Text = "Удаление Вершины";
            this.delete_vertex.UseVisualStyleBackColor = true;
            this.delete_vertex.Click += new System.EventHandler(this.Delete_vertex_Click);
            // 
            // view_vertex
            // 
            this.view_vertex.Location = new System.Drawing.Point(6, 99);
            this.view_vertex.Name = "view_vertex";
            this.view_vertex.Size = new System.Drawing.Size(165, 25);
            this.view_vertex.TabIndex = 3;
            this.view_vertex.Text = "Перемещение Вершин";
            this.view_vertex.UseVisualStyleBackColor = true;
            this.view_vertex.Click += new System.EventHandler(this.View_vertex_Click);
            // 
            // Chain
            // 
            this.Chain.Location = new System.Drawing.Point(6, 68);
            this.Chain.Name = "Chain";
            this.Chain.Size = new System.Drawing.Size(165, 25);
            this.Chain.TabIndex = 4;
            this.Chain.Text = "Соединить Вершины";
            this.Chain.UseVisualStyleBackColor = true;
            this.Chain.Click += new System.EventHandler(this.Chain_Click);
            // 
            // Cycle
            // 
            this.Cycle.Location = new System.Drawing.Point(6, 6);
            this.Cycle.Name = "Cycle";
            this.Cycle.Size = new System.Drawing.Size(248, 36);
            this.Cycle.TabIndex = 7;
            this.Cycle.Text = "Поиск контуров";
            this.Cycle.UseVisualStyleBackColor = true;
            this.Cycle.Click += new System.EventHandler(this.Cycle_Click);
            // 
            // Control
            // 
            this.Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Control.Controls.Add(this.tabPage1);
            this.Control.Controls.Add(this.Delete_Edge);
            this.Control.Controls.Add(this.tabPage2);
            this.Control.Location = new System.Drawing.Point(626, 12);
            this.Control.Name = "Control";
            this.Control.SelectedIndex = 0;
            this.Control.Size = new System.Drawing.Size(268, 502);
            this.Control.TabIndex = 10;
            this.Control.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.Control_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Send_JSON);
            this.tabPage1.Controls.Add(this.OpenSerial);
            this.tabPage1.Controls.Add(this.SaveSerial);
            this.tabPage1.Controls.Add(this.SaveGraph);
            this.tabPage1.Controls.Add(this.Draww);
            this.tabPage1.Controls.Add(this.view_vertex);
            this.tabPage1.Controls.Add(this.Chain);
            this.tabPage1.Controls.Add(this.delete_vertex);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(260, 474);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Элементы управления";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Send_JSON
            // 
            this.Send_JSON.Location = new System.Drawing.Point(6, 416);
            this.Send_JSON.Name = "Send_JSON";
            this.Send_JSON.Size = new System.Drawing.Size(248, 23);
            this.Send_JSON.TabIndex = 8;
            this.Send_JSON.Text = "Отправить граф json";
            this.Send_JSON.UseVisualStyleBackColor = true;
            this.Send_JSON.Click += new System.EventHandler(this.Send_JSON_Click);
            // 
            // OpenSerial
            // 
            this.OpenSerial.Location = new System.Drawing.Point(6, 445);
            this.OpenSerial.Name = "OpenSerial";
            this.OpenSerial.Size = new System.Drawing.Size(248, 23);
            this.OpenSerial.TabIndex = 7;
            this.OpenSerial.Text = "Открыть граф";
            this.OpenSerial.UseVisualStyleBackColor = true;
            this.OpenSerial.Click += new System.EventHandler(this.OpenSerial_Click);
            // 
            // SaveSerial
            // 
            this.SaveSerial.Location = new System.Drawing.Point(6, 387);
            this.SaveSerial.Name = "SaveSerial";
            this.SaveSerial.Size = new System.Drawing.Size(248, 23);
            this.SaveSerial.TabIndex = 6;
            this.SaveSerial.Text = "Сохранить граф json";
            this.SaveSerial.UseVisualStyleBackColor = true;
            this.SaveSerial.Click += new System.EventHandler(this.SaveSerial_Click);
            // 
            // SaveGraph
            // 
            this.SaveGraph.Location = new System.Drawing.Point(6, 358);
            this.SaveGraph.Name = "SaveGraph";
            this.SaveGraph.Size = new System.Drawing.Size(248, 23);
            this.SaveGraph.TabIndex = 5;
            this.SaveGraph.Text = "Сохранить Граф png";
            this.SaveGraph.UseVisualStyleBackColor = true;
            this.SaveGraph.Click += new System.EventHandler(this.SaveGraph_Click);
            // 
            // Delete_Edge
            // 
            this.Delete_Edge.Controls.Add(this.label1);
            this.Delete_Edge.Controls.Add(this.listView1);
            this.Delete_Edge.Location = new System.Drawing.Point(4, 24);
            this.Delete_Edge.Name = "Delete_Edge";
            this.Delete_Edge.Padding = new System.Windows.Forms.Padding(3);
            this.Delete_Edge.Size = new System.Drawing.Size(260, 474);
            this.Delete_Edge.TabIndex = 0;
            this.Delete_Edge.Text = "Ребра";
            this.Delete_Edge.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Для удаления ребра, необходимо \r\nпроизвести двойное нажатие по элементу";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(251, 431);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.ListView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Путь";
            this.columnHeader2.Width = 100;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ListBoxMatrix);
            this.tabPage2.Controls.Add(this.Cycle);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(260, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Контур";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ListBoxMatrix
            // 
            this.ListBoxMatrix.FormattingEnabled = true;
            this.ListBoxMatrix.ItemHeight = 15;
            this.ListBoxMatrix.Location = new System.Drawing.Point(6, 48);
            this.ListBoxMatrix.Name = "ListBoxMatrix";
            this.ListBoxMatrix.Size = new System.Drawing.Size(248, 424);
            this.ListBoxMatrix.TabIndex = 8;
            this.ListBoxMatrix.Click += new System.EventHandler(this.ListBoxMatrix_Click_1);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.Filter = "\"PNG (*.png)|*.png|Все файлы (*.*)|";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.DefaultExt = "json";
            this.saveFileDialog2.Filter = "\"Json\" (*.json)|*.json|Все файлы (*.*)|";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"Json (*.json)|*.json|Все файлы (*.*)|";
            // 
            // Main_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 540);
            this.Controls.Add(this.Control);
            this.Controls.Add(this.Field);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(922, 579);
            this.MinimumSize = new System.Drawing.Size(922, 579);
            this.Name = "Main_View";
            this.Text = "Fantokin option five";
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            this.Control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Delete_Edge.ResumeLayout(false);
            this.Delete_Edge.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox Field;
        private Button Draww;
        private Button delete_vertex;
        private Button view_vertex;
        private Button Chain;
        private Button Cycle;
        private TabControl Control;
        private TabPage Delete_Edge;
        private TabPage tabPage2;
        private ListView listView1;
        private ListBox ListBoxMatrix;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label label1;
        private TabPage tabPage1;
        private Button SaveGraph;
        private SaveFileDialog saveFileDialog1;
        private Button SaveSerial;
        private SaveFileDialog saveFileDialog2;
        private Button OpenSerial;
        private OpenFileDialog openFileDialog1;
        private Button Send_JSON;
    }
}