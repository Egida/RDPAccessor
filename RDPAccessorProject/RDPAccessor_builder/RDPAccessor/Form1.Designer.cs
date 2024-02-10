namespace RDPAccessor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.botTestBox = new System.Windows.Forms.GroupBox();
            this.accPasswdBox = new System.Windows.Forms.TextBox();
            this.accUsernameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stubBuildPanel = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chatidBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.botTokenBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buildBtn = new System.Windows.Forms.Button();
            this.saveBuildFile = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.minimazeBtn = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.botTestBox.SuspendLayout();
            this.stubBuildPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimazeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // botTestBox
            // 
            this.botTestBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(7)))), ((int)(((byte)(101)))), ((int)(((byte)(45)))));
            this.botTestBox.Controls.Add(this.accPasswdBox);
            this.botTestBox.Controls.Add(this.accUsernameBox);
            this.botTestBox.Controls.Add(this.label5);
            this.botTestBox.Controls.Add(this.label4);
            this.botTestBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botTestBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.botTestBox.ForeColor = System.Drawing.Color.White;
            this.botTestBox.Location = new System.Drawing.Point(12, 170);
            this.botTestBox.Name = "botTestBox";
            this.botTestBox.Size = new System.Drawing.Size(304, 89);
            this.botTestBox.TabIndex = 0;
            this.botTestBox.TabStop = false;
            this.botTestBox.Text = "Account Setting";
            // 
            // accPasswdBox
            // 
            this.accPasswdBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.accPasswdBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accPasswdBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.accPasswdBox.ForeColor = System.Drawing.Color.Green;
            this.accPasswdBox.Location = new System.Drawing.Point(58, 52);
            this.accPasswdBox.Multiline = true;
            this.accPasswdBox.Name = "accPasswdBox";
            this.accPasswdBox.Size = new System.Drawing.Size(233, 20);
            this.accPasswdBox.TabIndex = 0;
            // 
            // accUsernameBox
            // 
            this.accUsernameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.accUsernameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accUsernameBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.accUsernameBox.ForeColor = System.Drawing.Color.Green;
            this.accUsernameBox.Location = new System.Drawing.Point(58, 25);
            this.accUsernameBox.Multiline = true;
            this.accUsernameBox.Name = "accUsernameBox";
            this.accUsernameBox.Size = new System.Drawing.Size(233, 20);
            this.accUsernameBox.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Pass";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Login";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stubBuildPanel
            // 
            this.stubBuildPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(7)))), ((int)(((byte)(101)))), ((int)(((byte)(45)))));
            this.stubBuildPanel.Controls.Add(this.label3);
            this.stubBuildPanel.Controls.Add(this.chatidBox);
            this.stubBuildPanel.Controls.Add(this.label2);
            this.stubBuildPanel.Controls.Add(this.botTokenBox);
            this.stubBuildPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stubBuildPanel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stubBuildPanel.ForeColor = System.Drawing.Color.White;
            this.stubBuildPanel.Location = new System.Drawing.Point(12, 61);
            this.stubBuildPanel.Name = "stubBuildPanel";
            this.stubBuildPanel.Size = new System.Drawing.Size(304, 97);
            this.stubBuildPanel.TabIndex = 0;
            this.stubBuildPanel.TabStop = false;
            this.stubBuildPanel.Text = "Build Info";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "CHATID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chatidBox
            // 
            this.chatidBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chatidBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatidBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.chatidBox.ForeColor = System.Drawing.Color.Green;
            this.chatidBox.Location = new System.Drawing.Point(58, 55);
            this.chatidBox.Multiline = true;
            this.chatidBox.Name = "chatidBox";
            this.chatidBox.Size = new System.Drawing.Size(229, 20);
            this.chatidBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Token";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // botTokenBox
            // 
            this.botTokenBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.botTokenBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.botTokenBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.botTokenBox.ForeColor = System.Drawing.Color.Green;
            this.botTokenBox.Location = new System.Drawing.Point(58, 29);
            this.botTokenBox.Multiline = true;
            this.botTokenBox.Name = "botTokenBox";
            this.botTokenBox.Size = new System.Drawing.Size(229, 20);
            this.botTokenBox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panel1.Controls.Add(this.statusLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 339);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 13);
            this.panel1.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(328, 13);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Status: Idle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(55, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "RDPStealer";
            // 
            // buildBtn
            // 
            this.buildBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.buildBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buildBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buildBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buildBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buildBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buildBtn.ForeColor = System.Drawing.Color.White;
            this.buildBtn.Location = new System.Drawing.Point(100, 271);
            this.buildBtn.Name = "buildBtn";
            this.buildBtn.Size = new System.Drawing.Size(112, 35);
            this.buildBtn.TabIndex = 0;
            this.buildBtn.Text = "BUILD";
            this.buildBtn.UseVisualStyleBackColor = false;
            this.buildBtn.Click += new System.EventHandler(this.buildBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = global::RDPAccessor.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(15, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // minimazeBtn
            // 
            this.minimazeBtn.BackColor = System.Drawing.Color.Transparent;
            this.minimazeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimazeBtn.Image = global::RDPAccessor.Properties.Resources.Horizontal_Line;
            this.minimazeBtn.Location = new System.Drawing.Point(271, 11);
            this.minimazeBtn.Name = "minimazeBtn";
            this.minimazeBtn.Size = new System.Drawing.Size(17, 17);
            this.minimazeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minimazeBtn.TabIndex = 4;
            this.minimazeBtn.TabStop = false;
            this.minimazeBtn.Click += new System.EventHandler(this.minimazeBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Image = global::RDPAccessor.Properties.Resources.Close;
            this.closeBtn.Location = new System.Drawing.Point(297, 11);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(17, 17);
            this.closeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeBtn.TabIndex = 2;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(328, 352);
            this.Controls.Add(this.buildBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.minimazeBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.stubBuildPanel);
            this.Controls.Add(this.botTestBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RDPAccessor [Main]";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.botTestBox.ResumeLayout(false);
            this.botTestBox.PerformLayout();
            this.stubBuildPanel.ResumeLayout(false);
            this.stubBuildPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimazeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox botTestBox;
        private System.Windows.Forms.GroupBox stubBuildPanel;
        private System.Windows.Forms.PictureBox closeBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox minimazeBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox botTokenBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox chatidBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox accPasswdBox;
        private System.Windows.Forms.TextBox accUsernameBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buildBtn;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.SaveFileDialog saveBuildFile;
    }
}

