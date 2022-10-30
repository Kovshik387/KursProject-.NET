namespace KursProject
{
    partial class MailSend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Mail = new System.Windows.Forms.TextBox();
            this.NameF = new System.Windows.Forms.TextBox();
            this.Back_ToMainView = new System.Windows.Forms.Button();
            this.Correct = new System.Windows.Forms.Label();
            this.SendM = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Mail
            // 
            this.Mail.Location = new System.Drawing.Point(12, 12);
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(121, 23);
            this.Mail.TabIndex = 0;
            // 
            // NameF
            // 
            this.NameF.Location = new System.Drawing.Point(158, 12);
            this.NameF.Name = "NameF";
            this.NameF.Size = new System.Drawing.Size(121, 23);
            this.NameF.TabIndex = 1;
            // 
            // Back_ToMainView
            // 
            this.Back_ToMainView.Location = new System.Drawing.Point(12, 75);
            this.Back_ToMainView.Name = "Back_ToMainView";
            this.Back_ToMainView.Size = new System.Drawing.Size(90, 23);
            this.Back_ToMainView.TabIndex = 2;
            this.Back_ToMainView.Text = "Обратно";
            this.Back_ToMainView.UseVisualStyleBackColor = true;
            this.Back_ToMainView.Click += new System.EventHandler(this.Back_ToMainView_Click);
            // 
            // Correct
            // 
            this.Correct.AutoSize = true;
            this.Correct.Location = new System.Drawing.Point(12, 38);
            this.Correct.Name = "Correct";
            this.Correct.Size = new System.Drawing.Size(0, 15);
            this.Correct.TabIndex = 3;
            // 
            // SendM
            // 
            this.SendM.Location = new System.Drawing.Point(108, 75);
            this.SendM.Name = "SendM";
            this.SendM.Size = new System.Drawing.Size(171, 23);
            this.SendM.TabIndex = 4;
            this.SendM.Text = "Отправить";
            this.SendM.UseVisualStyleBackColor = true;
            this.SendM.Click += new System.EventHandler(this.SendM_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Название файла";
            // 
            // MailSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 110);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SendM);
            this.Controls.Add(this.Correct);
            this.Controls.Add(this.Back_ToMainView);
            this.Controls.Add(this.NameF);
            this.Controls.Add(this.Mail);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(307, 149);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(307, 149);
            this.Name = "MailSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MailSend";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Mail;
        private TextBox NameF;
        private Button Back_ToMainView;
        private Label Correct;
        private Button SendM;
        private Label label2;
    }
}