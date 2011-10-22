namespace TubeRun
{
    partial class FormSaveW
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
            this.mem5 = new System.Windows.Forms.Button();
            this.mem6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // line_label
            // 
            this.line_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.line_label.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.line_label.Size = new System.Drawing.Size(240, 20);
            // 
            // station_label
            // 
            this.station_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.station_label.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.station_label.Size = new System.Drawing.Size(240, 20);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.mem6);
            this.panel1.Controls.Add(this.mem5);
            this.panel1.Size = new System.Drawing.Size(240, 266);
            this.panel1.Controls.SetChildIndex(this.mem_auto, 0);
            this.panel1.Controls.SetChildIndex(this.mem5, 0);
            this.panel1.Controls.SetChildIndex(this.mem4, 0);
            this.panel1.Controls.SetChildIndex(this.mem2, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.mem1, 0);
            this.panel1.Controls.SetChildIndex(this.mem3, 0);
            this.panel1.Controls.SetChildIndex(this.mem6, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            // 
            // direction_Label
            // 
            this.direction_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.direction_Label.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.direction_Label.Size = new System.Drawing.Size(240, 20);
            // 
            // mem1
            // 
            this.mem1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.mem1.Location = new System.Drawing.Point(15, 45);
            // 
            // mem2
            // 
            this.mem2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.mem2.Location = new System.Drawing.Point(124, 45);
            // 
            // mem3
            // 
            this.mem3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.mem3.Location = new System.Drawing.Point(15, 97);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(4, 217);
            this.label2.Size = new System.Drawing.Size(114, 18);
            // 
            // mem4
            // 
            this.mem4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.mem4.Location = new System.Drawing.Point(124, 97);
            // 
            // mem_auto
            // 
            this.mem_auto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.mem_auto.Location = new System.Drawing.Point(124, 217);
            // 
            // mem5
            // 
            this.mem5.Location = new System.Drawing.Point(15, 150);
            this.mem5.Name = "mem5";
            this.mem5.Size = new System.Drawing.Size(102, 46);
            this.mem5.TabIndex = 6;
            this.mem5.Text = "Empty";
            this.mem5.Click += new System.EventHandler(this.save);
            // 
            // mem6
            // 
            this.mem6.Location = new System.Drawing.Point(124, 150);
            this.mem6.Name = "mem6";
            this.mem6.Size = new System.Drawing.Size(102, 46);
            this.mem6.TabIndex = 7;
            this.mem6.Text = "Empty";
            this.mem6.Click += new System.EventHandler(this.save);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(4, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 28);
            this.label3.Text = "(Activate Autostart in options)";
            // 
            // FormSaveW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 348);
            this.Name = "FormSaveW";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mem6;
        private System.Windows.Forms.Button mem5;
        private System.Windows.Forms.Label label3;
    }
}