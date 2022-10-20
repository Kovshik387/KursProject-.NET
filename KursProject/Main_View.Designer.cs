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
            this.button1 = new System.Windows.Forms.Button();
            this.Cycle = new System.Windows.Forms.Button();
            this.listBoxMatrix = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
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
            this.delete_vertex.Size = new System.Drawing.Size(73, 25);
            this.delete_vertex.TabIndex = 2;
            this.delete_vertex.Text = "Удаление";
            this.delete_vertex.UseVisualStyleBackColor = true;
            this.delete_vertex.Click += new System.EventHandler(this.delete_vertex_Click);
            // 
            // view_vertex
            // 
            this.view_vertex.Location = new System.Drawing.Point(183, 12);
            this.view_vertex.Name = "view_vertex";
            this.view_vertex.Size = new System.Drawing.Size(88, 25);
            this.view_vertex.TabIndex = 3;
            this.view_vertex.Text = "Просмотр";
            this.view_vertex.UseVisualStyleBackColor = true;
            this.view_vertex.Click += new System.EventHandler(this.view_vertex_Click);
            // 
            // Chain
            // 
            this.Chain.Location = new System.Drawing.Point(306, 12);
            this.Chain.Name = "Chain";
            this.Chain.Size = new System.Drawing.Size(89, 25);
            this.Chain.TabIndex = 4;
            this.Chain.Text = "ХЗ";
            this.Chain.UseVisualStyleBackColor = true;
            this.Chain.Click += new System.EventHandler(this.Chain_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(819, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Cycle
            // 
            this.Cycle.Location = new System.Drawing.Point(772, 458);
            this.Cycle.Name = "Cycle";
            this.Cycle.Size = new System.Drawing.Size(122, 56);
            this.Cycle.TabIndex = 7;
            this.Cycle.Text = "Поиск циклов";
            this.Cycle.UseVisualStyleBackColor = true;
            this.Cycle.Click += new System.EventHandler(this.Cycle_Click);
            // 
            // listBoxMatrix
            // 
            this.listBoxMatrix.FormattingEnabled = true;
            this.listBoxMatrix.ItemHeight = 15;
            this.listBoxMatrix.Location = new System.Drawing.Point(661, 115);
            this.listBoxMatrix.Name = "listBoxMatrix";
            this.listBoxMatrix.Size = new System.Drawing.Size(196, 154);
            this.listBoxMatrix.TabIndex = 8;
            this.listBoxMatrix.Click += new System.EventHandler(this.listBoxMatrix_Click);
            // 
            // Main_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 540);
            this.Controls.Add(this.listBoxMatrix);
            this.Controls.Add(this.Cycle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Chain);
            this.Controls.Add(this.view_vertex);
            this.Controls.Add(this.delete_vertex);
            this.Controls.Add(this.Draww);
            this.Controls.Add(this.Field);
            this.Name = "Main_View";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox Field;
        private Button Draww;
        private Button delete_vertex;
        private Button view_vertex;
        private Button Chain;
        private Button button1;
        private Button Cycle;
        private ListBox listBoxMatrix;
    }
}