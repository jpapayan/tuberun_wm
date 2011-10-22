namespace TubeRun
{
    partial class FormFavoritesN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFavoritesN));
            this.mainMenuMine = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.panel_selection = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.Label();
            this.panel_mem = new System.Windows.Forms.Panel();
            this.mem4 = new System.Windows.Forms.Button();
            this.mem3 = new System.Windows.Forms.Button();
            this.mem2 = new System.Windows.Forms.Button();
            this.mem1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.run = new System.Windows.Forms.PictureBox();
            this.panel_selection.SuspendLayout();
            this.panel_mem.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuMine
            // 
            this.mainMenuMine.MenuItems.Add(this.menuItem1);
            this.mainMenuMine.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Enabled = false;
            this.menuItem1.Text = "Save";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Back";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // panel_selection
            // 
            this.panel_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_selection.Controls.Add(this.run);
            this.panel_selection.Controls.Add(this.label1);
            this.panel_selection.Controls.Add(this.comboBox2);
            this.panel_selection.Controls.Add(this.comboBox1);
            this.panel_selection.Controls.Add(this.label3);
            this.panel_selection.Location = new System.Drawing.Point(0, 23);
            this.panel_selection.Name = "panel_selection";
            this.panel_selection.Size = new System.Drawing.Size(239, 110);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 20);
            this.label1.Text = "or press save below to memorize it.";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.comboBox2.Items.Add("Northbound");
            this.comboBox2.Items.Add("Southbound");
            this.comboBox2.Items.Add("Westbound");
            this.comboBox2.Items.Add("Eastbound");
            this.comboBox2.Items.Add("Platform 1");
            this.comboBox2.Items.Add("Platform 2");
            this.comboBox2.Items.Add("Platform 3");
            this.comboBox2.Items.Add("Platform 4");
            this.comboBox2.Items.Add("Platform 5");
            this.comboBox2.Items.Add("Platform 6");
            this.comboBox2.Items.Add("Platform 7");
            this.comboBox2.Items.Add("Platform 8");
            this.comboBox2.Items.Add("Platform 9");
            this.comboBox2.Items.Add("Platform 10");
            this.comboBox2.Location = new System.Drawing.Point(7, 56);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(166, 27);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.TextChanged += new System.EventHandler(this.activate_run);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.comboBox1.Location = new System.Drawing.Point(7, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(167, 27);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.TextChanged += new System.EventHandler(this.activate_run);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Select Station";
            // 
            // line
            // 
            this.line.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.line.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.line.Location = new System.Drawing.Point(0, 0);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(240, 20);
            this.line.Text = "Line";
            this.line.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel_mem
            // 
            this.panel_mem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_mem.Controls.Add(this.mem4);
            this.panel_mem.Controls.Add(this.mem3);
            this.panel_mem.Controls.Add(this.mem2);
            this.panel_mem.Controls.Add(this.mem1);
            this.panel_mem.Controls.Add(this.label2);
            this.panel_mem.Location = new System.Drawing.Point(0, 136);
            this.panel_mem.Name = "panel_mem";
            this.panel_mem.Size = new System.Drawing.Size(240, 131);
            // 
            // mem4
            // 
            this.mem4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mem4.Enabled = false;
            this.mem4.Location = new System.Drawing.Point(124, 75);
            this.mem4.Name = "mem4";
            this.mem4.Size = new System.Drawing.Size(102, 46);
            this.mem4.TabIndex = 7;
            this.mem4.Text = "Empty";
            this.mem4.Click += new System.EventHandler(this.mem_Click);
            // 
            // mem3
            // 
            this.mem3.Enabled = false;
            this.mem3.Location = new System.Drawing.Point(15, 75);
            this.mem3.Name = "mem3";
            this.mem3.Size = new System.Drawing.Size(102, 46);
            this.mem3.TabIndex = 6;
            this.mem3.Text = "Empty";
            this.mem3.Click += new System.EventHandler(this.mem_Click);
            // 
            // mem2
            // 
            this.mem2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mem2.Enabled = false;
            this.mem2.Location = new System.Drawing.Point(124, 23);
            this.mem2.Name = "mem2";
            this.mem2.Size = new System.Drawing.Size(102, 46);
            this.mem2.TabIndex = 5;
            this.mem2.Text = "Empty";
            this.mem2.Click += new System.EventHandler(this.mem_Click);
            // 
            // mem1
            // 
            this.mem1.Enabled = false;
            this.mem1.Location = new System.Drawing.Point(15, 23);
            this.mem1.Name = "mem1";
            this.mem1.Size = new System.Drawing.Size(102, 46);
            this.mem1.TabIndex = 4;
            this.mem1.Text = "Empty";
            this.mem1.Click += new System.EventHandler(this.mem_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Favorite Stations";
            // 
            // run
            // 
            this.run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.run.Enabled = false;
            this.run.Image = ((System.Drawing.Image)(resources.GetObject("run.Image")));
            this.run.Location = new System.Drawing.Point(183, 29);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(45, 45);
            this.run.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.run.MouseDown += new System.Windows.Forms.MouseEventHandler(this.highlight);
            this.run.MouseUp += new System.Windows.Forms.MouseEventHandler(this.unhighlight);
            // 
            // FormFavoritesN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel_mem);
            this.Controls.Add(this.line);
            this.Controls.Add(this.panel_selection);
            this.KeyPreview = true;
            this.Menu = this.mainMenuMine;
            this.Name = "FormFavoritesN";
            this.Text = "TubeRun";
            this.Closed += new System.EventHandler(this.FormFavoritesN_Closed);
            this.Activated += new System.EventHandler(this.FormFavoritesN_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFavoritesN_KeyDown);
            this.panel_selection.ResumeLayout(false);
            this.panel_mem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel_selection;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.ComboBox comboBox2;
        protected System.Windows.Forms.ComboBox comboBox1;
        protected System.Windows.Forms.Label line;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Panel panel_mem;
        protected System.Windows.Forms.Button mem4;
        protected System.Windows.Forms.Button mem3;
        protected System.Windows.Forms.Button mem2;
        protected System.Windows.Forms.Button mem1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.MainMenu mainMenuMine;
        protected System.Windows.Forms.MenuItem menuItem1;
        protected System.Windows.Forms.MenuItem menuItem2;
        protected System.Windows.Forms.PictureBox run;
    }
}