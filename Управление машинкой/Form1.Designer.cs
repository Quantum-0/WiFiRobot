namespace Управление_машинкой
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
            this.panelW = new System.Windows.Forms.Panel();
            this.panelS = new System.Windows.Forms.Panel();
            this.panelA = new System.Windows.Forms.Panel();
            this.panelD = new System.Windows.Forms.Panel();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // panelW
            // 
            this.panelW.BackColor = System.Drawing.Color.Black;
            this.panelW.Location = new System.Drawing.Point(85, 31);
            this.panelW.Name = "panelW";
            this.panelW.Size = new System.Drawing.Size(64, 64);
            this.panelW.TabIndex = 0;
            // 
            // panelS
            // 
            this.panelS.BackColor = System.Drawing.Color.Black;
            this.panelS.Location = new System.Drawing.Point(85, 101);
            this.panelS.Name = "panelS";
            this.panelS.Size = new System.Drawing.Size(64, 64);
            this.panelS.TabIndex = 1;
            // 
            // panelA
            // 
            this.panelA.BackColor = System.Drawing.Color.Black;
            this.panelA.Location = new System.Drawing.Point(15, 101);
            this.panelA.Name = "panelA";
            this.panelA.Size = new System.Drawing.Size(64, 64);
            this.panelA.TabIndex = 2;
            // 
            // panelD
            // 
            this.panelD.BackColor = System.Drawing.Color.Black;
            this.panelD.Location = new System.Drawing.Point(155, 101);
            this.panelD.Name = "panelD";
            this.panelD.Size = new System.Drawing.Size(64, 64);
            this.panelD.TabIndex = 2;
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSpeed.Location = new System.Drawing.Point(12, 204);
            this.trackBarSpeed.Maximum = 150;
            this.trackBarSpeed.Minimum = 40;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(350, 45);
            this.trackBarSpeed.TabIndex = 3;
            this.trackBarSpeed.Value = 40;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            this.trackBarSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackBarSpeed_KeyDown);
            this.trackBarSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.trackBarSpeed_KeyPress);
            this.trackBarSpeed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackBarSpeed_KeyUp);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(293, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(69, 173);
            this.listBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 261);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.trackBarSpeed);
            this.Controls.Add(this.panelD);
            this.Controls.Add(this.panelA);
            this.Controls.Add(this.panelS);
            this.Controls.Add(this.panelW);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelW;
        private System.Windows.Forms.Panel panelS;
        private System.Windows.Forms.Panel panelA;
        private System.Windows.Forms.Panel panelD;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.ListBox listBox1;
    }
}

