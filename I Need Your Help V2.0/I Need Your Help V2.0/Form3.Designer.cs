namespace I_Need_Your_Help_V2._0
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.P1 = new System.Windows.Forms.PictureBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.P1)).BeginInit();
            this.SuspendLayout();
            // 
            // P1
            // 
            this.P1.BackColor = System.Drawing.Color.Black;
            this.P1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P1.Location = new System.Drawing.Point(0, 24);
            this.P1.Name = "P1";
            this.P1.Size = new System.Drawing.Size(1116, 428);
            this.P1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P1.TabIndex = 12;
            this.P1.TabStop = false;
            this.P1.Click += new System.EventHandler(this.P1_Click);
            this.P1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.P1_MouseDown);
            this.P1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.P1_MouseMove);
            this.P1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.P1_MouseUp);
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.BackColor = System.Drawing.Color.Black;
            this.CheckBox2.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBox2.ForeColor = System.Drawing.Color.Blue;
            this.CheckBox2.Location = new System.Drawing.Point(936, -3);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(151, 27);
            this.CheckBox2.TabIndex = 21;
            this.CheckBox2.Text = "Control Mouse";
            this.CheckBox2.UseVisualStyleBackColor = false;
            this.CheckBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.BackColor = System.Drawing.Color.Black;
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(1116, 24);
            this.MenuStrip1.TabIndex = 22;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(357, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(357, 24);
            this.button1.TabIndex = 23;
            this.button1.Text = "Screen Shot";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(460, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 24;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 452);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CheckBox2);
            this.Controls.Add(this.P1);
            this.Controls.Add(this.MenuStrip1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen Remote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.P1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox P1;
        internal System.Windows.Forms.CheckBox CheckBox2;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}