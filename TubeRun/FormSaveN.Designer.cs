namespace TubeRun
{
    partial class FormSaveN
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
            this.mainMenuMine = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.line_label = new System.Windows.Forms.Label();
            this.station_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mem_auto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.mem4 = new System.Windows.Forms.Button();
            this.mem3 = new System.Windows.Forms.Button();
            this.mem2 = new System.Windows.Forms.Button();
            this.mem1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.direction_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuMine
            // 
            this.mainMenuMine.MenuItems.Add(this.menuItem1);
            this.mainMenuMine.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Clear All";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Back";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // line_label
            // 
            this.line_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.line_label.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.line_label.Location = new System.Drawing.Point(0, 0);
            this.line_label.Name = "line_label";
            this.line_label.Size = new System.Drawing.Size(240, 20);
            this.line_label.Text = "Line";
            this.line_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // station_label
            // 
            this.station_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.station_label.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.station_label.Location = new System.Drawing.Point(0, 20);
            this.station_label.Name = "station_label";
            this.station_label.Size = new System.Drawing.Size(240, 20);
            this.station_label.Text = "Station";
            this.station_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.mem_auto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.mem4);
            this.panel1.Controls.Add(this.mem3);
            this.panel1.Controls.Add(this.mem2);
            this.panel1.Controls.Add(this.mem1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 202);
            // 
            // mem_auto
            // 
            this.mem_auto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mem_auto.Location = new System.Drawing.Point(124, 153);
            this.mem_auto.Name = "mem_auto";
            this.mem_auto.Size = new System.Drawing.Size(102, 46);
            this.mem_auto.TabIndex = 5;
            this.mem_auto.Text = "Empty";
            this.mem_auto.Click += new System.EventHandler(this.saveAuto);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(4, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.Text = "Autostart Station:";
            // 
            // mem4
            // 
            this.mem4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mem4.Location = new System.Drawing.Point(124, 90);
            this.mem4.Name = "mem4";
            this.mem4.Size = new System.Drawing.Size(102, 46);
            this.mem4.TabIndex = 4;
            this.mem4.Text = "Empty";
            this.mem4.Click += new System.EventHandler(this.save);
            // 
            // mem3
            // 
            this.mem3.Location = new System.Drawing.Point(15, 90);
            this.mem3.Name = "mem3";
            this.mem3.Size = new System.Drawing.Size(102, 46);
            this.mem3.TabIndex = 3;
            this.mem3.Text = "Empty";
            this.mem3.Click += new System.EventHandler(this.save);
            // 
            // mem2
            // 
            this.mem2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mem2.Location = new System.Drawing.Point(124, 38);
            this.mem2.Name = "mem2";
            this.mem2.Size = new System.Drawing.Size(102, 46);
            this.mem2.TabIndex = 2;
            this.mem2.Text = "Empty";
            this.mem2.Click += new System.EventHandler(this.save);
            // 
            // mem1
            // 
            this.mem1.Location = new System.Drawing.Point(15, 38);
            this.mem1.Name = "mem1";
            this.mem1.Size = new System.Drawing.Size(102, 46);
            this.mem1.TabIndex = 1;
            this.mem1.Text = "Empty";
            this.mem1.Click += new System.EventHandler(this.save);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.Text = "Please select a memory to overwrite:";
            // 
            // direction_Label
            // 
            this.direction_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.direction_Label.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.direction_Label.Location = new System.Drawing.Point(0, 40);
            this.direction_Label.Name = "direction_Label";
            this.direction_Label.Size = new System.Drawing.Size(240, 20);
            this.direction_Label.Text = "Direction";
            this.direction_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(5, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 28);
            this.label3.Text = "(Activate Autostart in options)";
            // 
            // FormSaveN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.direction_Label);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.station_label);
            this.Controls.Add(this.line_label);
            this.KeyPreview = true;
            this.Menu = this.mainMenuMine;
            this.Name = "FormSaveN";
            this.Text = "TubeRun";
            this.Closed += new System.EventHandler(this.FormSaveN_Closed);
            this.Activated += new System.EventHandler(this.FormSaveN_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaveForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.MainMenu mainMenuMine;
        protected System.Windows.Forms.MenuItem menuItem1;
        protected System.Windows.Forms.MenuItem menuItem2;
        protected System.Windows.Forms.Label line_label;
        protected System.Windows.Forms.Label station_label;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label direction_Label;
        protected System.Windows.Forms.Button mem1;
        protected System.Windows.Forms.Button mem2;
        protected System.Windows.Forms.Button mem3;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Button mem4;
        protected System.Windows.Forms.Button mem_auto;
        private System.Windows.Forms.Label label3;

    }
}