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
            this.listBoxMatrix = new System.Windows.Forms.ListBox();
            this.DeleteEdge = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Delete_Edge = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Field
            // 
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
            this.view_vertex.Location = new System.Drawing.Point(406, 12);
            this.view_vertex.Name = "view_vertex";
            this.view_vertex.Size = new System.Drawing.Size(88, 25);
            this.view_vertex.TabIndex = 3;
            this.view_vertex.Text = "Просмотр";
            this.view_vertex.UseVisualStyleBackColor = true;
            this.view_vertex.Click += new System.EventHandler(this.View_vertex_Click);
            // 
            // Chain
            // 
            this.Chain.Location = new System.Drawing.Point(500, 12);
            this.Chain.Name = "Chain";
            this.Chain.Size = new System.Drawing.Size(120, 25);
            this.Chain.TabIndex = 4;
            this.Chain.Text = "Соеденить";
            this.Chain.UseVisualStyleBackColor = true;
            this.Chain.Click += new System.EventHandler(this.Chain_Click);
            // 
            // Cycle
            // 
            this.Cycle.Location = new System.Drawing.Point(6, 6);
            this.Cycle.Name = "Cycle";
            this.Cycle.Size = new System.Drawing.Size(248, 36);
            this.Cycle.TabIndex = 7;
            this.Cycle.Text = "Поиск циклов";
            this.Cycle.UseVisualStyleBackColor = true;
            this.Cycle.Click += new System.EventHandler(this.Cycle_Click);
            // 
            // listBoxMatrix
            // 
            this.listBoxMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxMatrix.FormattingEnabled = true;
            this.listBoxMatrix.ItemHeight = 15;
            this.listBoxMatrix.Location = new System.Drawing.Point(3, 43);
            this.listBoxMatrix.Name = "listBoxMatrix";
            this.listBoxMatrix.Size = new System.Drawing.Size(254, 392);
            this.listBoxMatrix.TabIndex = 8;
            this.listBoxMatrix.Click += new System.EventHandler(this.ListBoxMatrix_Click);
            // 
            // DeleteEdge
            // 
            this.DeleteEdge.Location = new System.Drawing.Point(236, 13);
            this.DeleteEdge.Name = "DeleteEdge";
            this.DeleteEdge.Size = new System.Drawing.Size(87, 23);
            this.DeleteEdge.TabIndex = 9;
            this.DeleteEdge.Text = "Удаление Ребра";
            this.DeleteEdge.UseVisualStyleBackColor = true;
            this.DeleteEdge.Click += new System.EventHandler(this.DeleteEdge_Click);
            // 
            // tabControl1
            // 
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
            this.Delete_Edge.Location = new System.Drawing.Point(4, 24);
            this.Delete_Edge.Name = "Delete_Edge";
            this.Delete_Edge.Padding = new System.Windows.Forms.Padding(3);
            this.Delete_Edge.Size = new System.Drawing.Size(260, 441);
            this.Delete_Edge.TabIndex = 0;
            this.Delete_Edge.Text = "tabPage1";
            this.Delete_Edge.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxMatrix);
            this.tabPage2.Controls.Add(this.Cycle);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(260, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Main_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 540);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.DeleteEdge);
            this.Controls.Add(this.Chain);
            this.Controls.Add(this.view_vertex);
            this.Controls.Add(this.delete_vertex);
            this.Controls.Add(this.Draww);
            this.Controls.Add(this.Field);
            this.Name = "Main_View";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            this.tabControl1.ResumeLayout(false);
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
        private ListBox listBoxMatrix;
        private Button DeleteEdge;
        private TabControl tabControl1;
        private TabPage Delete_Edge;
        private TabPage tabPage2;
    }
}