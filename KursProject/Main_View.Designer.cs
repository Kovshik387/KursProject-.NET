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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Delete_Edge = new System.Windows.Forms.TabPage();
            this.DeleteEdge = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ListBoxMatrix = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            this.tabControl1.SuspendLayout();
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
            this.Field.Location = new System.Drawing.Point(12, 43);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(608, 471);
            this.Field.TabIndex = 0;
            this.Field.TabStop = false;
            this.Field.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Field_MouseClick);
            // 
            // Draww
            // 
            this.Draww.Location = new System.Drawing.Point(12, 12);
            this.Draww.Name = "Draww";
            this.Draww.Size = new System.Drawing.Size(86, 25);
            this.Draww.TabIndex = 1;
            this.Draww.Text = "Добавление";
            this.Draww.UseVisualStyleBackColor = true;
            this.Draww.Click += new System.EventHandler(this.Draww_Click);
            // 
            // delete_vertex
            // 
            this.delete_vertex.Location = new System.Drawing.Point(104, 12);
            this.delete_vertex.Name = "delete_vertex";
            this.delete_vertex.Size = new System.Drawing.Size(126, 25);
            this.delete_vertex.TabIndex = 2;
            this.delete_vertex.Text = "Удаление Вершины";
            this.delete_vertex.UseVisualStyleBackColor = true;
            this.delete_vertex.Click += new System.EventHandler(this.Delete_vertex_Click);
            // 
            // view_vertex
            // 
            this.view_vertex.Location = new System.Drawing.Point(327, 12);
            this.view_vertex.Name = "view_vertex";
            this.view_vertex.Size = new System.Drawing.Size(165, 25);
            this.view_vertex.TabIndex = 3;
            this.view_vertex.Text = "Перемещение Вершин";
            this.view_vertex.UseVisualStyleBackColor = true;
            this.view_vertex.Click += new System.EventHandler(this.View_vertex_Click);
            // 
            // Chain
            // 
            this.Chain.Location = new System.Drawing.Point(236, 12);
            this.Chain.Name = "Chain";
            this.Chain.Size = new System.Drawing.Size(85, 25);
            this.Chain.TabIndex = 4;
            this.Chain.Text = "Соединить";
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Delete_Edge);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(626, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(268, 469);
            this.tabControl1.TabIndex = 10;
            // 
            // Delete_Edge
            // 
            this.Delete_Edge.Controls.Add(this.DeleteEdge);
            this.Delete_Edge.Controls.Add(this.listView1);
            this.Delete_Edge.Location = new System.Drawing.Point(4, 24);
            this.Delete_Edge.Name = "Delete_Edge";
            this.Delete_Edge.Padding = new System.Windows.Forms.Padding(3);
            this.Delete_Edge.Size = new System.Drawing.Size(260, 441);
            this.Delete_Edge.TabIndex = 0;
            this.Delete_Edge.Text = "Ребра";
            this.Delete_Edge.UseVisualStyleBackColor = true;
            // 
            // DeleteEdge
            // 
            this.DeleteEdge.Location = new System.Drawing.Point(3, 408);
            this.DeleteEdge.Name = "DeleteEdge";
            this.DeleteEdge.Size = new System.Drawing.Size(251, 27);
            this.DeleteEdge.TabIndex = 1;
            this.DeleteEdge.Text = "Удалить ребро";
            this.DeleteEdge.UseVisualStyleBackColor = true;
            this.DeleteEdge.Click += new System.EventHandler(this.DeleteEdge_Click_1);
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
            this.listView1.Size = new System.Drawing.Size(251, 396);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
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
            this.tabPage2.Size = new System.Drawing.Size(260, 441);
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
            this.ListBoxMatrix.Size = new System.Drawing.Size(248, 379);
            this.ListBoxMatrix.TabIndex = 8;
            this.ListBoxMatrix.Click += new System.EventHandler(this.ListBoxMatrix_Click_1);
            // 
            // Main_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 540);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Chain);
            this.Controls.Add(this.view_vertex);
            this.Controls.Add(this.delete_vertex);
            this.Controls.Add(this.Draww);
            this.Controls.Add(this.Field);
            this.Name = "Main_View";
            this.Text = "Fantokin option five";
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Delete_Edge.ResumeLayout(false);
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
        private TabControl tabControl1;
        private TabPage Delete_Edge;
        private TabPage tabPage2;
        private ListView listView1;
        private ListBox ListBoxMatrix;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button DeleteEdge;
    }
}