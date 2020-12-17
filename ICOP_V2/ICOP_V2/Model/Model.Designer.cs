namespace ICOP_V2.Model
{
    partial class Model
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.LbFormName = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ctbtClose = new System.Windows.Forms.Button();
            this.ctbtMaximize = new System.Windows.Forms.Button();
            this.ctbtMinimize = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.LbFormName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1550, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(102, 22);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ICOP_V2.Properties.Resources.close;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(68, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 22);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ctbtClose_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::ICOP_V2.Properties.Resources.maximize;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(34, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 22);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ctbtMaximize_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::ICOP_V2.Properties.Resources.minus;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 22);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ctbtMinimize_Click);
            // 
            // LbFormName
            // 
            this.LbFormName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.LbFormName.Controls.Add(this.label1);
            this.LbFormName.Controls.Add(this.pictureBox1);
            this.LbFormName.Controls.Add(this.tableLayoutPanel2);
            this.LbFormName.Controls.Add(this.tableLayoutPanel1);
            this.LbFormName.Dock = System.Windows.Forms.DockStyle.Top;
            this.LbFormName.Location = new System.Drawing.Point(0, 0);
            this.LbFormName.Name = "LbFormName";
            this.LbFormName.Size = new System.Drawing.Size(1652, 51);
            this.LbFormName.TabIndex = 1;
            this.LbFormName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbFormName_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ICOP - Auto multi webcams detect - Model";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbFormName_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ICOP_V2.Properties.Resources.swIcon;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbFormName_MouseDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Controls.Add(this.ctbtClose, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ctbtMaximize, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ctbtMinimize, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1550, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(102, 22);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ctbtClose
            // 
            this.ctbtClose.BackgroundImage = global::ICOP_V2.Properties.Resources.close;
            this.ctbtClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ctbtClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctbtClose.FlatAppearance.BorderSize = 0;
            this.ctbtClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ctbtClose.Location = new System.Drawing.Point(68, 0);
            this.ctbtClose.Margin = new System.Windows.Forms.Padding(0);
            this.ctbtClose.Name = "ctbtClose";
            this.ctbtClose.Size = new System.Drawing.Size(34, 22);
            this.ctbtClose.TabIndex = 2;
            this.ctbtClose.UseVisualStyleBackColor = true;
            // 
            // ctbtMaximize
            // 
            this.ctbtMaximize.BackgroundImage = global::ICOP_V2.Properties.Resources.maximize;
            this.ctbtMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ctbtMaximize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctbtMaximize.FlatAppearance.BorderSize = 0;
            this.ctbtMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ctbtMaximize.Location = new System.Drawing.Point(34, 0);
            this.ctbtMaximize.Margin = new System.Windows.Forms.Padding(0);
            this.ctbtMaximize.Name = "ctbtMaximize";
            this.ctbtMaximize.Size = new System.Drawing.Size(34, 22);
            this.ctbtMaximize.TabIndex = 1;
            this.ctbtMaximize.UseVisualStyleBackColor = true;
            // 
            // ctbtMinimize
            // 
            this.ctbtMinimize.BackgroundImage = global::ICOP_V2.Properties.Resources.minus;
            this.ctbtMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ctbtMinimize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctbtMinimize.FlatAppearance.BorderSize = 0;
            this.ctbtMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ctbtMinimize.Location = new System.Drawing.Point(0, 0);
            this.ctbtMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.ctbtMinimize.Name = "ctbtMinimize";
            this.ctbtMinimize.Size = new System.Drawing.Size(34, 22);
            this.ctbtMinimize.TabIndex = 0;
            this.ctbtMinimize.UseVisualStyleBackColor = true;
            // 
            // Model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1652, 713);
            this.ControlBox = false;
            this.Controls.Add(this.LbFormName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Model";
            this.ShowIcon = false;
            this.tableLayoutPanel2.ResumeLayout(false);
            this.LbFormName.ResumeLayout(false);
            this.LbFormName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel LbFormName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ctbtClose;
        private System.Windows.Forms.Button ctbtMaximize;
        private System.Windows.Forms.Button ctbtMinimize;
    }
}