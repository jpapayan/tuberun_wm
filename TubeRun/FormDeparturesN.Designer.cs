namespace TubeRun
{
    partial class FormDeparturesN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDeparturesN));
            this.mainMenuMine = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.train1_label_where = new System.Windows.Forms.Label();
            this.train1_label_dest = new System.Windows.Forms.Label();
            this.train1_label_run = new System.Windows.Forms.Label();
            this.train1_label_time = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.station_label = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.PictureBox();
            this.next = new System.Windows.Forms.PictureBox();
            this.platform_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.train2_label_where = new System.Windows.Forms.Label();
            this.train2_label_dest = new System.Windows.Forms.Label();
            this.train2_label_run = new System.Windows.Forms.Label();
            this.train2_label_time = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.train3_label_where = new System.Windows.Forms.Label();
            this.train3_label_dest = new System.Windows.Forms.Label();
            this.train3_label_run = new System.Windows.Forms.Label();
            this.train3_label_time = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.timer_update = new System.Windows.Forms.Timer();
            this.timer_nosignal = new System.Windows.Forms.Timer();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.menuItem1.Text = "Reload";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Back";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.train1_label_where);
            this.panel1.Controls.Add(this.train1_label_dest);
            this.panel1.Controls.Add(this.train1_label_run);
            this.panel1.Controls.Add(this.train1_label_time);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 72);
            // 
            // train1_label_where
            // 
            this.train1_label_where.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.train1_label_where.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.train1_label_where.Location = new System.Drawing.Point(68, 35);
            this.train1_label_where.Name = "train1_label_where";
            this.train1_label_where.Size = new System.Drawing.Size(163, 37);
            // 
            // train1_label_dest
            // 
            this.train1_label_dest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.train1_label_dest.Location = new System.Drawing.Point(68, 6);
            this.train1_label_dest.Name = "train1_label_dest";
            this.train1_label_dest.Size = new System.Drawing.Size(163, 14);
            // 
            // train1_label_run
            // 
            this.train1_label_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.train1_label_run.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.train1_label_run.Location = new System.Drawing.Point(144, 20);
            this.train1_label_run.Name = "train1_label_run";
            this.train1_label_run.Size = new System.Drawing.Size(87, 15);
            this.train1_label_run.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // train1_label_time
            // 
            this.train1_label_time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.train1_label_time.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.train1_label_time.Location = new System.Drawing.Point(68, 20);
            this.train1_label_time.Name = "train1_label_time";
            this.train1_label_time.Size = new System.Drawing.Size(50, 15);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // station_label
            // 
            this.station_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.station_label.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.station_label.Location = new System.Drawing.Point(46, 0);
            this.station_label.Name = "station_label";
            this.station_label.Size = new System.Drawing.Size(148, 20);
            this.station_label.Text = "Station";
            this.station_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // back
            // 
            this.back.Enabled = false;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.Location = new System.Drawing.Point(0, 0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(40, 40);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back.Click += new System.EventHandler(this.back_Click);
            this.back.MouseDown += new System.Windows.Forms.MouseEventHandler(this.highlight);
            this.back.MouseUp += new System.Windows.Forms.MouseEventHandler(this.unhighlight);
            // 
            // next
            // 
            this.next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.next.Enabled = false;
            this.next.Image = ((System.Drawing.Image)(resources.GetObject("next.Image")));
            this.next.Location = new System.Drawing.Point(200, 0);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(40, 40);
            this.next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.next.Click += new System.EventHandler(this.next_Click);
            this.next.MouseDown += new System.Windows.Forms.MouseEventHandler(this.highlight);
            this.next.MouseUp += new System.Windows.Forms.MouseEventHandler(this.unhighlight);
            // 
            // platform_label
            // 
            this.platform_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.platform_label.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.platform_label.Location = new System.Drawing.Point(46, 20);
            this.platform_label.Name = "platform_label";
            this.platform_label.Size = new System.Drawing.Size(148, 20);
            this.platform_label.Text = "Platform";
            this.platform_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.train2_label_where);
            this.panel2.Controls.Add(this.train2_label_dest);
            this.panel2.Controls.Add(this.train2_label_run);
            this.panel2.Controls.Add(this.train2_label_time);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(3, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 72);
            // 
            // train2_label_where
            // 
            this.train2_label_where.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.train2_label_where.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.train2_label_where.Location = new System.Drawing.Point(68, 35);
            this.train2_label_where.Name = "train2_label_where";
            this.train2_label_where.Size = new System.Drawing.Size(163, 37);
            // 
            // train2_label_dest
            // 
            this.train2_label_dest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.train2_label_dest.Location = new System.Drawing.Point(68, 6);
            this.train2_label_dest.Name = "train2_label_dest";
            this.train2_label_dest.Size = new System.Drawing.Size(163, 14);
            // 
            // train2_label_run
            // 
            this.train2_label_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.train2_label_run.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.train2_label_run.Location = new System.Drawing.Point(144, 20);
            this.train2_label_run.Name = "train2_label_run";
            this.train2_label_run.Size = new System.Drawing.Size(87, 15);
            this.train2_label_run.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // train2_label_time
            // 
            this.train2_label_time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.train2_label_time.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.train2_label_time.Location = new System.Drawing.Point(68, 20);
            this.train2_label_time.Name = "train2_label_time";
            this.train2_label_time.Size = new System.Drawing.Size(50, 15);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.train3_label_where);
            this.panel3.Controls.Add(this.train3_label_dest);
            this.panel3.Controls.Add(this.train3_label_run);
            this.panel3.Controls.Add(this.train3_label_time);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Location = new System.Drawing.Point(3, 193);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(234, 72);
            // 
            // train3_label_where
            // 
            this.train3_label_where.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.train3_label_where.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.train3_label_where.Location = new System.Drawing.Point(68, 35);
            this.train3_label_where.Name = "train3_label_where";
            this.train3_label_where.Size = new System.Drawing.Size(163, 37);
            // 
            // train3_label_dest
            // 
            this.train3_label_dest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.train3_label_dest.Location = new System.Drawing.Point(68, 6);
            this.train3_label_dest.Name = "train3_label_dest";
            this.train3_label_dest.Size = new System.Drawing.Size(163, 14);
            // 
            // train3_label_run
            // 
            this.train3_label_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.train3_label_run.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.train3_label_run.Location = new System.Drawing.Point(144, 20);
            this.train3_label_run.Name = "train3_label_run";
            this.train3_label_run.Size = new System.Drawing.Size(87, 15);
            this.train3_label_run.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // train3_label_time
            // 
            this.train3_label_time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.train3_label_time.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.train3_label_time.Location = new System.Drawing.Point(68, 20);
            this.train3_label_time.Name = "train3_label_time";
            this.train3_label_time.Size = new System.Drawing.Size(50, 15);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(59, 66);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // timer_update
            // 
            this.timer_update.Interval = 60000;
            // 
            // timer_nosignal
            // 
            this.timer_nosignal.Interval = 60000;
            this.timer_nosignal.Tick += new System.EventHandler(this.timer_nosignal_Tick);
            // 
            // FormDeparturesN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.platform_label);
            this.Controls.Add(this.next);
            this.Controls.Add(this.back);
            this.Controls.Add(this.station_label);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenuMine;
            this.Name = "FormDeparturesN";
            this.Text = "TubeRun";
            this.Deactivate += new System.EventHandler(this.FormDeparturesN_Deactivate);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Closed += new System.EventHandler(this.FormDeparturesN_Closed);
            this.Activated += new System.EventHandler(this.FormDeparturesN_Activated);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormDeparturesN_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDeparturesN_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.MainMenu mainMenuMine;
        protected System.Windows.Forms.MenuItem menuItem1;
        protected System.Windows.Forms.MenuItem menuItem2;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label station_label;
        protected System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Label train1_label_where;
        protected System.Windows.Forms.Label train1_label_dest;
        protected System.Windows.Forms.Label train1_label_run;
        protected System.Windows.Forms.Label train1_label_time;
        protected System.Windows.Forms.PictureBox back;
        protected System.Windows.Forms.PictureBox next;
        protected System.Windows.Forms.Label platform_label;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Label train2_label_where;
        protected System.Windows.Forms.Label train2_label_run;
        protected System.Windows.Forms.Label train2_label_time;
        protected System.Windows.Forms.PictureBox pictureBox2;
        protected System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.Label train3_label_where;
        protected System.Windows.Forms.Label train3_label_dest;
        protected System.Windows.Forms.Label train3_label_run;
        protected System.Windows.Forms.Label train3_label_time;
        protected System.Windows.Forms.PictureBox pictureBox3;
        protected System.Windows.Forms.Label train2_label_dest;
        private System.Windows.Forms.Timer timer_update;
        private System.Windows.Forms.Timer timer_nosignal;
    }
}