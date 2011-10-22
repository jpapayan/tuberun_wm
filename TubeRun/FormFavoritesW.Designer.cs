namespace TubeRun
{
    partial class FormFavoritesW
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
            this.panel_selection.SuspendLayout();
            this.panel_mem.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_selection
            // 
            this.panel_selection.Size = new System.Drawing.Size(240, 121);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.comboBox2.Size = new System.Drawing.Size(167, 29);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.comboBox1.Size = new System.Drawing.Size(167, 29);
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.line.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.line.Size = new System.Drawing.Size(240, 20);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 98);
            // 
            // panel_mem
            // 
            this.panel_mem.Controls.Add(this.mem6);
            this.panel_mem.Controls.Add(this.mem5);
            this.panel_mem.Location = new System.Drawing.Point(0, 150);
            this.panel_mem.Size = new System.Drawing.Size(240, 184);
            this.panel_mem.Controls.SetChildIndex(this.mem5, 0);
            this.panel_mem.Controls.SetChildIndex(this.mem4, 0);
            this.panel_mem.Controls.SetChildIndex(this.mem2, 0);
            this.panel_mem.Controls.SetChildIndex(this.mem3, 0);
            this.panel_mem.Controls.SetChildIndex(this.mem1, 0);
            this.panel_mem.Controls.SetChildIndex(this.label2, 0);
            this.panel_mem.Controls.SetChildIndex(this.mem6, 0);
            // 
            // mem4
            // 
            this.mem4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.mem4.Location = new System.Drawing.Point(124, 78);
            // 
            // mem3
            // 
            this.mem3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.mem3.Location = new System.Drawing.Point(15, 78);
            // 
            // mem2
            // 
            this.mem2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.mem2.Location = new System.Drawing.Point(124, 26);
            // 
            // mem1
            // 
            this.mem1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.mem1.Location = new System.Drawing.Point(15, 26);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.label2.Size = new System.Drawing.Size(112, 20);
            // 
            // run
            // 
            this.run.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.run.Location = new System.Drawing.Point(184, 30);
            // 
            // mem5
            // 
            this.mem5.Enabled = false;
            this.mem5.Location = new System.Drawing.Point(15, 130);
            this.mem5.Name = "mem5";
            this.mem5.Size = new System.Drawing.Size(102, 46);
            this.mem5.TabIndex = 8;
            this.mem5.Text = "Empty";
            this.mem5.Click += new System.EventHandler(this.mem_Click);
            // 
            // mem6
            // 
            this.mem6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mem6.Enabled = false;
            this.mem6.Location = new System.Drawing.Point(124, 130);
            this.mem6.Name = "mem6";
            this.mem6.Size = new System.Drawing.Size(102, 46);
            this.mem6.TabIndex = 9;
            this.mem6.Text = "Empty";
            this.mem6.Click += new System.EventHandler(this.mem_Click);
            // 
            // FormFavoritesW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 348);
            this.Name = "FormFavoritesW";
            this.panel_selection.ResumeLayout(false);
            this.panel_mem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mem6;
        private System.Windows.Forms.Button mem5;
    }
}